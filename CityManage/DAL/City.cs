namespace CityManage.DAL
{
    public class City : DbEntity
    {
        public Guid CountryId { get; set; }
        public string CityName { get; set; }
        public int Population { get; set; }
        public decimal Area { get; set; }
    }
}