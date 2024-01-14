namespace E_commerce.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public ICategory Category { get;  }
        public IProduct Product { get; }
        public IUser User { get; }
        void Complete();

    }
}
