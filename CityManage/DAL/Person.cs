namespace CityManage.DAL
{
    public class Person : DbEntity
    {
        public string FirstName {get;set;}
        public string LastName {get;set;}
        public string Sex {get;set;}
        public string Position {get;set;}
    }
}