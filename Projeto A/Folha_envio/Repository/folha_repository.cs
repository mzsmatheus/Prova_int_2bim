using ProjetoA.Models;
using System.Collections.Generic;

namespace ProjetoA.Repository
{
    public class FolhaRepository
    {
        private readonly List<Folha> folhas = new List<Folha>();

        public List<Folha> Cadastrar(Folha folha)
        {
            folhas.Add(folha);
            return folhas;
        }

        public List<Folha> Listar()
        {
            return folhas;
        }
    }
}
