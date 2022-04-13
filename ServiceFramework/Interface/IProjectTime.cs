using System.Collections.Generic;
using Dataframework.Entities;

namespace ServiceFramework.Interface
{
    public interface IProjectTime
    {
        List<TimeInProject> GetUserTime(int id);

        List<TimeInProject> UserTimePerProject(int id);
    }
}