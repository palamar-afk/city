namespace CityManage.DAL
{
    public class Street : DbEntity
    {
        public Guid DistrictId { get; set; }
        public string StreetName { get; set; }
        public string PostalCode { get; set; }
    }
}