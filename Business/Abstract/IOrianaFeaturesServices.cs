using System.Threading;

namespace Business.Abstract
{
    public interface IOrianaFeaturesServices
    {
        void RunWithDefaultSettings(CancellationToken stoppingToken);
    }
}
