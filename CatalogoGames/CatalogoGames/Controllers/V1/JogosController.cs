using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CatalogoGames.InputModel;
using CatalogoGames.ViewModel;
using CatalogoGames.Servico;
using System.ComponentModel.DataAnnotations;
using CatalogoGames.Excecoes;

namespace CatalogoGames.Controllers.V1
{
    [Route("api/V1/[controller]")]
    [ApiController]
    public class JogosController : ControllerBase
    {
        private readonly ServicoJogo _servicoJogo;

        public JogosController(ServicoJogo servicoJogo)
        {
            _servicoJogo = servicoJogo;
        }

       

        [HttpGet]
        public async Task<ActionResult<IEnumerable<JogoViewModel>>> Obter([FromQuery, Range(1, int.MaxValue)] int pagina = 1, [FromQuery, Range(1, 50)] int quantidade = 5)
        {
            var jogos = await _servicoJogo.Obter(pagina, quantidade);

            if (jogos.Count() == 0)
                return NoContent();

            return Ok(jogos);
        }


        [HttpGet("{idJogo:guid}")]
        public async Task<ActionResult<JogoViewModel>> Obter([FromRoute] Guid idJogo)
        {
            var jogo = await _servicoJogo.Obter(idJogo);

            if (jogo == null)
                return NoContent();

            return Ok(jogo);
        }

        

        [HttpPost]
        public async Task<ActionResult<JogoViewModel>> InserirJogo([FromBody] JogoInputModel jogoInputModel)
        {
            try
            {
                var jogo = await _servicoJogo.Inserir(jogoInputModel);

                return Ok(jogo);
            }
            catch (JogoJaCadastrado ex)
            {
                return UnprocessableEntity("Já existe um jogo com este nome para esta produtora");
            }
        }

        
        [HttpPut("{idJogo:guid}")]
        public async Task<ActionResult> AtualizarJogo([FromRoute] Guid idJogo, [FromBody] JogoInputModel jogoInputModel)
        {
            try
            {
                await _servicoJogo.Atualizar(idJogo, jogoInputModel);

                return Ok();
            }
            catch (JogoNaoCadastrado ex)
            {
                return NotFound("Não existe este jogo");
            }
        }

        [HttpPatch("{idJogo:guid}/preco/{preco:double}")]
        public async Task<ActionResult> AtualizarJogo([FromRoute] Guid idJogo, [FromRoute] double preco)
        {
            try
            {
                await _servicoJogo.Atualizar(idJogo, preco);

                return Ok();
            }
            catch (JogoNaoCadastrado ex)
            {
                return NotFound("Não existe este jogo");
            }
        }


        [HttpDelete("{idJogo:guid}")]
        public async Task<ActionResult> ApagarJogo([FromRoute] Guid idJogo)
        {
            try
            {
                await _servicoJogo.Remover(idJogo);

                return Ok();
            }
            catch (JogoNaoCadastrado ex)
            {
                return NotFound("Não existe este jogo");
            }
        }

    }
}
