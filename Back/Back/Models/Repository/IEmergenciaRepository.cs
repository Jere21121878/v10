namespace Back.Models.Repository
{
    public interface IEmergenciaRepository
    {
        Task<List<Emergencia>> GetListEmergencias();
        Task<Emergencia> GetEmergencia(int Id);
        Task DeleteEmergencia(Emergencia emergencia);
        Task<Emergencia> AddEmergencia(Emergencia emergencia);
        Task UpdateEmergencia(Emergencia emergencia);

    }
}
