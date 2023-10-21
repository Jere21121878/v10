namespace Back.Models
{
    public class Licenciado
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public ICollection<Tecnico> Tecnicos { get; set; }
    }
}
