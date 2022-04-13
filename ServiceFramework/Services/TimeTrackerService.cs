using System.Collections.Generic;
using System.Linq;
using Dataframework;
using Dataframework.Entities;
using Dataframework.Interface;
using ServiceFramework.Interface;

namespace ServiceFramework.Services
{
    public class TimeTrackerService: ITimeTrackerService
    {
        private IRepository<TimeTracker> timetrackerRepository;
        public TimeTrackerService()
        {
            this.timetrackerRepository = new Repository<TimeTracker>();
        }
        public List<TimeTracker> GetAllTimes() => this.timetrackerRepository.GetAll().ToList();


        public void EditTimer(TimeTracker time)
        {
            timetrackerRepository.Update(time);
        }
    }
}