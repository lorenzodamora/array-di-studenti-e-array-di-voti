//using System;

using System;

namespace Esercizio_Studenti
{
	public class Studenti
	{
		private Studente[] elencoStudenti;
		private short studentiCounter;

		public Studenti(int tot = 20)
		{
			elencoStudenti = new Studente[tot];
			studentiCounter = 0;
		}

		public Studente this[int index]
		{
			get
			{
				if(index >= 0 && index < studentiCounter)
					return elencoStudenti[index];
				throw new IndexOutOfRangeException("L'indice specificato non è valido.");
			}
			set
			{
				if(index >= 0 && index < studentiCounter)
					elencoStudenti[index] = value;
				else
					throw new IndexOutOfRangeException("L'indice specificato non è valido.");
			}
		}

		public Studente[] GetElenco() { return elencoStudenti; }

		private static int GetLength(int tot)
		{
			if(tot < 20) return 20;
			return tot/20 * 20 + 20;
		}

		private static void Resize(ref Studente[] array, int newSize)
		{
			if(array.Length != newSize)
			{
				Studente[] array2 = new Studente[newSize];
				if(array.Length < newSize) //se newsize è più grande, copia fino ad array.length e il resto rimane default
					for(int i = 0; i < array.Length; i++)
						array2[i] = array[i];
				else //se newsize è più piccolo copia fino a newsize
					for(int i = 0; i < newSize; i++)
						array2[i] = array[i];
				array = array2;
			}
		}

		public void AggiungiStudente(Studente studente)
		{
			if(studentiCounter < elencoStudenti.Length)
			{
				elencoStudenti[studentiCounter] = studente;
				studentiCounter++;
			}
			else
			{
				//throw new InvalidOperationException("L'elenco dei voti è pieno.");
				//resize
				Resize(ref elencoStudenti, GetLength(studentiCounter));
				AggiungiStudente(studente);
			}
		}

		/// <summary>
		/// non è ben gestito il caso in cui uno studente non ha voti
		/// </summary>
		public float MediaTotale()
		{
			if(studentiCounter == 0)
				return 0;

			float somma = 0;
			foreach(Studente studente in elencoStudenti)
			{
				if(studente != null)
				{
					somma += studente.MediaTotale();
				}
			}

			return somma / studentiCounter;
		}

		/// <summary>
		/// non è ben gestito il caso in cui uno studente non ha voti nella specifica materia
		/// </summary>
		public float CalcolaMediaMateria(string materia)
		{
			if(studentiCounter == 0)
				return 0;

			float somma = 0;
			foreach(Studente studente in elencoStudenti)
			{
				if(studente != null)
				{
					somma += studente.MediaMateria(materia);
				}
			}

			return somma / studentiCounter;
		}

		public string[] GetNominativi()
		{
			string[] result = new string[studentiCounter];
			for(int i = 0; i < studentiCounter; i++)
				result[i] = elencoStudenti[i].Nominativo;

			return result;
		}

		/// <summary>
		/// ordine alfabetico
		/// </summary>
		public void OrdinaPerNominativi()
		{
			StudentiSort.Quick(elencoStudenti, 0, studentiCounter - 1);
		}

	}
}
