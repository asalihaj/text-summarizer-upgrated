using System.Collections.Generic;

namespace TextSummarizer.Models
{
    public class Text
    {
        public string Content { get; set; }
        public string Type { get; set; }
        public List<Sentence> Sentences { get; set; }
        public List<Paragraph> Paragraphs { get; set; }
        public int NumberOfSentences { get; set; }
        public int NumberOfParagrapgs { get; set; }
    }
}
