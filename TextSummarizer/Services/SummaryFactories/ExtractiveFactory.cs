using TextSummarizer.Models;
using TextSummarizer.Services.Summarization;

namespace TextSummarizer.Services.SummaryFactories
{
    public class ExtractiveFactory : SummaryFactory
    {
        private string content;
        public ExtractiveFactory (Text text)
        {
            this.content = text.Content;
        }
        public override string GetSummary()
        {
            Summary summary = ExtractiveSummary.GetInstance();
            return summary.Summarize(content);
        }
    }
}