using System;
namespace projetoCrud.ViewModels
{
	public class AlunoCreateViewModel
	{
        public int Matricula { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
    }
}

