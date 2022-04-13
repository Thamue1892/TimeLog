namespace Dataframework.Interface
{
    public interface IUser
    {
        int Id { get; set; }
        string FullName { get; set; }
        string Email { get; set; }
        string Address { get; set; }
        int SupervisorId { get; set; }
        int RoleId { get; set; }
    }
}