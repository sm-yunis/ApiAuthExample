using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

[ApiController]
public class MyController : ControllerBase
{

    [HttpGet("/")]
    public ActionResult<string> Index()
    {
        return "Index page";
    }

    

    [Authorize]
    [HttpGet("/auth")]
    public ActionResult<string> Auth()
    {
        return "secret";
    }



    [HttpPost("/signin/{signInKey}")]
    public ActionResult<string> SignIn([FromRoute] string signInKey)
    {

        if (signInKey.Equals("super"))
        {

            // this should be stored in a secret location
            string secretKeyString = "superdupersuperdupersuperdupersuperdupersuperdupersuperduperSecret";
            byte[] secretKey = Encoding.ASCII.GetBytes(secretKeyString);

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = "me",
                Audience = "this",
                Expires = DateTime.Now.AddMinutes(15),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKey), SecurityAlgorithms.HmacSha256Signature)
            };

            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            SecurityToken jwtToken = jwtSecurityTokenHandler.CreateToken(tokenDescriptor);
            return Ok(jwtSecurityTokenHandler.WriteToken(jwtToken));


        }

        return Unauthorized();

    }


}