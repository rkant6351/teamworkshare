using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApiCaseStudyCFTry1.Data;
using WebApiCaseStudyCFTry1.Models;

namespace WebApiCaseStudyCFTry1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly CaseStudyDbContext _dbContext;

        public AuthController(IConfiguration config, CaseStudyDbContext dbContext)
        {
            _config = config;
            _dbContext = dbContext;
        }

        [AllowAnonymous]
        [HttpPost("userauth")]
        public async Task<IActionResult> ForUser([FromBody] Users user)
        {
            IActionResult response = Unauthorized();

            if (user != null)
            {
                var dbUser = await _dbContext.Users.FirstOrDefaultAsync(u => (u.UserId == user.UserId) &&(u.Password==user.Password));

                if (dbUser != null)
                {
                    var issuer = _config["Jwt:Issuer"];
                    var audience = _config["Jwt:Audience"];
                    var key = Encoding.UTF8.GetBytes(_config["Jwt:Key"]);
                    var signingCredential = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);

                    var claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, dbUser.FullName),
                        new Claim(JwtRegisteredClaimNames.Email, dbUser.Email)
                    };

                    var expires = DateTime.UtcNow.AddMinutes(10);

                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(claims),
                        Expires = expires,
                        Issuer = issuer,
                        Audience = audience,
                        SigningCredentials = signingCredential
                    };

                    var tokenHandler = new JwtSecurityTokenHandler();
                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    var jwtToken = tokenHandler.WriteToken(token);

                    return Ok(jwtToken);
                }
            }

            return response;
        }
        [AllowAnonymous]
        [HttpPost("sellerauth")]
        public async Task<IActionResult> ForSeller([FromBody] Sellers seller)
        {
            IActionResult response = Unauthorized();

            if (seller != null)
            {
                var dbUser = await _dbContext.Sellers.FirstOrDefaultAsync(s => (s.SellerId == seller.SellerId) && (s.SellerPassword == seller.SellerPassword));

                if (dbUser != null)
                {
                    var issuer = _config["Jwt:Issuer"];
                    var audience = _config["Jwt:Audience"];
                    var key = Encoding.UTF8.GetBytes(_config["Jwt:Key"]);
                    var signingCredential = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);

                    var claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, dbUser.SellerFullName),
                        new Claim(JwtRegisteredClaimNames.Email, dbUser.SellerEmail)
                    };

                    var expires = DateTime.UtcNow.AddMinutes(10);

                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(claims),
                        Expires = expires,
                        Issuer = issuer,
                        Audience = audience,
                        SigningCredentials = signingCredential
                    };

                    var tokenHandler = new JwtSecurityTokenHandler();
                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    var jwtToken = tokenHandler.WriteToken(token);

                    return Ok(jwtToken);
                }
            }

            return response;
        }

        [AllowAnonymous]
        [HttpPost("adminauth")]
        public async Task<IActionResult> ForAdmin([FromBody] Administrators administrator)
        {
            IActionResult response = Unauthorized();

            if (administrator != null)
            {
                var admin = await _dbContext.Administrators.FirstOrDefaultAsync(a => (a.AdminId == administrator.AdminId) && (a.AdminPassword == administrator.AdminPassword));

                if (admin != null)
                {
                    var issuer = _config["Jwt:Issuer"];
                    var audience = _config["Jwt:Audience"];
                    var key = Encoding.UTF8.GetBytes(_config["Jwt:Key"]);
                    var signingCredential = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);

                    var claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, admin.AdminFullName),
                        new Claim(JwtRegisteredClaimNames.Email, admin.AdminEmail)
                    };

                    var expires = DateTime.UtcNow.AddMinutes(10);

                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(claims),
                        Expires = expires,
                        Issuer = issuer,
                        Audience = audience,
                        SigningCredentials = signingCredential
                    };

                    var tokenHandler = new JwtSecurityTokenHandler();
                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    var jwtToken = tokenHandler.WriteToken(token);

                    return Ok(jwtToken);
                }
            }

            return response;
        }
    }
}
