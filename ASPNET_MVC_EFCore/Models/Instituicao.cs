namespace ASPNET_MVC_EFCore.Models
{
    public class Instituicao
    {
        public long? InstituicaoId { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Endereco { get; set; } = string.Empty;
    }
}
