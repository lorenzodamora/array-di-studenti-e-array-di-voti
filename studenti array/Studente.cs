//using System;

namespace Esercizio_Studenti
{
	public class Studente
	{
		private string _nominativo;
		private int _età;

		/**
		 * <summary>
		 * Ottiene o imposta il nominativo (nome e cognome).
		 * </summary>
		 */
		public string Nominativo
		{
			get { return _nominativo; }
			set { SetNominativo(value); }
		}

		public int Età
		{
			get { return _età; }
			set { SetEtà(value); }
		}

		public Voti Voti { get; set; }

		//
		public Studente(string nominativo = "nessun nominativo", int età = 0)
		{
			if(!SetStudente(nominativo, età))
			{
				Nominativo = "inserimento non valido, [throw]";
				Età = 0;
			}
			Voti = new Voti();
		}

		public Studente(string nominativo, string età_stringa)
		{
			if(!SetStudente(nominativo, età_stringa))
			{
				Nominativo = "inserimento non valido, [throw]";
				Età = 0;
			}
			Voti = new Voti();
		}

		//
		public bool SetNominativo(string nominativo)
		{
			if(string.IsNullOrEmpty(nominativo)) return false;
			_nominativo = nominativo;
			return true;
		}

		public bool SetEtà(int età)
		{
			if(età < 0) return false;
			_età = età;
			return true;
		}

		public bool SetEtà(string età_stringa)
		{
			if(int.TryParse(età_stringa, out int età) || età < 0)
			{
				_età = età;
				return true;
			}
			else
				return false;
		}

		public bool SetStudente(string nominativo, int età)
		{
			return SetNominativo(nominativo) & SetEtà(età);
		}

		public bool SetStudente(string nominativo, string età_stringa)
		{
			return SetNominativo(nominativo) & SetEtà(età_stringa);
		}

		//
		public void AggiungiVoto(Voto voto)
		{
			Voti.AggiungiVoto(voto);
		}

		public float MediaTotale()
		{
			return Voti.CalcolaMediaTotale();
		}

		public float MediaMateria(string materia)
		{
			return Voti.CalcolaMediaMateria(materia);
		}

	}
}
