using Chapter09;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Project
{
    public class _01User 
    {
        protected string name;
        protected string surname;
        protected string user;
        protected string password;
        protected string accountNumber;
        protected string age;
        protected string sexselect;
        protected string money;
        protected string win;
        protected string card;
        protected string confirmpassword;
        protected string fullname;
        protected string image;

        private List<string> texts = new List<string>();
        FileManagement file1 = new FileManagement("D:/000000/Project/Project/member.txt");

        // Constructors
        public _01User()
        {
            // Initialization code here, if needed
        }

        public _01User(string name, string surname, string user, string accountNumber, string age, string sexselect, string password, string confirmpassword)
        {
            this.name = name;
            this.surname = surname;
            this.user = user;
            this.accountNumber = accountNumber;
            this.age = age;
            this.sexselect = sexselect;
            this.password = password;
            this.confirmpassword = confirmpassword;
        }

        public _01User(string user, string fullname, string age)
        {
            this.user = user;
            this.fullname = fullname;
            this.age = age;
        }

        public _01User(string user, string password)
        {
            this.user = user;
            this.password = password;
        }





        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }

        public string User
        {
            get { return user; }
            set { user = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string AccountNumber
        {
            get { return accountNumber; }
            set { accountNumber = value; }
        }

        public string Age
        {
            get { return age; }
            set { age = value; }
        }

        public string Sex
        {
            get { return sexselect; }
            set { sexselect = value; }
        }

        public string FullName
        {
            get { return fullname; }
            set { fullname = value; }
        }

        public string Image
        {
            get { return image; }
            set { image = value; }
        }

        //ตรวจสอบข้อมูลผู้ใช้เมื่อมีการล็อกอิน
        public _01User Login(string username, string password)
        {
            string[] lines = file1.ReadAllLines("member.txt");

            foreach (string line in lines)
            {
                string[] parts = line.Split(',');

                if (parts[2] == username && parts[3] == password)
                {
                    return new _01User
                    {
                        name = parts[0],
                        surname = parts[1],
                        user = parts[2],
                        password = parts[3],
                        accountNumber = parts[4],
                        age = parts[5],
                        sexselect = parts[6],
                    };
                }
            }
            return null;
        }


        public string SetData()
        {
            return $"{name},{surname},{user},{password},{accountNumber},{age},{sexselect}";
        }
    }
}
