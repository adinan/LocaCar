using System.Collections.Generic;
using LocaCar.Business.Notificacoes;

namespace LocaCar.Business.Intefaces
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacao);
    }
}