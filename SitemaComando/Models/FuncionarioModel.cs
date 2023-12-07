using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Linq;
namespace SitemaComando.Models
{
    public class FuncionarioModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o Nome do Funcionario!")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Digite o E-mail do Funcionario!")]
        [EmailAddress(ErrorMessage = "o E-mail informado não e valido!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Digite a pontuação do Funcionario!")]
        public string Pontuacao { get; set; }
       
public class FuncionarioService
    {
        private List<FuncionarioModel> funcionarios;

        public FuncionarioService()
        {
            // Inicialize a lista de funcionários aqui
            funcionarios = new List<FuncionarioModel>();
        }

        public FuncionarioModel ObterFuncionarioComMaiorPontuacao()
        {
            return funcionarios.OrderByDescending(f => int.Parse(f.Pontuacao)).FirstOrDefault();
        }
    }
}
}
