namespace Back.Models
{
    public class Tecnico
    {


        public int Id { get; set; }
        public string Nombre { get; set; }
        public int LicenciadoId { get; set; }
        public Licenciado Licenciado { get; set; }

    }
}
