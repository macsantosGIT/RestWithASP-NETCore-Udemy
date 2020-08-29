namespace RestWithASPNETCore.Security.Configuration
{
    public class TokenCofiguration
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public int Seconds { get; set; }
    }
}
