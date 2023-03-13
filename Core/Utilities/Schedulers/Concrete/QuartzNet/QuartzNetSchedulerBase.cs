//using Core.Entities.Concrete;
//using Quartz;
//using Quartz.Impl;
//using Quartz.Impl.Matchers;
//using System;
//using System.Threading;
//using System.Threading.Tasks;

//namespace Core.Utilities.Schedulers.Concrete.QuartzNet
//{
//    public class QuartzNetSchedulerBase
//    {
//        private static IScheduler scheduler;
//        private readonly StdSchedulerFactory schedContext;
//        public QuartzNetSchedulerBase()
//        {
//            schedContext = new StdSchedulerFactory();
//        }

//        public async Task<CustomJob> CreateJobs(Job jobs, ICustomJob customJob)
//        {
//            scheduler = await schedContext.GetScheduler();

//            if (!scheduler.IsStarted)
//            {
//                await scheduler.Start();

//                Console.WriteLine("Scheduler Çalışmaya başladı");
//            }



//            var customJob2 = new CustomJob
//            {
//                Id = customJob.Id,
//                Instance = customJob,
//                JobType = customJob.GetType(),
//                Name = customJob.Name
//            };
//            JobKey jobKey = new JobKey(customJob.Name);
//            var JobIsExist = await scheduler.CheckExists(jobKey);
//            if (!JobIsExist)
//            {
//                IJobDetail jobDetail = JobBuilder.Create<ExecuteJobService>().WithIdentity(jobKey).Build();


//                await scheduler.AddJob(jobDetail, replace: true, true, cancellationToken: CancellationToken.None);

//                GlobalJobListener globalJobListener = new GlobalJobListener();
//                scheduler.ListenerManager.AddJobListener(new GlobalJobListener(), GroupMatcher<JobKey>.AnyGroup());
//            }

//            await Task.CompletedTask;
//            return customJob2;
//        }

//        public async Task CreateTrigger(CustomJob customJobs, Job customJob)
//        {
//            var userList = new Job();



//            var jobKey = new JobKey(customJob.JobName);

//            var TriggerKey = new TriggerKey(customJob.Id.ToString());


//            var TriggerIsExist = await scheduler.CheckExists(jobKey);


//            if (TriggerIsExist)
//            {

//                var currentJob = customJobs;

//                JobDataMap jobdataMap = new JobDataMap();
//                jobdataMap.Add("Plugin", currentJob.Instance);
//                jobdataMap.Add("UserJob", customJob);


//                ITrigger jobTrigger = TriggerBuilder.Create()
//                   .WithIdentity(TriggerKey)
//                   .UsingJobData(jobdataMap)
//                   .ForJob(jobKey)
//                   //.StartNow()
//                  .WithCronSchedule(customJob.Cron)
//                  .Build();

//                var result = await scheduler.ScheduleJob(jobTrigger);


//            }

//            await Task.CompletedTask;
//        }

//    }
//}
