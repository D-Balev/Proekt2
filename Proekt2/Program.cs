using System;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;

namespace Proekt2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Avto> avto1 = new List<Avto>();
            List<Buyer> buyers = new List<Buyer>();
            List<Avto> pocena = new List<Avto>();
            Console.Write("Колко данни за коли ще въвеждаш  = ");
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"[{i + 1}]. Въведи данните за колата = рег.номер, номер на двигателя, марката, модела, цената и годината = ");
                string[] input = Console.ReadLine().Split(' ');
                string regnomer = input[0];
                string enginumber = input[1];
                string marka = input[2];
                string model = input[3];
                double cena = double.Parse(input[4]);
                int godina = int.Parse(input[5]);

                Avto avto = new Avto(regnomer, enginumber, marka, model, godina, cena);
                avto1.Add(avto);
            }
            Console.WriteLine("------------------------------");
            for (int i = 0; i < n; i++)
            {
                avto1[i].PrintInfo();
            }
            Console.WriteLine("------------------------------");

            Console.Write("Колко данни за купувачи ще въвеждаш = ");
            int m = int.Parse(Console.ReadLine());
            for (int i = 0; i < m; i++)
            {
                Console.WriteLine($"[{i}]. Въведи данните за купувачите: номер, име, фамилия, година на раждане и бюджет");
                string[] input2 = Console.ReadLine().Split(' ');
                string nomer = input2[0];
                string ime = input2[1];
                string familiq = input2[2];
                int rajdane = int.Parse(input2[3]);
                double budget = double.Parse(input2[4]);

                Buyer buyer = new Buyer(nomer, ime, familiq, rajdane, budget);
                buyers.Add(buyer);
            }
            Console.Write("Ще правиш ли справки на коли? (YES/NO) = ");
            string answer = Console.ReadLine().ToUpper();
            while (answer == "YES")
            {
                Console.Write("Въведи марката или модела на която искаш справка, ако искаш да спреш напиши NO = ");
                string search = Console.ReadLine();
                if (search == "NO")
                {
                    answer = "NO";
                }
                else
                {
                    SearchAvto(avto1, search);
                }
            }
            Console.WriteLine("------------------------------");
            Console.Write("Искаш да иправиш промяна върxy информацията за автомобилите? (YES/NO) = ");
            string action = Console.ReadLine().ToUpper();
            while (action == "YES")
            {

                Console.WriteLine("Искаш ли да изтриваш или да актуализираш информацията за автомобили (AC/DEL), ако искаш да спреш напиши NO = ");
                string dei = Console.ReadLine().ToUpper();
                if (dei == "NO")
                {
                    action = "NO";
                    break;
                }
                else if (dei == "AC")
                {
                    Console.Write("Въведи модела на автомобила който искаш да актуализираш = ");
                    string search = Console.ReadLine();
                    for (int i = 0; i < avto1.Count; i++)
                    {
                        if (avto1[i].Model == search)
                        {
                            Console.WriteLine("Въведи новите данни за автомобила: рег.номер, номер на двигателя, марка, модел, година и цена");
                            string[] input3 = Console.ReadLine().Split(' ');
                            avto1[i].Regnomer = input3[0];
                            avto1[i].Enginumber = input3[1];
                            avto1[i].Marka = input3[2];
                            avto1[i].Model = input3[3];
                            avto1[i].Godina = int.Parse(input3[4]);
                            avto1[i].Cena = double.Parse(input3[5]);
                            Console.WriteLine($"Автомобилът {search} е актуализиран.");
                        }
                    }
                }
                else if (dei == "DEL")
                {
                    Console.Write("Въведи модела на автомобила който искаш да изтриеш = ");
                    string search = Console.ReadLine();
                    DeleteAvto(avto1, search);
                }
            }
            Console.WriteLine("------------------------------");
            Console.Write("Искаш ли да изтриеш иформацията за автомобили? (YES/NO) = ");
            string action1 = Console.ReadLine().ToUpper();
            while (action1 == "YES")
            {
                Console.Write("Въведи марката на автомобила който искаш да изтриеш, ако искаш да спреш напиши NO = ");
                string search = Console.ReadLine();
                if (search == "NO")
                {
                    action1 = "NO";
                }
                else
                {
                    DeleteAvto(avto1, search);
                }
            }
            Console.WriteLine("------------------------------");
            Avgcars(avto1);
            Console.WriteLine("------------------------------");
            Minage(avto1);
            Console.WriteLine("------------------------------");
            Expensive(avto1);
            Console.WriteLine("------------------------------");
            Sorting(avto1, pocena, buyers);
            Console.WriteLine("Автомобилите, които са в бюджета на купувачите са:");
            for (int i =0; i < pocena.Count;i++)
            {
                pocena[i].PrintInfo();
            }
            Console.WriteLine("------------------------------");
        }
        static public void SearchAvto(List<Avto> avto1, string search)
        {
            Console.WriteLine("------------------------------");
            for (int i =0; i <avto1.Count;i++)
            {
                if (avto1[i].Marka == search || avto1[i].Model == search)
                {
                    avto1[i].PrintInfo();
                }
            }
            Console.WriteLine("------------------------------");
        }
        static public void DeleteAvto(List<Avto> avto1, string search)
        {
            for (int i = 0; i < avto1.Count; i++)
            {
                if (avto1[i].Model == search)
                {
                    avto1.RemoveAt(i);
                    Console.WriteLine($"Автомобилът с модел {search} е изтрит.");
                    return;
                }
            }
            Console.WriteLine($"Автомобилът с модел {search} не е намерен.");
        }
        static public void Avgcars(List<Avto> avto1)
        {
            double avgold = 0;
            for (int i = 0; i < avto1.Count; i++)
            {
                avgold += (2025 - avto1[i].Godina);
            }
            double avggod = avgold / avto1.Count;
            Console.WriteLine($"Средната възраст на автомобилите е: {avggod:f0} г.");
        }
        static public void Minage(List<Avto> avto1)
        {
            int index = 0;
            int max = 2025 - avto1[0].Godina; ;
            for (int i = 1; i < avto1.Count; i++)
            {
                int age = 2025 - avto1[i].Godina;
                if (age < max)
                {
                    max = age;
                    index = i;
                }
            }
            Console.WriteLine($"Най-новият автомобил е: {avto1[index].Marka} {avto1[index].Model}, година на производство: {avto1[index].Godina},рег.номер: {avto1[index].Regnomer}, номер на двигателя: {avto1[index].Enginumber} цена: {avto1[index].Cena} лв.");
        }
        static public void Expensive(List<Avto> avto1)
        {
            int index = 0;
            double money = 0;
            for (int i = 0; i < avto1.Count; i++)
            {
                if (avto1[i].Cena > money)
                {
                    money = avto1[i].Cena;
                    index = i;
                }
            }
            Console.WriteLine($"Най-скъпия автомобил е: {avto1[index].Marka} {avto1[index].Model}, година на производство: {avto1[index].Godina},рег.номер: {avto1[index].Regnomer}, номер на двигателя: {avto1[index].Enginumber} цена: {avto1[index].Cena} лв.");
        }
        static public void Sorting(List<Avto> avto1, List<Avto> pocena, List<Buyer> buyers)
        {
            for (int i = 0; i < avto1.Count ; i++)
            {
                for (int j = 0; j < buyers.Count; j++)
                {
                    if (buyers[j].Budget >= avto1[i].Cena)
                    {
                        pocena.Add(avto1[i]);
                    }
                }
                
            }
            for (int i = 0; i < pocena.Count - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < pocena.Count; j++)
                {
                    if (pocena[j].Cena < pocena[minIndex].Cena)
                    {
                        minIndex = j;
                    }
                }
                if (minIndex != i)
                {
                    Avto temp = pocena[i];
                    pocena[i] = pocena[minIndex];
                    pocena[minIndex] = temp;
                }
            }
        }
    }
}
