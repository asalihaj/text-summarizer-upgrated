using System.Collections.Generic;
using TextSummarizer.Models;

namespace TextSummarizer.Services
{
    public class SentenceComparatorForSummary : Comparer<Sentence>
    {
        public override int Compare(Sentence x, Sentence y)
        {
            if (x.Number > y.Number)
            {
                return 1;
            } else if (x.Number < y.Number)
            {
                return -1;
            } else
            {
                return 0;
            }
        }
    }
}
