
namespace GrupoBIOS.Services.API.Services
{
    public class JobProcesosServices : IJobProcesosServices
    {
        private readonly ILogger _logger;
        //private readonly ICalculosApplication _Application;

        //public JobProcesosServices(ILogger<JobProcesosServices> logger, ICalculosApplication _Application)
        public JobProcesosServices(ILogger<JobProcesosServices> logger)
        {
            _logger = logger;
            //this._Application = _Application;
        }

        public void ContinuationJob()
        {
            _logger.LogInformation("Ejecución de ContinuationJob");
        }

        public void DelayedJob()
        {
            _logger.LogInformation("Ejecución desde el DelayedJob");
        }

        public void FireAndForgetJob()
        {
            _logger.LogInformation("Ejecución desde el FireAndForgetJob");
        }

        public Task ReccurringJob()
        {
            ////await _Application.Calculos();
            throw new NotImplementedException();
        }
    }
}
