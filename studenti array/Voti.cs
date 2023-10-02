using System;

namespace Esercizio_Studenti
{
	public class Voti
	{
		private Voto[] elencoVoti;
		private short votiCounter;

		public Voti(int tot = 20)
		{
			elencoVoti = new Voto[tot];
			votiCounter = 0;
		}

		public Voto this[int index]
		{
			get
			{
				if(index >= 0 && index < votiCounter)
					return elencoVoti[index];
				throw new IndexOutOfRangeException("L'indice specificato non è valido.");
			}
			set
			{
				if(index >= 0 && index < votiCounter)
					elencoVoti[index] = value;
				else
					throw new IndexOutOfRangeException("L'indice specificato non è valido.");
			}
		}

		public Voto[] GetElenco() { return elencoVoti; }

		private static int GetLength(int tot)
		{
			if(tot < 20) return 20;
			return tot/20 * 20 + 20;
		}

		private static void Resize(ref Voto[] array, int newSize)
		{
			if(array.Length != newSize)
			{
				Voto[] array2 = new Voto[newSize];
				if(array.Length < newSize) //se newsize è più grande, copia fino ad array.length e il resto rimane default
					for(int i = 0; i < array.Length; i++)
						array2[i] = array[i];
				else //se newsize è più piccolo copia fino a newsize
					for(int i = 0; i < newSize; i++)
						array2[i] = array[i];
				array = array2;
			}
		}

		public void AggiungiVoto(Voto voto)
		{
			if(votiCounter < elencoVoti.Length)
			{
				elencoVoti[votiCounter] = voto;
				votiCounter++;
			}
			else
			{
				//throw new InvalidOperationException("L'elenco dei voti è pieno.");
				//resize
				Resize(ref elencoVoti, GetLength(votiCounter));
				AggiungiVoto(voto);
			}
		}

		public float CalcolaMediaMateria(string materia)
		{
			if(votiCounter == 0)
				return 0;

			float somma = 0;
			short numVoti = 0;
			foreach(Voto voto in elencoVoti)
			{
				if(voto != null && voto.Materia.ToLower() == materia.ToLower())
				{
					somma += voto.Valore;
					numVoti++;
				}
			}

			if(numVoti == 0)
				return 0;

			return somma / numVoti;
		}

		public float CalcolaMediaTotale()
		{
			if(votiCounter == 0)
				return 0;

			float somma = 0;
			foreach(Voto voto in elencoVoti)
			{
				if(voto != null)
				{
					somma += voto.Valore;
				}
			}

			return somma / votiCounter;
		}

	}
}
