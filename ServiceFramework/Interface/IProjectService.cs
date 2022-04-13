using System.Collections.Generic;
using Dataframework.Entities;

namespace ServiceFramework.Interface
{
    public interface IProjectService
    {
        List<Project> GetAll();
    }
}