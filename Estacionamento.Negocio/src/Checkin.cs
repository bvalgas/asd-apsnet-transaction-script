using Estacionamento.Negocio.dto;
using Estacionamento.Negocio.src;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estacionamento.Negocio
{
    public class Checkin : ICommand
    {
        private CarroDTO _carro { get; set; }

        public Checkin(CarroDTO carro)
        {
            _carro = carro;
        }

        public bool Validar()
        {
            if (String.Equals(_carro.placa.Trim(), string.Empty))
                throw new Exception(String.Format("Placa inválida.", _carro.placa));

            if (MeuEstacionamento._estacionamento.Count == MeuEstacionamento.VAGAS_TOTAIS)
                throw new Exception("Estacionamento cheio!");

            if (MeuEstacionamento._estacionamento.Any(x => x.Key.placa == _carro.placa))
                throw new Exception(String.Format("Carro carro com a placa '{0} já existe!", _carro.placa));

            return true;
        }

        /// <summary>
        /// Registra a entrada de um carro no estacionamento.
        /// </summary>
        public object Run()
        {
            Validar();
            MeuEstacionamento._estacionamento.Add(_carro, DateTime.Now);
            return true;
        }
    }
}
