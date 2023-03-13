using Core.Utilities.Schedulers.Abstract;
using Quartz;
using System.Threading.Tasks;
namespace Core.Utilities.Schedulers.Concrete.QuartzNet
{
    public class SchedulerBase : ISchedulerBase
    {

        public Task Execute(IJobExecutionContext context)
        {
            var dataMap = context.MergedJobDataMap;
            var Plugin = (ICustomSchedulerBase)dataMap.Get("Plugin");
            Plugin.Execute();
            return Task.CompletedTask;
        }

    }
}
