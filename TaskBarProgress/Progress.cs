using System;
using System.Runtime.InteropServices;
using TaskBarProgress.Enums;
using TaskBarProgress.Interfaces;

namespace TaskBarProgress
{
    public static class Progress
    {
        #region Private Fields

        private static readonly ITaskbarList3 _taskbarInstance = (ITaskbarList3)new TaskbarInstance();

        private static readonly bool _taskbarSupported = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);

        #endregion Private Fields

        #region Public Methods

        public static void SetState(TaskbarStates taskbarState)
        {
            if (_taskbarSupported)
                _taskbarInstance.SetProgressState(GetConsoleWindow(), taskbarState);
        }

        public static void SetValue(double progressValue, double progressMax)
        {
            if (_taskbarSupported)
                _taskbarInstance.SetProgressValue(GetConsoleWindow(), (ulong)progressValue, (ulong)progressMax);
        }

        #endregion Public Methods

        #region Private Methods

        [DllImport("kernel32.dll")]
        private static extern IntPtr GetConsoleWindow();

        #endregion Private Methods

        #region Private Classes

        [ComImport]
        [Guid("56fdf344-fd6d-11d0-958a-006097c9a090")]
        [ClassInterface(ClassInterfaceType.None)]
        private class TaskbarInstance
        { }

        #endregion Private Classes
    }
}