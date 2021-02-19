using Fansoft.ConsultaClima.Core.Models;
using System.Collections.Generic;

namespace Fansoft.ConsultaClima.UI.Models
{
    public class GetPorCidadeVM
    {
        public string Cidade { get; set; }
        public IEnumerable<PrevisaoClimaModel> Dados { get; set; }
    }
}
