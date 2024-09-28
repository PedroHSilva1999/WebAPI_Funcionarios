using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WebAPI_Funcionarios.DataContext;
using WebAPI_Funcionarios.Models;

namespace WebAPI_Funcionarios.Service.FuncionariosService
{
    public class FuncionariosService : IFuncionarioInterface
    {
        private readonly ApplicationDbContext _context;
        public FuncionariosService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ServiceResponse<List<FuncionarioModel>>> CreateFuncionario(FuncionarioModel novoFuncionario)
        {
            ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();

            try
            {
                if(novoFuncionario == null)
                {
                    serviceResponse.dados = null;
                    serviceResponse.Mensagem = "Informe os dados corretamente";
                    serviceResponse.Sucesso =false;
                    return serviceResponse;
                }
                _context.Add(novoFuncionario);
               await _context.SaveChangesAsync();
               
               serviceResponse.dados = _context.Funcionarios.ToList();
                return serviceResponse;


            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<FuncionarioModel>>> DeleteFuncionario(int Id)
        {
            ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();

            try
            {
                if (Id == null)
                {
                    serviceResponse.dados = null;
                    serviceResponse.Mensagem = "Nenhum usuario encontrado";
                }
                var FuncionarioSelecionado = _context.Funcionarios.FirstOrDefault(x => x.Id == Id);
                _context.Remove(FuncionarioSelecionado);
                _context.SaveChanges();
                serviceResponse.dados = _context.Funcionarios.ToList();
                return serviceResponse;
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;

        }

        public async Task<ServiceResponse<FuncionarioModel>> GetFuncionarioByID(int Id)
        {
            ServiceResponse<FuncionarioModel> serviceResponse = new ServiceResponse<FuncionarioModel>();

            try
            {
                FuncionarioModel funcionarioId = await _context.Funcionarios.FirstOrDefaultAsync(x => x.Id == Id);

                if(funcionarioId == null)
                {
                    serviceResponse.dados = null;
                    serviceResponse.Mensagem = "Usuario nao localizado";
                    serviceResponse.Sucesso = false;
                }
                serviceResponse.dados = funcionarioId;
                return serviceResponse;
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;

        }

        public async Task<ServiceResponse<List<FuncionarioModel>>> GetFuncionarios()
        { 
            ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();
            try
            {
                serviceResponse.dados =  _context.Funcionarios.ToList();
                if (serviceResponse.dados.Count == 0)
                {
                    serviceResponse.Mensagem = "Nenhum dado encontrado";
                }
                return serviceResponse;
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;


        }

        public async Task<ServiceResponse<List<FuncionarioModel>>> InativaFuncionario(int Id)
        {
            ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();
            try
            {
                FuncionarioModel funcionarioAlterado = _context.Funcionarios.FirstOrDefault(x => x.Id == Id);
                if(funcionarioAlterado == null)
                {
                    serviceResponse.dados = null;
                    serviceResponse.Mensagem = "Usuario nao localizado";
                    serviceResponse.Sucesso = false;
                }
                funcionarioAlterado.Ativo = false;
                funcionarioAlterado.DataDeAtualizacao = DateTime.Now.ToLocalTime();
                _context.Funcionarios.Update(funcionarioAlterado);
                _context.SaveChanges();
                serviceResponse.dados = _context.Funcionarios.ToList();
                return serviceResponse;
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
           

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<FuncionarioModel>>> UpdateFuncionario(FuncionarioModel FuncionarioEditado)
        {
            ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();
            try
            {
                var FuncionarioPesquisado = _context.Funcionarios.AsNoTracking().FirstOrDefault(x => x.Id == FuncionarioEditado.Id);
                if (FuncionarioEditado == null)
                {
                    serviceResponse.dados = null;
                    serviceResponse.Mensagem = "Informe os dados corretamente";
                    serviceResponse.Sucesso = false;
                }
                FuncionarioEditado.DataDeAtualizacao = DateTime.Now.ToLocalTime();
                _context.Update(FuncionarioEditado);
                _context.SaveChanges();
                serviceResponse.dados = _context.Funcionarios.ToList();
                return serviceResponse;

            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }
    }
}
