using Microsoft.EntityFrameworkCore;

namespace Back.Models.Repository
{
    public class EmergenciaRepository
    {

        private readonly AplicationDbContext _context;

        public EmergenciaRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Emergencia> AddEmergencia(Emergencia emergencia)
        {
            _context.Add(emergencia);
            await _context.SaveChangesAsync();
            return emergencia;
        }

        public async Task DeleteEmergencia(Emergencia emergencia)
        {
            _context.Emergencias.Remove(emergencia);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Emergencia>> GetListEmergencias()
        {
            return await _context.Emergencias.ToListAsync();
        }

        public async Task<Emergencia> GetEmergencia(int Id)
        {
            return await _context.Emergencias.FindAsync(Id);
        }

        public async Task UpdateEmergencia(Emergencia emergencia)
        {
            var emeItem = await _context.Emergencias.FirstOrDefaultAsync(x => x.Id == emergencia.Id);

            if (emeItem != null)
            {

                emeItem.Name = emergencia.Name;
                emeItem.Description = emergencia.Description;

                await _context.SaveChangesAsync();
            }

        }
    }
}
