using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HungryPizzaria.Eventos.Events;

namespace HungryPizzaria.Eventos.Abstractions
{
    public interface IIntegrationEventHandler<in TIntegrationEvent> : IIntegrationEventHandler
        where TIntegrationEvent : IntegrationEvent
    {
        Task Handle(TIntegrationEvent @event, IHandlerCommand command = null);
    }

    public interface IIntegrationEventHandler
    {
    }
}
