using System.Collections.Generic;
using Fit.HealthCareApi.Application.Notificacoes;

namespace Fit.HealthCareApi.Application.Intefaces
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacao);
    }
}