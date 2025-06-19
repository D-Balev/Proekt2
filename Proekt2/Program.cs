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
            Console.Write("Ще правиш ли справки на коли? (Y/N) = ");
            string answer = Console.ReadLine().ToUpper();
            while (answer == "Y")
            {
                Console.Write("Въведи марката или модела на която искаш справка = ");
                string search = Console.ReadLine();
                if (search == "N")
                {
                    answer = "N";
                }
                else
                {
                    SearchAvto(avto1, search);
                }
            }
            //Console.WriteLine("Искаш да изтриваш или да актуализираш информацията за автомобили (AC/DEL) = ");
            //string action = Console.ReadLine().ToUpper();
            Console.Write("Искаш ли да изтриеш иформацията за афтомобили? (YES/NO) = ");
            string action1 = Console.ReadLine().ToUpper();
            while (action1 == "YES")
            {
                Console.Write("Въведи марката на автомобила който искаш да изтриеш = ");
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
                if (avto1[i].Marka == search || avto1[i].Model == search)
                {
                    avto1.RemoveAt(i);
                    Console.WriteLine($"Автомобилът с марка {search} е изтрит.");
                    return;
                }
            }
            Console.WriteLine($"Автомобилът с марка {search} не е намерен.");
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
            pocena.Sort((a, b) => a.Cena.CompareTo(b.Cena));
        }
    }
}
