using Dataframework.Interface;

namespace Dataframework.Entities
{
    public class Role : IRole
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}