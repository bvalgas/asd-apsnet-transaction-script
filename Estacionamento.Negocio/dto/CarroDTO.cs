using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estacionamento.Negocio.dto
{
    public class CarroDTO
    {
        public CarroDTO(string _placa)
        {
            placa = _placa;
        }
        public string placa { get; set; }
    }
}
