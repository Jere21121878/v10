namespace Back.Models.Repository
{
    public interface ILegalRepository
    {

        Task<List<Legal>> GetListLegals();
        Task<Legal> GetLegal(int Id);
        Task DeleteLegal(Legal legal);
        Task<Legal> AddLegal(Legal legal);
        Task UpdateLegal(Legal legal);


    }
}
