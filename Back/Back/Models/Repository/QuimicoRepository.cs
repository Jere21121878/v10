using Microsoft.EntityFrameworkCore;

namespace Back.Models.Repository
{
    public class QuimicoRepository : IQuimicoRepository
    {
        private readonly AplicationDbContext _context;

        public QuimicoRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Quimico> AddQuimico(Quimico quimico)
        {
            _context.Add(quimico);
            await _context.SaveChangesAsync();
            return quimico;
        }

        public async Task DeleteQuimico(Quimico quimico)
        {
            _context.Quimicos.Remove(quimico);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Quimico>> GetListQuimicos()
        {
            return await _context.Quimicos.ToListAsync();
        }

        public async Task<Quimico> GetQuimico(int Id)
        {
            return await _context.Quimicos.FindAsync(Id);
        }

        public async Task UpdateQuimico(Quimico quimico)
        {
            var quimicoItem = await _context.Quimicos.FirstOrDefaultAsync(x => x.Id == quimico.Id);

            if (quimicoItem != null)
            {
                quimicoItem.Nombre = quimico.Nombre;
                quimicoItem.CAS = quimico.CAS;
                quimicoItem.NumeroOnu = quimico.NumeroOnu;
                quimicoItem.AnteIncendio = quimico.AnteIncendio;
                quimicoItem.Combustion = quimico.Combustion;
                quimicoItem.PrevencionIncendio = quimico.PrevencionIncendio;
                quimicoItem.PeligrosFisicos = quimico.PeligrosFisicos;
                quimicoItem.PeligrosQuimicos = quimico.PeligrosQuimicos;
                quimicoItem.AnteDerramesyFugas = quimico.AnteDerramesyFugas;
                quimicoItem.LimitesdeExposicionLaboral = quimico.LimitesdeExposicionLaboral;
                quimicoItem.Uso = quimico.Uso;
                quimicoItem.PrimerosAuxilios = quimico.PrimerosAuxilios;
                quimicoItem.ClasedePeligroONU = quimico.ClasedePeligroONU;
                quimicoItem.Almacenamiento = quimico.Almacenamiento;
                quimicoItem.InformacionFisicoQuimica = quimico.InformacionFisicoQuimica;
                quimicoItem.Aspecto = quimico.Aspecto;
                quimicoItem.Notas = quimico.Notas;


                await _context.SaveChangesAsync();
            }

        }

    }
}
