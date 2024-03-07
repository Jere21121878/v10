using Back.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Back.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration _configuration;

        public AuthService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            _configuration = configuration;
          

        }


        public async Task<(int, string)> Registration(RegistrationModel model)
        {
            string role = ""; // Asignación predeterminada

            // Obtener el primer carácter del email
            var firstChar = model.Email.FirstOrDefault();

            if (firstChar == 'T' || firstChar == 't')
            {
                role = UserRoles.Tecnico;
            }
            else if (firstChar == 'L' || firstChar == 'l')
            {
                role = UserRoles.Licenciado;
            }
            else if (firstChar == 'A' || firstChar == 'a') 
            {
                role = UserRoles.Admin;
            }

            if (string.IsNullOrEmpty(role)) 
            {
                return (0, "Invalid role");
            }

            var userExists = await userManager.FindByNameAsync(model.Email);
            if (userExists != null)
                return (0, "User already exists");

            ApplicationUser user = new ApplicationUser()
            {
                UserName = model.Email,
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                Name = model.Name,
                Apellido = model.Apellido,
                Tsuperior = model.Tsuperior,
                Tinferior = model.Tinferior,
                Acargo = model.Acargo,
                EmpresaId = model.EmpresaId,
                EmpleadorId = model.EmpleadorId,
            };

            var createUserResult = await userManager.CreateAsync(user, model.Password);
            if (!createUserResult.Succeeded)
                return (0, "User creation failed! Please check user details and try again.");

            if (!await roleManager.RoleExistsAsync(role))
                await roleManager.CreateAsync(new IdentityRole(role));

            if (await roleManager.RoleExistsAsync(role))
                await userManager.AddToRoleAsync(user, role);

            return (1, "User created successfully!");
        }

        public async Task<(int, string, string)> Login(LoginModel model)
        {
            var user = await userManager.FindByNameAsync(model.Email);
            if (user == null)
                return (0, "Invalid username", null);
            if (!await userManager.CheckPasswordAsync(user, model.Password))
                return (0, "Invalid password", null);

            var userRoles = await userManager.GetRolesAsync(user);
            var authClaims = new List<Claim>
    {
        new Claim(ClaimTypes.Name, user.Email),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
    };

            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }

            string token = GenerateToken(authClaims);
            string role = userRoles.FirstOrDefault();
            


            return (1, token, role);
        }


        private string GenerateToken(IEnumerable<Claim> claims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _configuration["JWT:ValidIssuer"],
                Audience = _configuration["JWT:ValidAudience"],
                Expires = DateTime.UtcNow.AddHours(3),
                SigningCredentials = new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256),
                Subject = new ClaimsIdentity(claims)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
