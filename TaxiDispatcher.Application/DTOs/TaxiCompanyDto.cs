namespace TaxiDispatcher.Application.DTOs
{
    public class TaxiCompanyDto
    {
        public TaxiCompanyDto(Guid id, string name, int basePrice)
        {
            Id = id;
            Name = name;
            BasePrice = basePrice;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public int BasePrice { get; set; }
    }
}
