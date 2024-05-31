using Chapter09;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
using static System.Net.WebRequestMethods;

namespace Project
{
    /// <summary>
    /// Interaction logic for Start.xaml
    /// </summary>
    public partial class Start : Window
    {

        FileManagement file2 = new FileManagement("D:/000000/Project/Project/game.txt");
        private List<string> texts = new List<string>();
        private _02Game game;
        public Start()
        {
            InitializeComponent();
            LoadGameData();
        }
        private void LoadGameData()
        {
            game = new _02Game();
            game.ReadFileGamee(); 

            lbBalance.Content = $"The prize money you received {game.Balance:C}";
        }

        private void btnStrat_Click(object sender, RoutedEventArgs e)
        {
            string[] lines = file2.ReadAllLines("game.txt");
            

            // วนลูปผ่านแต่ละบรรทัดในไฟล์ game.txt
            foreach (string line in lines)
            {
                // แยกข้อมูลด้วยเครื่องหมาย ','
                string[] parts = line.Split(',');

                if (parts.Length == 3)
                {
                    if (decimal.Parse(parts[0].ToString()) >= 10) {
                        // เช็คว่าเราอยู่ที่อาร์เรย์ที่ 2 หรือไม่
                       
                            // แปลงข้อมูลในอาร์เรย์ที่ 2 เป็นตัวเลขแล้วบวกด้วย 10
                            decimal balance = decimal.Parse(parts[0]) - 10;
                            int win = int.Parse(parts[1]);
                            int card = int.Parse(parts[2]);
                            // สร้างข้อมูลใหม่ที่มีค่าใหม่แล้วเขียนลงใน List

                            _02Game member = new _02Game(balance, win, card);
                            string text = member.newData();


                            texts.Add(text);
                            file2.WriteFile("game.txt", texts);

                            this.Close();
                            Select select = new Select();
                            select.Show();

                    }
                    else
                    {
                        MessageBox.Show("Your money is not enough Please top up.", "not enough money", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                
            }
        }
        private void btnRules_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Rules rules = new Rules();
            rules.Show();
        }

        private void btnAddMoney_Click(object sender, RoutedEventArgs e)
        {
            this.Close();   
            AddMoney addMoney = new AddMoney();
            addMoney.Show();
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
