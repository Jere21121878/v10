namespace Back.Models.DTO
{
    public class EmpresaDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public FotoDTO Foto { get; set; }

        public int EmpleadorId { get; set; }

    }
}
