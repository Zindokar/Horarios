using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HorariosBack.Models;
using HorariosBack.Utils;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace HorariosBack.Controllers
{
  [Route("api/auth")]
  [ApiController]
  public class AuthController : ControllerBase
  {
    private readonly horariosContext _context;
    private readonly IConfiguration _config;

    public AuthController(horariosContext context, IConfiguration config)
    {
      _context = context;
      _config = config;
    }

    [HttpPost, Route("login")]
    public IActionResult Login([FromBody]Person user)
    {
      if (user == null)
      {
        return BadRequest();
      }

      var sha512 = Sha512.Generate512Digest(user.Pass);

      var currentUser =  (from login in _context.People
                          where login.Username == user.Username &&
                                login.Pass == sha512
                          select login)
                        .SingleOrDefault();

      if (currentUser == null)
      {
        return Unauthorized();
      }

      var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("Auth")["SecretKey"]));

      var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

      var tokenOptions = new JwtSecurityToken(
        issuer: "https://localhost:5001",
        audience: "https://localhost:5001",
        claims: new List<Claim>(),
        expires: DateTime.Now.AddMinutes(5),
        signingCredentials: signingCredentials
      );

      var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

      return Ok(new { Token = tokenString });
    }
  }
}
