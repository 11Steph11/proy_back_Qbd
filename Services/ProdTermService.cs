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

        // public async Task<ProdTermUpdateResponse?> Actualizar(int id, ProdTermUpdateReq request)
        // {
        //     ProdTermUpdateResponse response = new ProdTermUpdateResponse();
        //     ProdTerm? formula = await _context.ProdTerms
        //     .Where(p => p.Id == id)
        //     .FirstOrDefaultAsync();
        //     if (formula == null)
        //     {
        //         response.Msg = "no se encontró";
        //         return response;
        //     }
        //     _mapper.Map(request, formula);
        //     response.Msg = "ProdTerm Actualizado";
        //     response.ProdTermRes = formula;
        //     await _context.SaveChangesAsync();
        //     return response;
        // }

        public async Task<ProdTerm?> Crear(ProdTermCreateReq request)
        {            
            ProdTerm prodTerm = _mapper.Map<ProdTerm>(request);
            prodTerm.ModificadorId = prodTerm.CreadorId;
            await _context.ProdTerms.AddAsync(prodTerm);            
            await _context.SaveChangesAsync();
            return prodTerm;
        }

        // public async Task<ProdTerm?> Eliminar(int id)
        // {
        //     ProdTerm? formula = await _context.ProdTerms
        //     .Include(p => p.ProdTerms)
        //     .Include(p => p.ProdTerms)
        //    .FirstOrDefaultAsync(a => a.Id == id);
        //     _context.ProdTerms.Remove(formula);
        //     foreach (var formulaFor in formula.ProdTerms)
        //     {
        //         ProdTerm formula = _mapper.Map<ProdTerm>(formulaFor);
        //         _context.ProdTerms.Remove(formula);
        //     }
        //     foreach (var prodTermFor in formula.ProdTerms)
        //     {
        //         ProdTerm prodTerm = _mapper.Map<ProdTerm>(prodTermFor);
        //         _context.ProductoTerminados.Remove(prodTerm);
        //     }
        //     await _context.SaveChangesAsync();
        //     return formula;
        // }

    }
}