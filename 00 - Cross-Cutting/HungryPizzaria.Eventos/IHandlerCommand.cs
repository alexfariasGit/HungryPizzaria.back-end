using System;
using System.Collections.Generic;
using System.Text;

namespace HungryPizzaria.Eventos
{
    public interface IHandlerCommand
    {
        void Build(dynamic ev);
    }
}
