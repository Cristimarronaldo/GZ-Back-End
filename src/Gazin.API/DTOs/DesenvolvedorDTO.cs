namespace Gazin.API.DTOs
{
    public class DesenvolvedorDTO
    {
        public int Id { get; set; }
        public int NivelId { get; set; }
        public string Nome { get; set; }
        public char Sexo { get; set; }
        public DateTime DataNascimento { get; set; }
        public int Idade { get; set; } = 0;
        public string? Hobby { get; set; }

        public string? Nivel { get; set; }
    }
}
