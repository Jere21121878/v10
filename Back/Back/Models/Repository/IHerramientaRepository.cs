namespace Back.Models.Repository
{
    public interface IHerramientaRepository
    {
        Task<List<Herramienta>> GetListHerramientas();
        Task<Herramienta> GetHerramienta(int Id);
        Task DeleteHerramienta(Herramienta herramienta);
        Task<Herramienta> AddHerramienta(Herramienta herramienta);
        Task UpdateHerramienta(Herramienta herramienta);
    }
}
