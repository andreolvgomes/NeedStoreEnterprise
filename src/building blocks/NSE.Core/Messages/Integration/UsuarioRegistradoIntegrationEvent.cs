using System;

namespace NSE.Core.Messages.Integration
{
    public class UsuarioRegistradoIntegrationEvent : IntegrationEvent
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }

        public UsuarioRegistradoIntegrationEvent(Guid id, string nome, string email, string cfp)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Cpf = cfp;
        }
    }
}