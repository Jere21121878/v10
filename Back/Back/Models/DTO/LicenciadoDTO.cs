namespace Back.Models.DTO
{
    public class LicenciadoDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public ICollection<Tecnico> Tecnicos { get; set; }
        public FotoDTO Foto { get; set; }

    }
}
