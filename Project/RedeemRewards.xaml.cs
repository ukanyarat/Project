using Chapter09;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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
    /// Interaction logic for RedeemRewards.xaml
    /// </summary>
    public partial class RedeemRewards : Window
    {

        private List<_04Reward> card = new List<_04Reward>();

        FileManagement file = new FileManagement("D:/000000/Project/Project/details_card.txt");
        FileManagement file2 = new FileManagement("D:/000000/Project/Project/game.txt");
        private List<string> texts = new List<string>();
        private _02Game game;


        public RedeemRewards()
        {
            InitializeComponent();
            LoadGameData();

        }

        private void LoadGameData()
        {
            game = new _02Game();
            game.ReadFileGamee();

            // อัปเดต Label ด้วยยอดเงินคงเหลือ
            string[] lines = file2.ReadAllLines("game.txt");
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                decimal balance = decimal.Parse(parts[0]);
                int win = int.Parse(parts[1]);
                int card = int.Parse(parts[2]);

                _02Game member = new _02Game(balance, win, card);
                string text = member.newData();
                texts.Add(text);
                
                if (card == 1)
                {
                    ImageShow.Source = new BitmapImage(new Uri("D:/000000/Project/Project/image/card001.jpg"));
                }
                else if (card == 2)
                {
                    ImageShow.Source = new BitmapImage(new Uri("D:/000000/Project/Project/image/card002.jpg"));

                }
                else if (card == 3)
                {
                    ImageShow.Source = new BitmapImage(new Uri("D:/000000/Project/Project/image/card003.jpg"));

                }
                else if (card == 4)
                {
                    ImageShow.Source = new BitmapImage(new Uri("D:/000000/Project/Project/image/card004.jpg"));

                }
                else if (card == 5)
                {
                    ImageShow.Source = new BitmapImage(new Uri("D:/000000/Project/Project/image/card005.jpg"));

                }

            }

        }


    private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            YourScore score = new YourScore();
            score.Show();
        }

        private void btnWithdraw_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Withdraw withdraw = new Withdraw();
            withdraw.Show();
        }
    }
}
