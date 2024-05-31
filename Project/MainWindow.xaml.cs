using Chapter09;
using System;
using System.Reflection.Metadata;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IUser
    {
        private string sexselect;
        private string name;
        private string surname;
        private string user;
        private string password;
        private string accountNumber;
        private string agee;
        private string money;
        private string win;
        private string ccard;
        private string confirmpassword;
        //------------------------------

        private List<_04Reward> card = new List<_04Reward>();
        FileManagement file = new FileManagement("D:/000000/Project/Project/details_card.txt");
        private List<_01User> member = new List<_01User>();
        FileManagement file1 = new FileManagement("D:/000000/Project/Project/member.txt");
        private List<string> texts = new List<string>();


        public MainWindow()
        {
            InitializeComponent();

            for (int i = 15; i <= 100; i++)
            {
                age.Items.Add(i);
            }

            selectSex.Items.Add("Male");
            selectSex.Items.Add("Female");
  
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            

            string username = txtUsername.Text;
            string password = txtPassword.Password;

            


            if (AuthenticateUser(username, password))
            {
                Userr($" Welcome to Game , {username}");// call interface 

                this.Hide();
                Start start = new Start();
                start.Show();
            }
            else
            {
                MessageBox.Show("Username or Password is incorrect.", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                txtUsername.Text = "";
                txtPassword.Password = "";
            }

        }
        //interface
        public void Userr(string message)
        {
            MessageBox.Show(  message,"hello! ",MessageBoxButton.OK,MessageBoxImage.Information);
        }


        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            tabControl.SelectedIndex = 1;
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

        private void btnLoginRegis_Click(object sender, RoutedEventArgs e)
        {
            name = txtName.Text;
            surname = txtSurname.Text;
            accountNumber = txtAccountNumber.Text;
            user = txtUsername2.Text;
            password = txtPassword2.Password;
            confirmpassword = txtConfirmPassword.Password;
            agee = age.SelectedItem.ToString();
            string newPassword = txtPassword2.Password;
            string confirmPassword = txtConfirmPassword.Password;


            if ((newPassword == confirmPassword) && (user != ""))
            {

                string show = "name : " + name + "\nsurname : " + surname + "\nuser : " + user + "\n\naccountNumber : " + accountNumber + "\nage : " + agee + "\nsex : "
                    + sexselect ;
                MessageBox.Show(show, "Confirm", MessageBoxButton.OK);

                _01User member = new _01User(name, surname, user, accountNumber, agee, sexselect, password, confirmpassword);
                string text = member.SetData();


                texts.Add(text);
                file1.AppendToFile(text);

                // ถ้ารหัสผ่านตรงกัน ให้ย้อนกลับไปแท็บก่อนหน้า (แท็บ Login)
                tabControl.SelectedIndex = 0; // 0 คือ Login, 1 คือ Register
                MessageBox.Show("Registration successful. Please log in.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                txtName.Text = "";
                txtSurname.Text = "";
                txtAccountNumber.Text = "";
                age.SelectedIndex = -1;
                txtUsername2.Text = "";
                txtPassword2.Password = "";
                txtConfirmPassword.Password = "";

            }
            else
            {
                // ถ้ารหัสผ่านไม่ตรงกัน ให้แจ้งเตือน
                MessageBox.Show("Passwords do not match. Please try again.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                txtUsername2.Text = "";
                txtPassword2.Password = "";
                txtConfirmPassword.Password = "";
            }

        }


        
        private void age_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender == null)
            {
                return;
            }

            ComboBox comboBox = sender as ComboBox;

            if (comboBox == null)
            {
                return;
            }

            if (comboBox.SelectedItem != null)
            {
                var ageSelect = age.SelectedItem.ToString();
            }

        }


        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            member = new List<_01User>();
            foreach (string i in file1.ReadFile())
            {
                if (i != "")
                {
                    texts.Add(i);
                    string[] data = new string[9];
                    data = i.Split(',');
                    string user = data[2];
                    string fullname = data[0] + "  " + data[1];
                    string age = data[5];
                    _01User p = new _01User(user, fullname, age);
                    member.Add(p);
                }
            }
            displayData.ItemsSource = member;
        }

        private void selectSex_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            sexselect = selectSex.SelectedItem.ToString();
        }

        public _01User Login(string username, string password)
        {
            throw new NotImplementedException();
        }

        public string SetData()
        {
            throw new NotImplementedException();
        }

        
    }
}