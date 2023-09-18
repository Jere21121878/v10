using Microsoft.EntityFrameworkCore;

namespace Back.Models.Repository
{
    public class HistorialRepository : IHistorialRepository
    {
        private readonly AplicationDbContext _context;

        public HistorialRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Historial> AddHistorial(Historial historial)
        {
            _context.Add(historial);
            await _context.SaveChangesAsync();
            return historial;
        }

        public async Task DeleteHistorial(Historial historial)
        {
            _context.Historials.Remove(historial);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Historial>> GetListHistorials()
        {
            return await _context.Historials.ToListAsync();
        }

        public async Task<Historial> GetHistorial(int Id)
        {
            return await _context.Historials.FindAsync(Id);
        }

        public async Task UpdateHistorial(Historial historial)
        {
            var historialItem = await _context.Historials.FirstOrDefaultAsync(x => x.Id == historial.Id);

            if (historialItem != null)
            {
                historialItem.Clasi = historial.Clasi;
                historialItem.Desc = historial.Desc;
                historialItem.Causa = historial.Causa;
                historialItem.NaTr = historial.NaTr;
                historialItem.PreFu = historial.PreFu;
                historialItem.Tec = historial.Tec;
                historialItem.Conse = historial.Conse;
                historialItem.Sect = historial.Sect;
                historialItem.Fecha = historial.Fecha;




                await _context.SaveChangesAsync();
            }

        }
    }
}
