namespace DeskFlow.Shared.Models
{
    public enum TaskState
    {
        Todo,       // Task is yet to be started
        InProgress, // Task is currently being worked on
        Done,       // Task has been completed
        Blocked     // Task cannot proceed due to some issue
    }
}
