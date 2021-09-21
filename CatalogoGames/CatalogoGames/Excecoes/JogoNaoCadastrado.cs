using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogoGames.Excecoes
{
    public class JogoNaoCadastrado : Exception
    {
        public JogoNaoCadastrado()
            : base("Este jogo não está cadastrado")
        { }
    }
}
