using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TextSummarizer.Models;

namespace TextSummarizer.Services
{
    public class SummaryTool
    {
        private List<Sentence> sentences;
        private List<Sentence> summary;
        private int numOfSentences;
        private double[,] intersectionMatrix;

        private static SummaryTool instance = null;

        private SummaryTool() { }

        public static SummaryTool GetInstance()
        {
            if (instance == null)
            {
                instance = new SummaryTool();
                instance.Init();
            }
            else 
            {
                instance.Clear();
            }
            return instance;
        }

        public void Init()
        {
            sentences = new List<Sentence>();
            summary = new List<Sentence>();
            numOfSentences = 0;
        }

        private void Clear()
        {
            sentences.Clear();
            summary.Clear();
            numOfSentences = 0;
            intersectionMatrix = null;
        }

        public void ExtractSentences (string context)
        {
            string[] contextParagraphs = context.Split("\n");
            StringBuilder sentence = new StringBuilder();
            for (int i = 0; i < contextParagraphs.Length; i++)
            {
                for (int j = 0; j < contextParagraphs[i].Length; j++)
                {
                    char temp = contextParagraphs[i][j];
                    if (temp == '.' || temp == '!' || temp == '?')
                    {
                        sentence.Append(temp);
                        sentences.Add(new Sentence(numOfSentences, sentence.ToString(), i));
                        numOfSentences++;
                        sentence = new StringBuilder();
                    }
                    else 
                    {
                        sentence.Append(temp);
                    }
                }
            }
        }

        private int NumberOfCommonWords(Sentence s1, Sentence s2)
        {
            int commonCount = 0;
            string[] s1Words = s1.Value.Split("\\s+");
            string[] s2Words = s2.Value.Split("\\s+");

            foreach (string word1 in s1Words)
            {
                foreach (string word2 in s2Words)
                {
                    if(word1.CompareTo(word2) == 0)
                    {
                        commonCount++;
                    }
                }
            }
            return commonCount;
        }

        public void CreateIntersectionMatrix()
        {
            intersectionMatrix = new double[numOfSentences, numOfSentences];
            for (int i = 0; i < numOfSentences; i++)
            {
                for (int j = 0; j < numOfSentences; j++)
                {
                    if (i <= j)
                    {
                        Sentence s1 = sentences.ElementAt(i);
                        Sentence s2 = sentences.ElementAt(j);
                        intersectionMatrix[i, j] = NumberOfCommonWords(s1, s2) / ((double) (s1.NumberOfWords + s2.NumberOfWords) / 2);
                    } else {
                        intersectionMatrix[i, j] = intersectionMatrix[j, i];
                    }
                }
            }
        }

        public void AssignScore()
        {
            for (int i = 0; i < numOfSentences; i++)
            {
                double score = 0;
                for (int j = 0; j < numOfSentences; j++)
                {
                    score += intersectionMatrix[i, j];
                }
                sentences[i].Score = score;
            }
        }

        public List<Sentence> CreateSummary()
        {
            int primarySet = sentences.Count() / 2;
            sentences.Sort(new SentenceComparator());

            for (int j = 0; j <= primarySet; j++)
            {
                summary.Add(sentences[j]);
            }
            summary.Sort(new SentenceComparatorForSummary());
            return summary;
        }

    }
}