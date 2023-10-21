namespace Back.Models.Repository
{
    public interface IAtsRepository
    {


        Task<List<Ats>> GetListAtss();
        Task<Ats> GetAts(int Id);
        Task DeleteAts(Ats ats);
        Task<Ats> AddAts(Ats ats);
        Task UpdateAts(Ats ats);


    }
}
