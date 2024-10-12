using System.ComponentModel;

namespace Web.ViewModels.Forms
{
    public class OpcionalCadastrarViewModel
    {
        [DisplayName("Nome Opcional")]
        public string? Nome { get; set; }
    }
}
