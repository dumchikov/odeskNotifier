using System;

namespace OdeskNotifier.Services
{
    public interface ISheduler
    {
        void RunProcessByTime(DateTime timeToRun, Action whatToDo);
    }
}
