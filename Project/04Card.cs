using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    internal class _04Reward
    {
        private string level;
        private string win;
        private string moneyvalue;
        private string namecard;
        private string image;

        public _04Reward()
        {
        }

        public _04Reward(string namecard ,string level, string win, string moneyvalue)
        {
            this.namecard = namecard;
            this.level = level;
            this.win = win;
            this.moneyvalue = moneyvalue;
        }

        public string Level
        {
            get { return level; }
            set { level = value; }
        }
        public string Win
        {
            get { return win; }
            set { win = value; }
        }
        public string Moneyvalue
        {
            get { return moneyvalue; }
            set { moneyvalue = value; }
        }
        public string Image
        {
            get { return image; }
            set { image = value; }
        }
        public string Namecard
        {
            get { return namecard; }
            set { namecard = value; }
        }
        public string MoneyValue
        {
            get { return moneyvalue; }
        }
        public string SetData()
        {
            return level + "," + win + "," + moneyvalue;
        }

    }
}
