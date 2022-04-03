namespace Gazin.Dominio.Models
{
    public class Niveis
    {
        public Niveis(int id, string nivel)
        {
            Id = id;
            Nivel = nivel.Trim();
        }

        //E.F
        protected Niveis() { }

        //Relacionamento E.F
        public IEnumerable<Desenvolvedor> Desenvolvedor { get; set; }

        public int Id { get; private set; }
        public string Nivel { get; private set; }
    }
}
