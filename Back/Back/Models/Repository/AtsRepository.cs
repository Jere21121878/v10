using Microsoft.EntityFrameworkCore;

namespace Back.Models.Repository
{
    public class AtsRepository : IAtsRepository
    {


        private readonly AplicationDbContext _context;

        public AtsRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Ats> AddAts(Ats ats)
        {
            _context.Add(ats);
            await _context.SaveChangesAsync();
            return ats;
        }

        public async Task DeleteAts(Ats ats)
        {
            _context.Atss.Remove(ats);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Ats>> GetListAtss()
        {
            return await _context.Atss.ToListAsync();
        }

        public async Task<Ats> GetAts(int Id)
        {
            return await _context.Atss.FindAsync(Id);
        }

        public async Task UpdateAts(Ats ats)
        {
            var atsItem = await _context.Atss.FirstOrDefaultAsync(x => x.Id == ats.Id);

            if (atsItem != null)
            {
                atsItem.ResponsableDelTrabajo = ats.ResponsableDelTrabajo;
                atsItem.Tarea = ats.Tarea;
                atsItem.Area = ats.Area;
                atsItem.Fecha = ats.Fecha;
                atsItem.Peligros = ats.Peligros;
                atsItem.Herramientas = ats.Herramientas;
                atsItem.Proteccion = ats.Proteccion;
                atsItem.Personal = ats.Personal;
                atsItem.DescripccionEt = ats.DescripccionEt;
                atsItem.RiegosEt = ats.RiegosEt;
                atsItem.Valoracion = ats.Valoracion;
                atsItem.MedidasPreventi = ats.MedidasPreventi;
                atsItem.ValoracionPost = ats.ValoracionPost;

                await _context.SaveChangesAsync();
            }

        }



    }
}
