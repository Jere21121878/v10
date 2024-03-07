namespace Back.Models.Repository
{
    public interface IEmpleadorRepository
    {
        Task<List<Empleador>> GetListEmpleadors();
        Task<Empleador> GetEmpleador(int Id);
        Task DeleteEmpleador(Empleador empleador);
        Task<Empleador> AddEmpleador(Empleador empleador);
        Task UpdateEmpleador(Empleador empleador);

    }
}
