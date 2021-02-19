using Fansoft.ConsultaClima.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fansoft.ConsultaClima.Core.Contracts
{
    public interface IPrevisaoTempoService
    {
        Task<IEnumerable<TopCidadeModel>> ObterCidadesTopMinAsync(int qtde);
        Task<IEnumerable<TopCidadeModel>> ObterCidadesTopMaxAsync(int qtde);

        Task<IEnumerable<PrevisaoClimaModel>> ObterPorCidadeAsync(int cidadeId);

        Task<IEnumerable<CidadeModel>> ObterCidadesAsync();
    }
}
