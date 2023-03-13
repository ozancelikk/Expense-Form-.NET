namespace Core.Entities
{
    public interface IRawLog : IEntity
    {
        string CurrentDate { get; set; }
        string CurrentTime { get; set; }
        string Log { get; set; }
    }
}
