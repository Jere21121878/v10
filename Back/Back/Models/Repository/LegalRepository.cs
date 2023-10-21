using Microsoft.EntityFrameworkCore;

namespace Back.Models.Repository
{
    public class LegalRepository : ILegalRepository
    {


        private readonly AplicationDbContext _context;

        public LegalRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Legal> AddLegal(Legal legal)
        {
            _context.Add(legal);
            await _context.SaveChangesAsync();
            return legal;
        }

        public async Task DeleteLegal(Legal legal)
        {
            _context.Legals.Remove(legal);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Legal>> GetListLegals()
        {
            return await _context.Legals.ToListAsync();
        }

        public async Task<Legal> GetLegal(int Id)
        {
            return await _context.Legals.FindAsync(Id);
        }

        public async Task UpdateLegal(Legal legal)
        {
            var legallItem = await _context.Legals.FirstOrDefaultAsync(x => x.Id == legal.Id);

            if (legallItem != null)
            {
                legallItem.Texto = legal.Texto;
                legallItem.Tipo = legal.Tipo;
                legallItem.Nombre = legal.Nombre;
                

                await _context.SaveChangesAsync();
            }

        }



    }
}
