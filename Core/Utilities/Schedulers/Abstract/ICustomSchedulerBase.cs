using System.Threading.Tasks;

namespace Core.Utilities.Schedulers.Abstract
{
    public interface ICustomSchedulerBase
    {
        Task Execute();
    }
}
