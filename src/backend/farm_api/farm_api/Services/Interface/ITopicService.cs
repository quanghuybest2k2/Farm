namespace farm_api.Services.Interface
{
    public interface ITopicService
    {
        Task<IEnumerable<string>> GetAllTopicAsync(CancellationToken cancellationToken=default);
    }
}
