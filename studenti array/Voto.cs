using System;

namespace Esercizio_Studenti
{
	public class Voto
	{
		private float _valore;
		private string _materia;

		public float Valore
		{
			get { return _valore; } 
			set { SetValore(value); }
		}

		public string Materia
		{
			get { return _materia; }
			set { SetMateria(value); }
		}

		public Voto(float valore, string materia)
		{
			if(!SetVoto(valore, materia))
			{
				throw new ArgumentException("Il voto deve essere compreso tra 1 e 10; e la materia non deve essere vuota");
			}
		}

		public Voto(string valore_stringa, string materia)
		{
			if(!SetVoto(valore_stringa, materia))
			{
				throw new ArgumentException("Il voto deve essere compreso tra 1 e 10; e la materia non deve essere vuota");
			}
		}

		public bool SetValore(float valore)
		{
			if(valore < 1.0f || valore > 10.0f) return false;
			_valore = valore;
			return true;
		}

		public bool SetValore(string valore_stringa)
		{
			if(float.TryParse(valore_stringa, out float valore) || valore < 1.0f || valore > 10.0f)
			{
				_valore = valore;
				return true;
			}
			else
				return false;
		}

		public bool SetMateria(string materia)
		{
			if(string.IsNullOrEmpty(materia)) return false;
			_materia = materia;
			return true;
		}

		public bool SetVoto(float valore, string materia)
		{
			return SetValore(valore) & SetMateria(materia);
		}

		public bool SetVoto(string valore_string, string materia)
		{
			return SetValore(valore_string) & SetMateria(materia);
		}

	}
}
