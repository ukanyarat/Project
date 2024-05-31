using Chapter09;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
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
    /// Interaction logic for Withdraw.xaml
    /// </summary>
    public partial class Withdraw : Window
    {

        

        private _02Game game;
        FileManagement file2 = new FileManagement("D:/000000/Project/Project/game.txt");
        private List<string> texts = new List<string>();

        FileManagement file1 = new FileManagement("D:/000000/Project/Project/member.txt");
        public Withdraw()
        {
            InitializeComponent();
            LoadGameData();
        }
        private void LoadGameData()
        {
            game = new _02Game();
            game.ReadFileGamee();

            // อัปเดต Label ด้วยยอดเงินคงเหลือ
            lbCurrent.Content = $"{game.Balance:C}";
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
                file2.WriteFile("game.txt",texts);

            }

        }


        private bool AuthenticateUser(string username, string password)
        {
            List<string> registrationData = file1.ReadFile();
            foreach (string data in registrationData)
            {
                string[] userData = data.Split(',');
                if (userData[2] == username && userData[3] == password)
                {
                    return true; // ข้อมูลผู้ใช้ถูกต้อง
                }
            }
            return false; // ไม่พบข้อมูลผู้ใช้
        }
        private void btnWithdraw_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUserName.Text;
            string password = txtPassword.Password;


            if (AuthenticateUser(username, password))
            {
                string[] lines = file2.ReadAllLines("game.txt");
                string moneyWithdraw = txtWithdraw.Text.ToString();


               

                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 3)
                    {
                        int a = Convert.ToInt32(parts[0]);
                        int b = Convert.ToInt32(moneyWithdraw);
                        int sum = a - b;


                        if (b < a)
                        {
                            decimal balance = sum;
                            int win = int.Parse(parts[1]);
                            int card = int.Parse(parts[2]);

                            _02Game member = new _02Game(balance, win, card);
                            string text = member.newData();

                            texts.Add(text);
                            file2.WriteFile("game.txt", texts);

                            string show = $"\nuser : {txtUserName.Text}\n\naccountNumber : {txtAccount.Text}\namount : {balance} Bath";
                            MessageBox.Show(show, "Confirm", MessageBoxButton.OK);

                            this.Hide();
                            Start start = new Start();
                            start.Show();

                        }
                        else {
                            MessageBox.Show("Your balance is insufficient for withdrawal.", "Not enough money", MessageBoxButton.OK,MessageBoxImage.Error);
                            txtWithdraw.Text = "";
                            txtAccount.Text = "";
                            txtUserName.Text = "";
                            txtPassword.Password = "";
                        }

                    }
                }
            }
            else
            {
                MessageBox.Show("Username or Password is incorrect. or You have not entered the amount or useraccount you want to deposit.", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                txtUserName.Text = "";
                txtPassword.Password = "";
            }

        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            YourScore score = new YourScore();
            score.Show();
        }
        
    }
}
