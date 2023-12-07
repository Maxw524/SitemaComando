    using SitemaComando.Data;
    using SitemaComando.Models;
    using Microsoft.EntityFrameworkCore;

namespace SitemaComando.Repositorio
    {
        public class FuncionarioRepositorio :IFuncionarioRepositorio
        {
            private readonly BancoContext _bancoContext;

            public FuncionarioRepositorio(BancoContext bancoContext)
            {

                this._bancoContext = bancoContext;
            }


            public FuncionarioModel ListarPorId(int id)
            {
                return _bancoContext.Funcionario.FirstOrDefault(x => x.Id == id);
            }

            public FuncionarioModel Adicionar(FuncionarioModel funcionario)
            {
                _bancoContext.Funcionario.Add(funcionario);
                _bancoContext.SaveChanges();
                return funcionario;
            }

            public FuncionarioModel Atualizar(FuncionarioModel Funcionario)
            {
                FuncionarioModel FuncionarioDB = ListarPorId(Funcionario.Id);

                if (FuncionarioDB == null) throw new SystemException("Houve um erro na atualização do Funcionario!");

                FuncionarioDB.Nome = Funcionario.Nome;
                FuncionarioDB.Email = Funcionario.Email;
                FuncionarioDB.Pontuacao = Funcionario.Pontuacao;

                _bancoContext.Funcionario.Update(FuncionarioDB);
                _bancoContext.SaveChanges();

                return FuncionarioDB;
            }

            public bool Apagar(int id)
            {
                FuncionarioModel FuncionarioDB = ListarPorId(id);

                if (FuncionarioDB == null) throw new SystemException("Erro na deleção do Funcionario!");
                _bancoContext.Funcionario.Remove(FuncionarioDB);
                _bancoContext.SaveChanges();

                return true;
            }

        List<FuncionarioModel> IFuncionarioRepositorio.BuscarTodos()
        {
         return _bancoContext.Funcionario.ToList();
        }
    }
    }
