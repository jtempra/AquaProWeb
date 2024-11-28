namespace AquaProWeb.Domain.Contracts
{
    public abstract class AuditableBaseEntity : BaseEntity
    {

        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public string LastModifiedBy { get; set; }
    }
}
