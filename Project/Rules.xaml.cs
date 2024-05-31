using Chapter09;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Project
{
    /// <summary>
    /// Interaction logic for Rules.xaml
    /// </summary>
    /// 
    
    public partial class Rules : Window
    {
        private List<_04Reward> card = new List<_04Reward>();
        FileManagement file = new FileManagement("D:/000000/Project/Project/details_card.txt");
        private string imageFile = "image/";
        private int index = 0;
        public Rules()
        {
            InitializeComponent();

            card = new List<_04Reward>();
            foreach (string i in file.ReadFile())
            {
                if (i != "")
                {
                    string[] data = new string[4];
                    data = i.Split(',');
                    string level = data[0];
                    string win = data[1];
                    string moneyValue = data[2];
                    string image = data[3];
                    string namecard = data[4];
                    _04Reward p = new _04Reward(namecard,level, win, moneyValue);
                    p.Image = imageFile + image + ".jpg";
                    card.Add(p);
                }
            }
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(card[index].Image, UriKind.Relative);
            bitmap.EndInit();
            ImageShow.Source = bitmap;
            textDisplay.Text = "\n  Card name :  " + card[index].Namecard + "\n  Card level :  " + card[index].Level + "\n  The time to win :   "
                   + card[index].Win + "\n\nCard value :  " + card[index].MoneyValue + "\n";
        }

        private void btnNextCard_Click(object sender, RoutedEventArgs e)
        {
            if (index >= card.Count - 1)
            {
                index = 0;
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(card[index].Image, UriKind.Relative);
                bitmap.EndInit();
                ImageShow.Source = bitmap;
                textDisplay.Text = "\n  Card name :  " + card[index].Namecard + "\n  Card level :  " + card[index].Level + "\n  The time to win :   "
                   + card[index].Win + "\n\nCard value :  " + card[index].MoneyValue + "\n";
            }
            else
            {
                index++;
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(card[index].Image, UriKind.Relative);
                bitmap.EndInit();
                ImageShow.Source = bitmap;
                textDisplay.Text = "\n  Card name :  " + card[index].Namecard + "\n  Card level :  " + card[index].Level + "\n  The time to win :   "
                   + card[index].Win + "\n\nCard value :  " + card[index].MoneyValue + "\n";
            }
        }

        private void btnBackToGame_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Start start = new Start();  
            start.Show();
        }
    }
}
