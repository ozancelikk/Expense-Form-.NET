using Core.CrossCuttingConcerns.Logging.Log4Net;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Quartz;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Utilities.Schedulers.Concrete.QuartzNet
{ 
public class GlobalJobListener : IJobListener
{
    public string Name => "SchedulerListener";
    private LoggerServiceBase _loggerServiceBase;
    public GlobalJobListener()
    {
        _loggerServiceBase = (LoggerServiceBase)Activator.CreateInstance(typeof(FileLogger));
    }

    public Task JobExecutionVetoed(IJobExecutionContext context, CancellationToken cancellationToken = default)
    {

        _loggerServiceBase.Info($"{context.JobDetail.JobType} Job'ı {DateTime.Now} zamanında   ({context.JobDetail.Key})  reddedildi");

        return Task.CompletedTask;
    }



    public Task JobToBeExecuted(IJobExecutionContext context, CancellationToken cancellationToken = default)
    {
        _loggerServiceBase.Info($"{context.JobDetail.JobType} Job'ı {DateTime.Now} zamanında  ({context.JobDetail.Key})  Çalıştırılacak");
        return Task.CompletedTask;
    }

    public Task JobWasExecuted(IJobExecutionContext context, JobExecutionException jobException, CancellationToken cancellationToken = default)
    {
        _loggerServiceBase.Info($"{context.JobDetail.JobType} Job'ı {DateTime.Now} zamanında  ({context.JobDetail.Key})  Çalıştırıldı");
        return Task.CompletedTask;
    }
    }
}