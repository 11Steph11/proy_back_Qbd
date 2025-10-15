using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Proy_back_QBD.Data;
using Proy_back_QBD.Dto.Request;
using Proy_back_QBD.Dto.Response;
using Proy_back_QBD.Models;
using Proy_back_QBD.Request;

namespace Proy_back_QBD.Services
{
    public class FormulaCCService : IFormulaCCService
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;
        public FormulaCCService(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<RecetaRes>?> ListarInsumos(int sedeId)
        {
            List<RecetaRes> response = await _context.FormulasCC
            .Select(s => new RecetaRes
            {
                
            })
            .ToListAsync();

            if (response == null)
            {
                return null;
            }
            
            return response;
        }
       
    }
}