namespace CityManage.DAL
{
    public class Factory : DbEntity
    {
        public string Guid { get; set; }
        public string FactoryName { get; set; }
        public string Product { get; set; }
    }
}