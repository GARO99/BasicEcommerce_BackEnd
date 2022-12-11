namespace BasicEcommerce_BackEnd.Settings
{
    public class AppSettings
    {
#nullable disable
        public DbConnectionSettings ConnectionStrings { get; set; }
        public JsonWebTokenSettings Jwt { get; set; }
    }
}
