namespace Finances.Backend.Helper
{
    public class System
    {
        public static bool IsDevelopment()
        {
            string env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? Environments.Production;

            var envDevelopment = new List<string>
            {
                Environments.Development,
                "Local"
            };

            if(envDevelopment.Contains(env))
                return true;
            
            return false;
        }
    }
}
