using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Back.Models
{
    public class ApplicationUser : IdentityUser
    
    {


       
        public string? Name { get; set; }
        
        public string Apellido { get; set; }

       
        public string Tsuperior { get; set; }
        public string? Acargo { get; set; }


        public string Tinferior { get; set; }

        public int? EmpleadorId { get; set; }

        public int? EmpresaId { get; set; }





    }
}
