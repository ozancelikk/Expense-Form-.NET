//using Core.Entities.Concrete;
//using Quartz;
//using System;
//using System.Threading.Tasks;

//namespace Core.Utilities.Schedulers.Concrete.QuartzNet
//{
//    public class ExecuteJobService : IJob
//    {
//        public Task Execute(IJobExecutionContext context)
//        {
//            try
//            {
//                var dataMap = context.MergedJobDataMap;

//                var Plugin = (ICustomJob)dataMap.Get("Plugin");

//                var userJob = (Job)dataMap.Get("Job");

//                Plugin.Execute(userJob);

//                return Task.CompletedTask;
//            }
//            catch (Exception ex)
//            {

//                var currentTrigger = context.Trigger;


//                context.Scheduler.PauseTrigger(currentTrigger.Key);

//                Console.WriteLine($"{currentTrigger.Key} durduruldu");

//                return Task.FromResult(TaskStatus.Faulted);
//            }

//        }
//    }

//}
