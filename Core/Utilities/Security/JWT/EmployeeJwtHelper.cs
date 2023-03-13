using Core.Entities.Concrete;
using Core.Extensions;
using Core.Utilities.Security.Encryption;
using Entities.Concrete;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Core.Utilities.Security.JWT
{
    public class EmployeeJwtHelper : IEmployeeTokenHelper
    {
        public IConfiguration Configuration{ get; }
        private TokenOptions _TokenOptions;
        private DateTime _accessTokenExpiration;
        public EmployeeJwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            _TokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();
        }
        public EmployeeAccessToken CreateToken(Employee employee, List<OperationClaim> operationClaims)
        {
            _accessTokenExpiration = DateTime.Now.AddMinutes(_TokenOptions.AccessTokenExpiration);
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_TokenOptions.SecurityKey);
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
            var jwt = CreateJwtSecurityToken(_TokenOptions, employee, signingCredentials, operationClaims);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);

            return new EmployeeAccessToken
            {
                Token = token,
                Expiration = _accessTokenExpiration.ToString("yyy-MM-dd HH:mm:ss")
            };
        }

        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, Employee employee,
            SigningCredentials signingCredentials, List<OperationClaim> operationClaims)
        {
            var jwt = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                expires: _accessTokenExpiration,
                notBefore: DateTime.Now,
                claims: SetClaims(employee, operationClaims),
                signingCredentials: signingCredentials
                );
            return jwt;
        }
        private IEnumerable<Claim> SetClaims(Employee employee, List<OperationClaim> operationClaims)
        {
            var claims = new List<Claim>();

            claims.AddNameIdentifier(employee.Id.ToString());
            claims.AddName($"{employee.Name} {employee.Surname}");
            claims.AddEmail(employee.EMail);
            claims.AddRoles(operationClaims.Select(c => c.Name).ToArray());
            return claims;
        }

    }
}
