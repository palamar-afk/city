namespace CityManage.DAL
{
    public class PersonHouse : DbEntity
    {
        public Guid PersonId { get; set; }
        public Guid HouseId { get; set; }
    }
}