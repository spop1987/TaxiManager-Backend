using TaxiManagerDomain.Shared;

namespace TaxiManagerDomain.Entities
{
    public class Maintenance : BaseEntity
    {
        public long VehicleMileage { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; } = null;
        public bool IsRepair { get; set; } = false;
        public Money TotalPrice { get; set; } = Money.Zero();
        public Money LaborPrice { get; set; } = Money.Zero();
        public virtual Address WhereItWasMade { get; set; }
        public virtual Vehicle Vehicle { get; set; }
        public virtual List<AutoPart> AutoParts { get; set; }

    }
}