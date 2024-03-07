namespace Back.Models.Repository
{
    public interface IEmpresaRepository
    {
        Task<List<Empresa>> GetListEmpresas();
        Task<Empresa> GetEmpresa(int Id);
        Task DeleteEmpresa(Empresa empresa);
        Task<Empresa> AddEmpresa(Empresa empresa);
        Task UpdateEmpresa(Empresa empresa);
    }
}
