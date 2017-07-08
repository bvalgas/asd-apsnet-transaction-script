using Estacionamento.Negocio.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estacionamento.Negocio
{
    public interface ICommand
    {
        bool Validar();
        object Run();
    }
}
