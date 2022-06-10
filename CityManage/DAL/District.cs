namespace CityManage.DAL
{
    public class District : DbEntity
    {
        public Guid CityId {get;set;}
        public string DistrictName {get;set;}
        public decimal Area {get;set;}
    }
}