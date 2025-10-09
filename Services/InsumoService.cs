using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Proy_back_QBD.Data;
using Proy_back_QBD.Dto.Auxiliares;
using Proy_back_QBD.Dto.Productos;
using Proy_back_QBD.Dto.Request;
using Proy_back_QBD.Dto.Response;
using Proy_back_QBD.Models;
using Proy_back_QBD.Request;

namespace Proy_back_QBD.Services
{
    public class InsumoService : IInsumoService
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;
        public InsumoService(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<InsumoLabRes>?> ListaFormulaR(int FormulaRId)
        {
            List<InsumoLabRes> response = await _context.InsumosR
                                                        .Where(w => w.FormulaRId == FormulaRId)
                                                        .Select(s => new InsumoLabRes
                                                        {
                                                            Id = s.InsumoId,
                                                            Descripcion = s.Insumo.Descripcion,
                                                            FactorCorreccion =s.Insumo.FactorCorreccion,
                                                            Dilucion=s.Insumo.Dilucion,
                                                            UnidadMedida=s.Insumo.UnidadMedida
                                                        })
                                                        .ToListAsync();
            return response;
        }
    }
}