using System.ComponentModel.DataAnnotations;

namespace Back.Models
{
    public class RegistrationModel
    {

        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        public string Name { get; set; }
        public string Apellido { get; set; }

   
        public string Tsuperior { get; set; }

       
        public string Tinferior { get; set; }


      
        public string? Acargo { get; set; }
        public int? EmpresaId { get; set; }
        public int? EmpleadorId { get; set; }

    }
}