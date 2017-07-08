using Estacionamento.Negocio.dto;
using Estacionamento.Negocio.src;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estacionamento.Negocio
{
    public class Checkout : ICommand
    {
        private CarroDTO _carro { get; set; }

        public Checkout(CarroDTO carro)
        {
            _carro = carro;
        }

        public bool Validar(){
            if (String.Equals(_carro.placa.Trim(), string.Empty))
                throw new Exception(String.Format("Placa inválida.", _carro.placa));

            if (!MeuEstacionamento._estacionamento.Any(x => x.Key.placa == _carro.placa))
                throw new Exception(String.Format("Carro carro com a placa '{0}' NÃO existe!", _carro.placa));
            
            return true;
        }

        /// <summary>
        /// Registra a saída de um carro do estacionamento.
        /// </summary>
        public object Run()
        {
            Validar();
            DateTime horaEntrada = MeuEstacionamento._estacionamento.Single(x => x.Key.placa == _carro.placa).Value;

            MeuEstacionamento._estacionamento.Remove(MeuEstacionamento._estacionamento.Single(x => x.Key.placa == _carro.placa));

            return CalcularValorEstacionamento(horaEntrada, DateTime.Now);
        }


        /// <summary>
        /// Calcula o valor com base no tempo de permanência
        /// </summary>
        private double CalcularValorEstacionamento(DateTime entrada, DateTime saida)
        {
            var permanencia = saida.Subtract(entrada);
            return Math.Round((permanencia.TotalMinutes / 3), 2); // 3 reais é o valor mínimo
        }
    }
}
