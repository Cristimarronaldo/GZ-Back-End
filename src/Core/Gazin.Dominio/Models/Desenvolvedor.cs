namespace Gazin.Dominio.Models
{
    public class Desenvolvedor
    {
        public Desenvolvedor(int id, int nivelId, string nome, char sexo, DateTime dataNascimento,
                             int idade, string hobby)
        {
            Id = id;
            NivelId = nivelId;
            Nome = nome.Trim();
            Sexo = sexo;
            DataNascimento = dataNascimento;
            Idade = idade;
            Hobby = hobby;
        }

        //E.F
        protected Desenvolvedor(){}

        public Niveis Niveis { get; private set; }

        public int Id { get; private set; }
        public int NivelId { get; private set; }
        public string Nome { get; private set; }
        public char Sexo { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public int Idade { get; private set; }
        public string Hobby { get; private set; }

        public void AtualizarIdade(int idade) => Idade = idade;
    }
}
