namespace Back.Models.DTO
{
    public class TecnicoDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int LicenciadoId { get; set; }
        public Licenciado Licenciado { get; set; }
        public FotoDTO Foto { get; set; }

    }
}
