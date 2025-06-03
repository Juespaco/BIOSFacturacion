namespace GrupoBIOS.Services.API.Services
{
    public interface IJobProcesosServices
    {
        void FireAndForgetJob();
        Task ReccurringJob();
        void DelayedJob();
        void ContinuationJob();
    }
}
