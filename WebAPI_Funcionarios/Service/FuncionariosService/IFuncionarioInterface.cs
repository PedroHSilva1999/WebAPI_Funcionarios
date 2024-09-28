using WebAPI_Funcionarios.Models;

namespace WebAPI_Funcionarios.Service.FuncionariosService
{
    public interface IFuncionarioInterface
    {
        Task<ServiceResponse<List<FuncionarioModel>>> GetFuncionarios();
        Task<ServiceResponse<List<FuncionarioModel>>> CreateFuncionario(FuncionarioModel novoFuncionario);//Retorna uma lista e recebe um funcionario

        Task<ServiceResponse<FuncionarioModel>> GetFuncionarioByID(int Id);//Retorna uma lista e recebe um id

        Task<ServiceResponse<List<FuncionarioModel>>> UpdateFuncionario(FuncionarioModel FuncionarioEditado);//Retorna uma lista e recebe um funcionario

        Task<ServiceResponse<List<FuncionarioModel>>> DeleteFuncionario(int Id);

        Task<ServiceResponse<List<FuncionarioModel>>> InativaFuncionario(int Id);


    }
}
