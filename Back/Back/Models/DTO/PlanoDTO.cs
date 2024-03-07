namespace Back.Models.DTO
{
    public class PlanoDTO
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public FotoDTO Foto { get; set; }

        public int EmpresaId { get; set; }
    }
}
