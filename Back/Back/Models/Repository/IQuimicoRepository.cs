namespace Back.Models.Repository
{
    public interface IQuimicoRepository
    {
        Task<List<Quimico>> GetListQuimicos();
        Task<Quimico> GetQuimico(int Id);
        Task DeleteQuimico(Quimico quimico);
        Task<Quimico> AddQuimico(Quimico quimico);
        Task UpdateQuimico(Quimico quimico);
    }
}
