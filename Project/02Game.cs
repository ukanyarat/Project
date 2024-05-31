using Chapter09;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Xml.Linq;

namespace Project
{
    internal class _02Game 
    {
        public decimal balance;
        public int win ;
        public int card;

        private List<string> texts = new List<string>();
        FileManagement filegame = new FileManagement("D:/000000/Project/Project/game.txt");

        public _02Game(decimal balance ,int win , int card) {
            this.balance = balance;
            this.win = win;
            this.card = card;
        }
        public _02Game() { }
         public _02Game ReadFileGamee()
        {

            string[] lines = filegame.ReadAllLines("game.txt");

            foreach (string line in lines)
            {
                string[] parts = line.Split(',');

                if (parts.Length == 3)
                {
                    balance = decimal.Parse(parts[0]);
                    win = int.Parse(parts[1]);
                    card = int.Parse(parts[2]);
                }
            }
            return null;
        }

        public decimal Balance
        {
            get { return balance; }
            set { balance = value; }
        }
        public int Win
        {
            get { return win; }
            set { win = value; }
        }
        public int Card
        {
            get { return card; }
            set { card = value; }
        }

        public string newData()
        {
            return $"{balance},{win},{card}";
        }
    }
}
