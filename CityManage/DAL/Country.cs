namespace CityManage.DAL
{
    public class Country : DbEntity
    {
        public string CountryName { get; set; }
        public int Population { get; set; }
        public decimal Area { get; set; }
    }
}