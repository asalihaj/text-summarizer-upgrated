using System.Text.RegularExpressions;

namespace TextSummarizer.Models
{
    public class Sentence
    {
        public int ParagraphNumber { get; set; }
        public int Number { get; set; }
        public double Score { get; set; }
        public int NumberOfWords { get; set; }
        public string Value { get; set; }

        public Sentence(int Number, string Value, int ParagraphNumber)
        {
            this.Number = Number;
            this.Value = Value;
            NumberOfWords = Regex.Split(Value, "\\s+").Length;
            Score = 0;
            this.ParagraphNumber = ParagraphNumber;
        }

    }
}
