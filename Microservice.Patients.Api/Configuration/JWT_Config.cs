using Microservice.Patients.Application.AppSettings;
using Microservice.Patients.Application.AppSettings.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Microservice.Patients.Api.Configuration
{
    public class JWT_Config
    {
        public JWT_Config(IServiceCollection services, AppSettings settings) { 
            string secretKey = AppSettings_Helper.Auth.SecretKey;

            
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {


                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = AppSettings_Helper.Auth.Issuer, // Cambia esto por tu emisor
                    ValidAudience = AppSettings_Helper.Auth.Audience, // Cambia esto por tu audiencia
                    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(secretKey))
                };
            });
            

        } 
    }
}
