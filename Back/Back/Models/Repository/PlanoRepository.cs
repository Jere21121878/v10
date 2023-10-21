using Microsoft.EntityFrameworkCore;

namespace Back.Models.Repository
{
    public class PlanoRepository : IPlanoRepository
    {





        private readonly AplicationDbContext _context;

        public PlanoRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Plano> AddPlano(Plano plano)
        {
            _context.Add(plano);
            await _context.SaveChangesAsync();
            return plano;
        }

        public async Task DeletePlano(Plano plano)
        {
            _context.Planos.Remove(plano);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Plano>> GetListPlanos()
        {
            return await _context.Planos.ToListAsync();
        }

        public async Task<Plano> GetPlano(int Id)
        {
            return await _context.Planos.FindAsync(Id);
        }

        public async Task UpdatePlano(Plano plano)
        {
            var planoItem = await _context.Planos.FirstOrDefaultAsync(x => x.Id == plano.Id);

            if (planoItem != null)
            {
                planoItem.Archivo = plano.Archivo;
                planoItem.Nombre = plano.Nombre;


                await _context.SaveChangesAsync();
            }

        }





    }
}
