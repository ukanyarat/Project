using Chapter09;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
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
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace Project
{
    /// <summary>
    /// Interaction logic for YourScore.xaml
    /// </summary>
    public partial class YourScore : Window
    {

        FileManagement file2 = new FileManagement("D:/000000/Project/Project/game.txt");
        private List<string> texts = new List<string>();


        private _02Game game;
        public YourScore()
        {
            InitializeComponent();
            LoadGameData();


        }
        private void LoadGameData()
        {
            game = new _02Game();
            game.ReadFileGamee();

            //ImageShow.Source = new BitmapImage(new Uri("D:/000000/Project/Project/image/card02.jpg"));

            lbWinner.Content = $"{game.Win}";
           

            string[] lines = file2.ReadAllLines("game.txt");
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');

                int card = int.Parse(parts[2]);
                int win = int.Parse(parts[1]);

                if (card == 0)
                {
                    int valuecard0 = 0;
                    parts[0] = parts[0] + valuecard0;

                    lbValue.Content = " + 0 bath ";
                    ImageShow.Source = new BitmapImage(new Uri("D:/000000/Project/Project/image/card000.jpg"));
                    btnRewards.IsEnabled = false;
                }
                else if (card == 1)
                {
                    int valuecard1 = 500;
                    parts[0] = parts[0] + valuecard1;
                    lbValue.Content = " + 500 bath ";
                    ImageShow.Source = new BitmapImage(new Uri("D:/000000/Project/Project/image/card001.jpg"));
                }
                else if (card == 2)
                {
                    int valuecard2 = 1000;
                    parts[0] = parts[0] + valuecard2;
                    lbValue.Content = " + 1000 bath ";
                    ImageShow.Source = new BitmapImage(new Uri("D:/000000/Project/Project/image/card002.jpg"));
                }
                else if (card == 3)
                {
                    int valuecard3 = 2500;
                    parts[0] = parts[0] + valuecard3;
                    lbValue.Content = " + 2500 bath ";
                    ImageShow.Source = new BitmapImage(new Uri("D:/000000/Project/Project/image/card003.jpg"));
                }
                else if (card == 4)
                {
                    int valuecard4 = 7000;
                    parts[0] = parts[0] + valuecard4;
                    lbValue.Content = " + 7000 bath ";
                    ImageShow.Source = new BitmapImage(new Uri("D:/000000/Project/Project/image/card004.jpg"));
                }
                else if (card == 5)
                {
                    int valuecard5 = 20000;
                    parts[0] = parts[0] + valuecard5;
                    lbValue.Content = " + 20000 bath ";
                    ImageShow.Source = new BitmapImage(new Uri("D:/000000/Project/Project/image/card005.jpg"));
                }

                decimal balance = int.Parse(parts[0]);




                _02Game member = new _02Game(balance, win, card);
                string text = member.newData();

                texts.Add(text);
                file2.WriteFile("game.txt", texts);
                lbBalance.Content = $"{game.Balance:C}";
            }

        }

        private void btnPlayAgain_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Start start = new Start();
            start.Show();
        }

        private void btnRewards_Click(object sender, RoutedEventArgs e)
        {
            
                this.Close();
                RedeemRewards rewards = new RedeemRewards();
                rewards.Show();
            
            
        }

        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {
            string[] lines = file2.ReadAllLines("game.txt");
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');

                // แปลงข้อมูลในอาร์เรย์ที่ 2 เป็นตัวเลขแล้วบวกด้วย 10
                parts[0] = "100";
                decimal balance = decimal.Parse(parts[0]);
                parts[1] = "0";
                int win = int.Parse(parts[1]);
                parts[2] = "0";
                int card = int.Parse(parts[2]);
                // สร้างข้อมูลใหม่ที่มีค่าใหม่แล้วเขียนลงใน List

                _02Game member = new _02Game(balance, win, card);
                string text = member.newData();

                texts.Add(text);
                file2.WriteFile("game.txt", texts);
            }
        
            this.Close();
            MainWindow main = new MainWindow();
            main.Show();
        }
    }
}