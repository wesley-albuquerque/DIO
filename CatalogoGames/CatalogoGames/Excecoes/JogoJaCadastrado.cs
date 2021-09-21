using System;

namespace CatalogoGames.Excecoes
{
    public class JogoJaCadastrado : Exception
    {
        public JogoJaCadastrado()
            : base("Este já jogo está cadastrado")
        { }
    }
}
