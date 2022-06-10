namespace CityManage.DAL
{
    public class House : DbEntity
    {
        public Guid StreetId { get; set; }
        public string Number { get; set; }
    }
}