using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Proy_back_QBD.Data;
using Proy_back_QBD.Dto.Request;
using Proy_back_QBD.Dto.Response;
using Proy_back_QBD.Models;
using Proy_back_QBD.Request;

namespace Proy_back_QBD.Services
{
    public class ProdTermService : IProdTermService
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;
        public ProdTermService(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProdTerm?> Actualizar(int id, ProdTermUpdateReq request)
        {
            ProdTerm? prodTerm = await _context.ProdTerms
            .Where(p => p.Id == id)
            .FirstOrDefaultAsync();

            if (prodTerm == null)
            {
                return null;
            }

            _mapper.Map(request, prodTerm);

            await _context.SaveChangesAsync();

            return prodTerm;
        }

        public async Task<ProdTerm?> Crear(ProdTermCreateReq request)
        {
            ProdTerm prodTerm = _mapper.Map<ProdTerm>(request);
            prodTerm.ModificadorId = prodTerm.CreadorId;

            await _context.ProdTerms.AddAsync(prodTerm);
            await _context.SaveChangesAsync();
            
            return prodTerm;
        }

        public async Task<ProdTerm?> Eliminar(int id)
        {
            ProdTerm? prodTerm = await _context.ProdTerms
           .FirstOrDefaultAsync(a => a.Id == id);
            if (prodTerm == null)
            {
                return null;
            }
            _context.ProdTerms.Remove(prodTerm);
            await _context.SaveChangesAsync();
            return prodTerm;
        }

    }
}