using Chapter09;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
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
    /// Interaction logic for AddMoney.xaml
    /// </summary>
    public partial class AddMoney : Window
    {
        private _02Game game;
        FileManagement file1 = new FileManagement("D:/000000/Project/Project/member.txt");
        FileManagement file2 = new FileManagement("D:/000000/Project/Project/game.txt");
        private List<string> texts = new List<string>();
        public AddMoney()
        {
            InitializeComponent();
            LoadGameData();


            addMoney.Items.Add("10");
            addMoney.Items.Add("20");
            addMoney.Items.Add("50");
            addMoney.Items.Add("100");
            addMoney.Items.Add("300");

        }

        private void LoadGameData()
        {
            game = new _02Game();
            game.ReadFileGamee();

            // อัปเดต Label ด้วยยอดเงินคงเหลือ
            lbCurrent.Content = $"{game.Balance:C}";
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Start start = new Start();
            start.Show();
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
        private void btnDeposit_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string password = PasswordBox.Password;


            if ((AuthenticateUser(username, password))&&(addMoney.SelectedItem != null)&&(txtAccount.Text != ""))
            {
                string[] lines = file2.ReadAllLines("game.txt");
                string moneyWithdraw = addMoney.SelectedItem.ToString();


                // วนลูปผ่านแต่ละบรรทัดในไฟล์ game.txt
                foreach (string line in lines)
                {
                    // แยกข้อมูลด้วยเครื่องหมาย ','
                    string[] parts = line.Split(',');

                    if (parts.Length == 3)
                    {
                        int a = Convert.ToInt32(parts[0]);
                        int b =Convert.ToInt32(moneyWithdraw);
                        int sum = a + b;

                        decimal balance = sum ;
                        int win = int.Parse(parts[1]);
                        int card = int.Parse(parts[2]);

                        _02Game member = new _02Game(balance, win, card);
                        string text = member.newData();

                        texts.Add(text);
                        file2.WriteFile("game.txt", texts);

                        // Show confirmation message
                        string show = $"\nUser : {txtUsername.Text}\n\nAccountNumber : {txtAccount.Text}\nTotal amount : {balance} Bath";
                        MessageBox.Show(show, "Confirm", MessageBoxButton.OK);

                        this.Hide();
                        Start start = new Start();
                        start.Show();

                    }
                }
                    }
                    else
                    {
                        MessageBox.Show("Username or Password is incorrect. or You have not entered the amount or useraccount you want to deposit.", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                        txtUsername.Text = "";
                        PasswordBox.Password = "";
                    }



                }

            }
        }