using Microsoft.AspNetCore.Authorization;

namespace Finances.Backend.Authorization
{
    public class MinAge : IAuthorizationRequirement
    {
        public MinAge(byte age) {
            Age = age;
        }
        public byte Age { get; set; }
    }
}
