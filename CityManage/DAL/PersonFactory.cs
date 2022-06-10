namespace CityManage.DAL
{
    public class PersonFactory : DbEntity
    {
        public Guid PersonId { get; set; }
        public Guid FactoryId { get; set; }
    }
}