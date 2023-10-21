namespace Back.Models.Repository
{
    public interface IPlanoRepository
    {

        Task<List<Plano>> GetListPlanos();
        Task<Plano> GetPlano(int Id);
        Task DeletePlano(Plano plano);
        Task<Plano> AddPlano(Plano plano);
        Task UpdatePlano(Plano plano);
    }
}
