using System;
using System.Collections.Generic;

namespace NaiveBayes
{
    public class Bayes
    {
        public List<string> extragere(List<List<string>> date, List<string> simptome)
        {
            List<string> clase = new List<string>();
            foreach (List<string> lista in date)
            {
                int aparitii = 0;
                foreach (string simptom in simptome)
                {
                    if (lista.Contains(simptom))
                        aparitii++;
                }
                if((float) aparitii / simptome.Count >= 0.33 && clase.Contains(lista[lista.Count - 1]) == false)
                    clase.Add(lista[lista.Count - 1]);

            }
            clase.ForEach(Console.WriteLine);

            return clase;
        }

        public float probabilitate_clasa(List<List<string>> date, string clasa)
        {
            float corecte = 0, totale = 0;
            totale = date.Count;
            foreach (List<string> lista in date)
                if (lista[lista.Count - 1] == clasa)
                    corecte++;
            return (float) corecte / totale;
        }

        public float calculare_probabilitate_conditionata(List<List<string>> date, string atribut, string clasa) {
            float corecte = 0, totale = 0;
            foreach (List<string> lista in date)
                if (lista[lista.Count - 1] == clasa)
                {
                    totale++;
                    if (lista.Contains(atribut))
                        corecte++;
                }
            return (float)corecte / totale;
        }

        public object Naive_Bayes(List<List<string>> date, List<string> simptome)
        {
            Dictionary<string, double> ponderi = new Dictionary<string, double>();
            List<string> clase = new List<string>();
            clase = extragere(date, simptome);

            foreach (string clasa in clase)
                ponderi[clasa] = 1;


            
            foreach (string clasa in clase)
            {
                foreach (string simptom in simptome)
                {
                    double p;
                    p = calculare_probabilitate_conditionata(date, simptom, clasa);
                    if (p == 0)
                        ponderi[clasa] = ponderi[clasa] * 0.7;
                    else
                        ponderi[clasa] = ponderi[clasa] * p;

                }

                
            }
            foreach (KeyValuePair<string, double> kvp in ponderi)
            {
                Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
            }
                return ponderi;
        }
    }
}
