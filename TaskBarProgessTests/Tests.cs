using System.Threading;

namespace TaskBarProressTests
{
    internal class Program
    {
        #region Private Methods

        private static void Main(string[] args)
        {
            RunProgress();
        }

        private static void RunProgress()
        {
            var maxIndex = 100;

            TaskBarProgress.Progress.SetState(TaskBarProgress.Enums.TaskbarStates.Normal);

            for (var index = 0; index <= maxIndex; index++)
            {
                TaskBarProgress.Progress.SetValue(index, maxIndex);

                Thread.Sleep(100);
            }

            TaskBarProgress.Progress.SetState(TaskBarProgress.Enums.TaskbarStates.NoProgress);
        }

        #endregion Private Methods
    }
}