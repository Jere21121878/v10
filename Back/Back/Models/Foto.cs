namespace Back.Models
{
    public class Foto
    {
         public int Id { get; set; }
        public string NombreFo { get; set; }
        public byte[] Data { get; set; }
        public string? QuimicoId { get; set; }
        public string? HerramientaId { get; set; }
        public string? LicenciadoId { get; set; }
        public string? TecnicoId { get; set; }
        public string? EmpresaId { get; set; }

        public string? PlanoId { get; set; }
    }
}
