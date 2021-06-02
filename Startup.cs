using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace ApiAuthExample
{
    public class Startup
    {
        
        public void ConfigureServices(IServiceCollection services)
        {


            services.AddAuthentication(auth => {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(jwt => {

                jwt.SaveToken = true;
                jwt.TokenValidationParameters = new TokenValidationParameters {

                    ValidateIssuer = true,
                    ValidIssuer = "me",

                    ValidateAudience = true,
                    ValidAudience = "this",

                    ValidateLifetime = true,

                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("superdupersuperdupersuperdupersuperdupersuperdupersuperduperSecret"))

                };
            });

            services.AddControllers();


        }

        public void Configure(IApplicationBuilder app)
        {
          
            app.UseDeveloperExceptionPage();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => endpoints.MapControllers());
           
        }
    }
}
