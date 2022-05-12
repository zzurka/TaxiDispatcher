namespace TaxiDispatcher.Application.DTOs
{
    public class TaxiDto
    {
        public TaxiDto(Guid id, string driverName, TaxiCompanyDto taxiCompany, int location)
        {
            Id = id;
            DriverName = driverName;
            TaxiCompany = taxiCompany;
            Location = location;
        }

        public Guid Id { get; set; }
        public string DriverName { get; set; }
        public TaxiCompanyDto TaxiCompany { get; set; }
        public int Location { get; set; }
    }
}
