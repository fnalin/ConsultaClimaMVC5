using Fansoft.ConsultaClima.Core.Models;
using System.Collections.Generic;

namespace Fansoft.ConsultaClima.UI.Models
{
    public class ClimaGetTopsVM
    {
        public ClimaGetTopsVM(IEnumerable<TopCidadeModel> topQuentes, IEnumerable<TopCidadeModel> topFrias)
        {
            TopQuentes = topQuentes;
            TopFrias = topFrias;
        }
        public IEnumerable<TopCidadeModel> TopQuentes { get; }
        public IEnumerable<TopCidadeModel> TopFrias { get; }
    }
}
