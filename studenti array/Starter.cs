using System;

namespace Esercizio_Studenti
{
	internal class Starter
	{
		/*
		 * Crea un'applicazione per gestire un array di (oggetti) studenti.
		 * Gli studenti avranno nomi, età e voti, e l'applicazione deve essere in grado di aggiungere studenti,
		 * calcolare la media dei voti e visualizzare l'elenco completo degli studenti.
		 */
		static void Main()
		{
			Console.WriteLine("Schermo intero? (f11)");
			Console.ReadKey();
			Console.Clear();
			Console.WriteLine("ho già riempito randomicamente con 40 studenti e 40 voti per studente\n");

			// Liste di cognomi e nomi e materie
			string[] cognomi =
			{
				"Rossi", "Bianchi", "Verdi", "Ferrari", "Esposito", "Ricci", "Romano", "Gallo",
				"Greco", "Conti", "Mancini", "Marino", "Santoro", "Ferrara", "Ferri", "Barbieri",
				"Silvestri", "Russo", "Colombo", "De Luca", "Serra", "Gatti", "Riva", "Caruso",
				"Moretti", "Testa", "Villa", "Marchetti", "Benedetti"
			};

			string[] nomi =
			{
				"Mario", "Luigi", "Anna", "Maria", "Giovanni", "Giuseppe", "Sofia", "Elena",
				"Antonio", "Francesca", "Marco", "Alessia", "Luca", "Lorenzo", "Simona", "Roberto",
				"Paola", "Emanuele", "Valentina", "Federico", "Fabio", "Laura", "Vittorio",
				"Riccardo", "Alessandro", "Elisa", "Stefano", "Giulia", "Sara"
			};

			string[] materie =
			{
				"Informatica", "Sistemi e Reti", "Religione", "Inglese", "Matematica",
				"TEP", "Italiano", "Storia", "Scienze Motorie", "Telecomunicazioni"
			};

			Studenti studenti = new Studenti(20);

			/*
			string cognome = cognomi[rnd.Next(cognomi.Length)];
			string nome = nomi[rnd.Next(cognomi.Length)];
			string nominativo = cognome + " " + nome;
			int età = rnd.Next(21+1);
			Studente st1 = new Studente(nominativo, età);
			st.AggiungiStudente(st1);
			*/
			for(int i = 0; i < 40; i++)
			{
				Random rnd = new Random(Environment.TickCount * (i+1));

				studenti.AggiungiStudente(new Studente(cognomi[rnd.Next(cognomi.Length)] + " " + nomi[rnd.Next(nomi.Length)], rnd.Next(21+1)));

				for(int v = 0; v < 40; v++)
				{
					/*
					float valore = rnd.Next(1, 10+1);
					string materia = materie[rnd.Next(materie.Length)];
					Voto voto = new Voto(valore, materia);
					studenti[i].AggiungiVoto(voto);
					*/
					//studenti[i].AggiungiVoto(new Voto(rnd.Next(1, 10+1), materie[rnd.Next(materie.Length)]));

					/*
					int valore; //il voto è al 15% sotto al 6
					if(rnd.Next(1,20+1) <= 3)
						valore = rnd.Next(1, 5+1);
					else
						valore = rnd.Next(6, 10+1);
					*/

					//il voto è al 20% sotto al 7
					//(1, 100 + 1) <= 20 == (1, 20 + 1) <= 4 == (1, 5 + 1) <=\== 1
					int valore = (rnd.Next(1, 5 + 1) == 1) ? rnd.Next(1, 6 + 1) : rnd.Next(7, 10 + 1);

					studenti[i].AggiungiVoto(new Voto(valore, materie[rnd.Next(materie.Length)]));
				}
			}

			studenti.OrdinaPerNominativi();

			Console.WriteLine("la media dei voti (di tutte le materie) di tutti gli studenti è: " + studenti.MediaTotale());
			Console.WriteLine("\nDi seguito l'elenco ordinato degli studenti (solo nominativi)\n");
			Console.WriteLine(string.Join("\n", studenti.GetNominativi()));

			Console.WriteLine("\n\nFINE\n");
			Console.ReadKey(true);
		}
	}
}
