using TaxiManagerDomain.Shared;

namespace TaxiManagerDomain.Entities
{
    public class AutoPart : BaseEntity
    {
        public string AutoPartName { get; set; }
        public Money Price { get; set; } = Money.Zero();
        public virtual Address WhereItWasPurchased { get; set; }
        public virtual Maintenance Maintenance { get; set; }
    }
}