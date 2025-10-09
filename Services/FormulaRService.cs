using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Proy_back_QBD.Data;
using Proy_back_QBD.Dto.Auxiliares;
using Proy_back_QBD.Dto.Request;
using Proy_back_QBD.Dto.Response;
using Proy_back_QBD.Models;
using Proy_back_QBD.Request;

namespace Proy_back_QBD.Services
{
    public class FormulaRService : IFormulaRService
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;
        public FormulaRService(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<FormulaRRes>?> ListaFormulaR(int sedeId)
        {
            List<FormulaRRes> response = await _context.FormulasR
                                                        .Where(w => w.SedeId == sedeId)
                                                        .Select(s => new FormulaRRes
                                                        {
                                                            Id = s.Id,
                                                            Descripcion = s.Descripcion
                                                        })
                                                        .ToListAsync();
            return response;
        }
    }
}