using Quartz;

namespace Core.Utilities.Schedulers
{
    public interface ICustomJob : IJob
    {

        string Name { get; }

        int Id { get; }
    }
}
