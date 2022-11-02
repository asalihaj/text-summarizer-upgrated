using TextSummarizer.Models;
using TextSummarizer.Services.Summarization;

namespace TextSummarizer.Services.SummaryFactories
{
    public class AbstractiveFactory : SummaryFactory
    {
        private string content;
        public AbstractiveFactory(Text text)
        {
            this.content = text.Content;
        }
        public override string GetSummary()
        {
            Summary summary = AbstractiveSummary.GetInstance();
            return summary.Summarize(content);
        }
    }
}