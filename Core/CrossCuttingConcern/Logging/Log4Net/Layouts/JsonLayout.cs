using Core.CrossCuttingConcern.Logging.Log4Net;
using Core.CrossCuttingConcern.Logging.Log4Net.Layouts;
using log4net.Core;
using log4net.Layout;
using Newtonsoft.Json;
using System.IO;

namespace Core.CrossCuttingConcerns.Logging.Log4Net.Layouts
{
    public class JsonLayout : LayoutSkeleton
    {
        public override void ActivateOptions()
        {

        }

        public override void Format(TextWriter writer, LoggingEvent loggingEvent)
        {
            var jsonSettings = new JsonSerializerSettings();
            jsonSettings.Converters.Add(new IPConverter());
            var logEvent = new SerializableLogEvent(loggingEvent);
            var json = JsonConvert.SerializeObject(logEvent, Formatting.Indented, jsonSettings);
            writer.WriteLine(json);
        }
    }
}