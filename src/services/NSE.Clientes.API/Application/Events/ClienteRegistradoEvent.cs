using NSE.Core.Messages;
using System;

namespace NSE.Clientes.API.Application.Events
{
    public class ClienteRegistradoEvent : Event
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cfp { get; set; }

        public ClienteRegistradoEvent(Guid id, string nome, string email, string cfp)
        {
            AggregateId = id;
            Id = id;
            Nome = nome;
            Email = email;
            Cfp = cfp;
        }
    }
}