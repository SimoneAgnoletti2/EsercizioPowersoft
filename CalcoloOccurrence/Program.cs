using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CalcoloOccurrence
{
    public class Program
    {
        public static async Task Main()
        {
            var execute = true;
            do
            {
                try
                {
                    Console.Clear();

                    var doubleCount1 = 0;
                    var tripleCount1 = 0;

                    var doubleCount2 = 0;
                    var tripleCount2 = 0;

                    Console.Write("Inserisci il percorso del file .txt: ");
                    var path = Console.ReadLine();
                    var cleanPath = path.Replace("\"", "");
                    if (File.Exists(cleanPath))
                    {
                        Console.WriteLine("File trovato.\n");
                        await Task.Delay(1000);
                        Console.WriteLine("Il primo risultato ritornerà: la somma del totale dei caratteri che compaiono 2 volte " +
                            "in ogni riga moltiplicato per la somma dei caratteri che compaiono 3 volte in ogni riga.\n");
                        var lines = File.ReadAllLines(cleanPath);
                        foreach (var line in lines)
                        {
                            var dictionary = new Dictionary<char, int>();
                            foreach (var actualChar in line)
                            {
                                if (dictionary.ContainsKey(actualChar))
                                    dictionary[actualChar]++;
                                else
                                    dictionary[actualChar] = 1;
                            }
                            if (dictionary.Any(x => x.Value == 2))
                            {
                                doubleCount1 += dictionary.Count(x => x.Value == 2);
                                doubleCount2++;
                            }
                            if (dictionary.Any(x => x.Value == 3))
                            {
                                tripleCount1 += dictionary.Count(x => x.Value == 3);
                                tripleCount2++;
                            }
                        }
                        Console.WriteLine($"Primo risultato: {doubleCount1 * tripleCount1}\n\n");

                        await Task.Delay(1000);
                        Console.WriteLine("Il secondo risultato ritornerà: la moltiplicazione del numero di righe in cui compaiono " +
                            "2 caratteri uguali per il numero di righe in cui compaiono 3 caratteri uguali.\n");

                        Console.WriteLine($"Secondo risultato: {doubleCount2 * tripleCount2}\n\n");
                    }
                    else
                    {
                        Console.WriteLine("File non esistente\n\n");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Eccezione: {ex.Message}\n\n");
                    Console.ReadLine();
                }
                finally
                {
                    Console.WriteLine("Per elaborare un altro file premere il tasto s/S, altrimenti premere un tasto qualunque per uscire");
                    execute = Console.ReadLine().ToLower() == "s" ? true : false;
                }
            } while (execute == true);
        }
    }
}
