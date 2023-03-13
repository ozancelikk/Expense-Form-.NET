using System.Threading.Tasks;

namespace DataAccess.Concrete.MessageBrokers.Abstract
{
    public interface IQueueAdditionalFeaturesService
    {
        Task ApplyDefaultConfigurations();

    }
}
