using Microsoft.EntityFrameworkCore;

namespace Back.Models.Repository
{
    public class EmpleadorRepository : IEmpleadorRepository
    {

        private readonly AplicationDbContext _context;

        public EmpleadorRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Empleador> AddEmpleador(Empleador empleador)
        {
            _context.Add(empleador);
            await _context.SaveChangesAsync();
            return empleador;
        }

        public async Task DeleteEmpleador(Empleador empleador)
        {
            _context.Empleadors.Remove(empleador);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Empleador>> GetListEmpleadors()
        {
            return await _context.Empleadors.ToListAsync();
        }

        public async Task<Empleador> GetEmpleador(int Id)
        {
            return await _context.Empleadors.FindAsync(Id);
        }

        public async Task UpdateEmpleador(Empleador empleador)
        {
            var empItem = await _context.Empleadors.FirstOrDefaultAsync(x => x.Id == empleador.Id);

            if (empItem != null)
            {

                empItem.Nombre = empleador.Nombre;

                await _context.SaveChangesAsync();
            }

        }

    }
}
