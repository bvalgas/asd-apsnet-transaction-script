using Estacionamento.Negocio.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estacionamento.Negocio.src
{
    public static class MeuEstacionamento
    {
        public const int VAGAS_TOTAIS = 15;
        public static IDictionary<CarroDTO, DateTime> _estacionamento = new Dictionary<CarroDTO, DateTime>();
    }
}
