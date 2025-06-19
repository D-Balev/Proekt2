using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proekt2
{
    public class Buyer
    {
        private string nomer;
        public string Nomer
        {
            get
            {
                return nomer;
            }
            set
            {
                nomer = value;
            }
        }
        private string ime;
        public string Ime
        {
            get
            {
                return ime;
            }
            set
            {
                ime = value;
            }
        }
        private string familiq;
        public string Familiq
        {
            get
            {
                return familiq;
            }
            set
            {
                familiq = value;
            }
        }
        private int rajdane;
        public int Rajdane
        {
            get
            {
                return rajdane;
            }
            set
            {
                rajdane = value;
            }
        }
        private double budget;
        public double Budget
        {
            get
            {
                return budget;
            }
            set
            {
                budget = value;
            }
        }
        public Buyer(string nomer, string ime, string familiq, int rajdane, double budget)
        {
            Nomer = nomer;
            Ime = ime;
            Familiq = familiq;
            Rajdane = rajdane;
            Budget = budget;
        }
        public Buyer()
        {
            Nomer = "unknown";
            Ime = "unknown";
            Familiq = "unknown";
            Rajdane = 0;
            Budget = 0;
        }
    }
}
