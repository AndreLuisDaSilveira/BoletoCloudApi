using BoletoCloudApi.Business.Notificacoes;

namespace BoletoCloudApi.Business.Interfaces
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacao);
    }
}
