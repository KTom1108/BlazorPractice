using System.Threading;

namespace BlazorPractice.Data
{
    public class CommonService
    {
        public string selectedCulture = Thread.CurrentThread.CurrentCulture.Name;

        public void SetLoadingTime(int loadingTime)
        {
            Thread.Sleep(loadingTime);
        }
    }
}
