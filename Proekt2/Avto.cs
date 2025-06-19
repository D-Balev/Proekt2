using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proekt2
{
    public class Avto
    {
        private string regnomer;
        public string Regnomer
        {
            get
            {
                return regnomer;
            }
            set
            {
                if (value.Length == 8)
                {
                    regnomer = value;
                }
                else
                {
                    Console.WriteLine("Номера е невалиден.");
                    return;
                }
            }
        }
        private string enginumber;
        public string Enginumber
        {
            get
            {
                return enginumber;
            }
            set
            {
                enginumber = value;
            }
        }
        private string marka;
        public string Marka
        {
            get
            {
                return marka;
            }
            set
            {
                marka = value;
            }
        }
        private string model;
        public string Model
        {
            get
            {
                return model;
            }
            set
            {
                model = value;
            }
        }
        private int godina;
        public int Godina
        {
            get
            {
                return godina;
            }
            set
            {
                if (value > 1885 && value <= 2025)
                {
                    godina = value;
                }
                else
                {
                    Console.WriteLine("Годината е невалидна.");
                    return;
                }
            }
        }
        private double cena;
        public double Cena
        {
            get
            {
                return cena;
            }
            set
            {
                cena = value;
            }
        }
        public Avto(string regnomer, string enginumber, string marka, string model, int godina, double cena)
        {
            Regnomer = regnomer;
            Enginumber = enginumber;
            Marka = marka;
            Model = model;
            Godina = godina;
            Cena = cena;
        }
        public Avto()
        {
            Regnomer = "00000000";
            Enginumber = "0000000000";
            Marka = "Неизвестна";
            Model = "Неизвестен";
            Godina = 2000;
            Cena = 0;
        }
        public void PrintInfo()
        {
            Console.WriteLine($"Регистрационен номер: {Regnomer}, Двигателен номер: {Enginumber}, Марка: {Marka}, Модел: {Model}, Година: {Godina}, Цена: {Cena}");
        }
    }
}
