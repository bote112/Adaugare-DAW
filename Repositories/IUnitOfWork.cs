namespace DAW.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoriiRepository Categorii { get; }
        IFeedbackRepository Feedbacks { get; }
        Task<int> CompleteAsync();

        IStiriRepository Stiri { get; }
        int Complete();
    }
}
