using Microsoft.EntityFrameworkCore;

namespace Back.Models.Repository
{
    public class HerramientaRepository : IHerramientaRepository
    {
        private readonly AplicationDbContext _context;

        public HerramientaRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Herramienta> AddHerramienta(Herramienta herramienta)
        {
            _context.Add(herramienta);
            await _context.SaveChangesAsync();
            return herramienta;
        }

        public async Task DeleteHerramienta(Herramienta herramienta)
        {
            _context.Herramientas.Remove(herramienta);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Herramienta>> GetListHerramientas()
        {
            return await _context.Herramientas.ToListAsync();
        }

        public async Task<Herramienta> GetHerramienta(int Id)
        {
            return await _context.Herramientas.FindAsync(Id);
        }

        public async Task UpdateHerramienta(Herramienta herramienta)
        {
            var herramientaItem = await _context.Herramientas.FirstOrDefaultAsync(x => x.Id == herramienta.Id);

            if (herramientaItem != null)
            {
                herramientaItem.Nombre = herramienta.Nombre;
                herramientaItem.Uso = herramienta.Uso;
                herramientaItem.Descripcion = herramienta.Descripcion;
                herramientaItem.Proteccion = herramienta.Proteccion;
                herramientaItem.MedidaHerra = herramienta.MedidaHerra;
                herramientaItem.MedidaUso = herramienta.MedidaUso;
                herramientaItem.Riegos = herramienta.Riegos;
                herramientaItem.Antesde = herramienta.Antesde;
                herramientaItem.Notas = herramienta.Notas;
                herramientaItem.Tipo = herramienta.Tipo;

                await _context.SaveChangesAsync();
            }

        }

    }
}
