﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HungryPizzaria.Eventos.Events
{
    public class IntegrationEvent
    {
        public IntegrationEvent()
        {
            Id = Guid.NewGuid();
            CreationDate = DateTime.UtcNow;
        }

        public Guid Id { get; }
        public DateTime CreationDate { get; }
    }
}
