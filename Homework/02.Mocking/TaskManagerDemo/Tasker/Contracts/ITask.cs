namespace Tasker.Contracts
{
    public interface ITask
    {
        int Id { get; set; }
        string Description { get; set; }
    }
}