namespace MMC_Auth.Infrastructure.Helpers
{
	public class JWT
	{
        //this class is read all attribute exists in File Json 
        public string key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public double DurationInDay { get; set; }
	}
}