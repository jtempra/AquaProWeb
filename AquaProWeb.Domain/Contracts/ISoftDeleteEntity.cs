namespace AquaProWeb.Domain.Contracts
{
    public interface ISoftDeleteEntity
    {
        public Boolean IsActive
        {
            get; set;
        }
    }
}
