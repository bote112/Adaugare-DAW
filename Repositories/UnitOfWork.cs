using DAW.Data;

namespace DAW.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public ICategoriiRepository Categorii { get; private set; }
        public IFeedbackRepository Feedbacks { get; private set; }
        public IStiriRepository Stiri { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Categorii = new CategoriiRepository(_context);
            Feedbacks = new FeedbackRepository(_context);
            Stiri = new StiriRepository(_context);
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }



        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
