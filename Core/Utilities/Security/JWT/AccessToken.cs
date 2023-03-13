using System;

namespace Core.Utilities.Security.JWT
{
    public class AccessToken
    {
        public string UserId { get; set; }
        public string Token { get; set; }
        public string Expiration { get; set; }

    }
}
