namespace Back.Models
{
    public class Empresa
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }

        public int EmpleadorId { get; set; }

    }
}
