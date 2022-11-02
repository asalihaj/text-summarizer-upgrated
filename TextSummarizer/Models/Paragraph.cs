using System.Collections.Generic;

namespace TextSummarizer.Models
{
    public class Paragraph
    {
        public int Number{ get; set; }
        public List<Sentence> Sentences { get; set; }

        public Paragraph(int Number)
        {
            this.Number = Number;
            Sentences = new List<Sentence>();
        }
    }
}
