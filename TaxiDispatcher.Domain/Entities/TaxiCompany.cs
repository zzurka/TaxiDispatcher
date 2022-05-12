using TaxiDispatcher.Domain.Common;

namespace TaxiDispatcher.Domain.Entities
{
    public class TaxiCompany : BaseEntity
    {
        // public TaxiCompany(string name, int basePrice)
        // {
        //    Name = name;
        //    BasePrice = basePrice;
        // }

        public string Name { get; set; }
        public int BasePrice { get; set; }
    }
}
