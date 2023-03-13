using Business.Abstract;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class OrianaFeaturesManager : IOrianaFeaturesServices
    {

        private List<int> PortNumbersToListen { get; set; }
        public static Dictionary<string, Task> _tasks;

        public OrianaFeaturesManager()
        {

        }

        public void RunWithDefaultSettings(CancellationToken stoppingToken)
        {

        }


    }
}
