namespace WebAPI_Funcionarios.Models
{
    public class ServiceResponse<T>//T pode receber pode receber classe de objeto
    {
        public T? dados { get; set; }//Vai receber um objeto
        public string Mensagem { get; set; } = string.Empty;
        public bool Sucesso { get; set; } = true;

    }
}
