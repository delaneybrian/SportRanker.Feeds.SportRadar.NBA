using System.Threading.Tasks;

namespace SportRanker.Feeds.SportRadar.NBA.Interfaces
{
    public interface IFeedProcessor
    {
        Task StartProcessing();
    }
}
