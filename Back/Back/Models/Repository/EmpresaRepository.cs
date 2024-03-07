using Microsoft.EntityFrameworkCore;

namespace Back.Models.Repository
{
    public class EmpresaRepository : IEmpresaRepository
    {
        private readonly AplicationDbContext _context;

        public EmpresaRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Empresa> AddEmpresa(Empresa empresa)
        {
            _context.Add(empresa);
            await _context.SaveChangesAsync();
            return empresa;
        }

        public async Task DeleteEmpresa(Empresa empresa)
        {
            _context.Empresas.Remove(empresa);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Empresa>> GetListEmpresas()
        {
            return await _context.Empresas.ToListAsync();
        }

        public async Task<Empresa> GetEmpresa(int Id)
        {
            return await _context.Empresas.FindAsync(Id);
        }

        public async Task UpdateEmpresa(Empresa empresa)
        {
            var empreItem = await _context.Empresas.FirstOrDefaultAsync(x => x.Id == empresa.Id);

            if (empreItem != null)
            {
                empreItem.Nombre = empresa.Nombre;

                await _context.SaveChangesAsync();
            }

        }
    }
}
