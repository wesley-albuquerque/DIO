using System;
using System.Collections.Generic;
using Series;

namespace Series
{
    public class SerieRepositorio : IRepositorio<Serie>
    {
        private List<Serie> listaSerie = new List<Serie>();
		public void Atualiza(int id, Serie itemSerie)
		{
			listaSerie[id] = itemSerie;
		}

		public void Exclui(int id)
		{
			listaSerie[id].Excluir();
		}

		public void Insere(Serie itemSerie)
		{
			listaSerie.Add(itemSerie);
		}

		public List<Serie> Lista()
		{
			return listaSerie;
		}

		public int ProximoId()
		{
			return listaSerie.Count;
		}

		public Serie RetornaPorId(int id)
		{
			return listaSerie[id];
		}
    }
}