using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using MovieStore.Entities;
using MovieStore.TokenOperations.Models;

namespace MovieStore.TokenOperations;
public class TokenHandler
{
    public IConfiguration Configuration {get;set;}

    public TokenHandler(IConfiguration configuration)
    {
        Configuration=configuration;
        
    }

    public Token CreateAccsessToken(Customer customer)
    {
        Token tokenModel=new Token();
        SymmetricSecurityKey key=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Key"]));
        SigningCredentials credentials= new SigningCredentials(key,SecurityAlgorithms.HmacSha256);
        tokenModel.Expiration=DateTime.Now.AddHours(1);

        JwtSecurityToken token=new JwtSecurityToken(
            issuer:Configuration["JWT:Issuer"],
            audience:Configuration["JWT:Audience"],
            expires:tokenModel.Expiration,
            notBefore:DateTime.Now,
            signingCredentials:credentials
            );
            JwtSecurityTokenHandler tokenHandler=new JwtSecurityTokenHandler();
            tokenModel.AccsessToken=tokenHandler.WriteToken(token);
            return tokenModel;
    }

}