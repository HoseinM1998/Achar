namespace AcharDomainCore.Entites.Config
{
    public class SiteSetting
    {
        public Connectionstring ConnectionString { get; set; }
        public string ApiKey { get; set; }


    }
    public class Connectionstring
    {
        public string SqlConnection { get; set; }
    }


}
