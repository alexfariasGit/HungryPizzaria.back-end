using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HungryPizzaria.Eventos.Abstractions
{
    public interface IDynamicIntegrationEventHandler
    {
        Task Handle(dynamic eventData, IHandlerCommand command = null);
    }
}
