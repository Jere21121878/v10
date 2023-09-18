namespace Back.Models.Repository
{
    public interface IHistorialRepository
    {
        Task<List<Historial>> GetListHistorials();
        Task<Historial> GetHistorial(int Id);
        Task DeleteHistorial(Historial historial);
        Task<Historial> AddHistorial(Historial historial);
        Task UpdateHistorial(Historial historial);


    }
}
