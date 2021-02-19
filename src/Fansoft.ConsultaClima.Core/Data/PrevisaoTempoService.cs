using Fansoft.ConsultaClima.Core.Contracts;
using Fansoft.ConsultaClima.Core.Data.EF;
using Fansoft.ConsultaClima.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Fansoft.ConsultaClima.Core.Data
{
    public class PrevisaoTempoService : IPrevisaoTempoService, IDisposable
    {
        private readonly ClimaTempoSimplesEntities _ctx = new ClimaTempoSimplesEntities();

        public async Task<IEnumerable<TopCidadeModel>> ObterCidadesTopMaxAsync(int qtde)
        {
            var date = DateTime.Now.Date;
            var data =
                await _ctx.PrevisaoClima
                        .Where(d => d.DataPrevisao == date)
                        .OrderByDescending(m => m.TemperaturaMaxima).ThenBy(m => m.Cidade).ThenBy(m => m.Cidade.Estado)
                        .Take(qtde)
                        .ToListAsync();

            return ReturnData(data);
        }

        public async Task<IEnumerable<TopCidadeModel>> ObterCidadesTopMinAsync(int qtde)
        {
            var date = DateTime.Now.Date;
            var data =
                await _ctx.PrevisaoClima
                        .Where(d => d.DataPrevisao == date)
                        .OrderBy(m => m.TemperaturaMaxima).ThenBy(m => m.Cidade).ThenBy(m => m.Cidade.Estado)
                        .Take(qtde)
                        .ToListAsync();
            return ReturnData(data);
        }

        private IEnumerable<TopCidadeModel> ReturnData(List<PrevisaoClima> data)
        {
            return (data.Select(d => new TopCidadeModel
            {
                Cidade = d.Cidade.Nome,
                UF = d.Cidade.Estado.UF,
                Temp = (float)d.TemperaturaMaxima
            })).ToList();
        }

        public async Task<IEnumerable<PrevisaoClimaModel>> ObterPorCidadeAsync(int cidadeId)
        {
            var dateIni = DateTime.Now.AddDays(1).Date;
            var dateFim = DateTime.Now.AddDays(7).Date;
            var data =
                await _ctx.PrevisaoClima
                        .Where(d =>
                                    d.CidadeId == cidadeId &&
                                    d.DataPrevisao >= dateIni &&
                                    d.DataPrevisao <= dateFim
                                )
                        .OrderBy(m => m.DataPrevisao)
                        .ToListAsync();

            return (data.Select(d => new PrevisaoClimaModel
            {
                Cidade = d.Cidade.Nome,
                UF = d.Cidade.Estado.UF,
                DataPrevisao = d.DataPrevisao,
                Clima = d.Clima,
                TemperaturaMaxima = (float)d.TemperaturaMaxima,
                TemperaturaMinima = (float)d.TemperaturaMinima
            })).ToList();

        }

        public async Task<IEnumerable<CidadeModel>> ObterCidadesAsync()
        {
            var data = await _ctx.Cidade.OrderBy(c=>c.Nome).ToListAsync();
            return data.Select(d => new CidadeModel { Id = d.Id, Nome = d.Nome });
        }

        public void Dispose()
        {
            _ctx.Dispose();
        }


    }
}
