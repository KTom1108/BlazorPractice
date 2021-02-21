using System.Threading;

namespace BlazorPractice.Data
{
    public class CommonService
    {
        public void SetLoadingTime(int loadingTime)
        {
            Thread.Sleep(loadingTime);
        }
    }
}
