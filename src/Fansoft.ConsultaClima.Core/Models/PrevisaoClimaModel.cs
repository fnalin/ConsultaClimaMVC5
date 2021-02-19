using System;

namespace Fansoft.ConsultaClima.Core.Models
{
    public class PrevisaoClimaModel
    {
        public string Cidade { get; set; }
        public string UF { get; set; }

        public DateTime DataPrevisao { get; set; }
        public float TemperaturaMinima { get; set; }
        public float TemperaturaMaxima { get; set; }
        public string Clima { get; set; }
    }
}
