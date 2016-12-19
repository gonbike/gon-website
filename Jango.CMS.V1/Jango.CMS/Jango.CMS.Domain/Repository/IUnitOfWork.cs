namespace Jango.CMS.Domain.Repository
{
    public interface IUnitOfWork
    {
        void Commit();
        void RollBack();
        bool Committed { get; set; }
    }
}