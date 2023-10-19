using ColabRH.Business.Notificacoes;
using System.Collections.Generic;

namespace ColabRH.Business.Interfaces;

public interface INotificador
{
    bool TemNotificacao();
    List<Notificacao> ObterNotificacoes();
    void Handle(Notificacao notificacao);
}