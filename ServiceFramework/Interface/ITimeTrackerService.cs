using System.Collections.Generic;
using Dataframework.Entities;

namespace ServiceFramework.Interface
{
    public interface ITimeTrackerService
    {
        List<TimeTracker> GetAllTimes();

        void EditTimer(TimeTracker time);
    }
}