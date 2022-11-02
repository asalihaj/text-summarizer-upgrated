using System.Collections.Generic;
using System.Text;
using TextSummarizer.Models;

namespace TextSummarizer.Services.Summarization
{
    public class ExtractiveSummary : Summary
    {
        private static ExtractiveSummary instance = null;

        private ExtractiveSummary() { }

        public static ExtractiveSummary GetInstance()
        {
            if (instance == null)
            {
                instance = new ExtractiveSummary();
            }
            return instance;
        }
        public override string Summarize(string content)
        {
            SummaryTool tool = SummaryTool.GetInstance();
            tool.ExtractSentences(content);
            tool.CreateIntersectionMatrix();
            tool.AssignScore();
            List<Sentence> summary = tool.CreateSummary();
            string result = ParseToString(summary);
            return result;
        }

        private string ParseToString(List<Sentence> summary)
        {
            StringBuilder result = new StringBuilder();
            foreach (Sentence sentence in summary)
            {
                result.Append(sentence.Value);
                result.Append(' ');
            }
            return result.ToString();
        }
    }
}