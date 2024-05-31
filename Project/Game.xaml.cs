using Chapter09;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Windows;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace Project
{
    /// <summary>
    /// Interaction logic for Game.xaml
    /// </summary>
    public partial class Game : Window
    {
        FileManagement file2 = new FileManagement("D:/000000/Project/Project/game.txt");
        private List<string> texts = new List<string>();

        private string _randomNumber;
        private int randomCount = 0;
        private string _comboBox1Value;
        private string _comboBox2Value;
        private string _comboBox3Value;

        public string ComboBox1Value
        {
            get { return _comboBox1Value; }
            set
            {
                _comboBox1Value = value;
                OnPropertyChanged(nameof(ComboBox1Value));
            }
        }

        public string ComboBox2Value
        {
            get { return _comboBox2Value; }
            set
            {
                _comboBox2Value = value;
                OnPropertyChanged(nameof(ComboBox2Value));
            }
        }

        public string ComboBox3Value
        {
            get { return _comboBox3Value; }
            set
            {
                _comboBox3Value = value;
                OnPropertyChanged(nameof(ComboBox3Value));
            }
        }

        public string RandomNumber
        {
            get { return _randomNumber; }
            set
            {
                _randomNumber = value;
                OnPropertyChanged(nameof(RandomNumber));
            }
        }

        public Game()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            YourScore score = new YourScore();
            score.Show();
        }

        private void btnNewSelect_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Select select = new Select();
            select.Show();
        }


        public void GenerateRandomNumber()
        {
            
            if (randomCount < 5)
            {
                Random random = new Random();
                int number = random.Next(1, 10);
                txtRND.Content = number.ToString();

                btnNewSelect.IsEnabled = false; 
                randomCount++;

                string[] lines = file2.ReadAllLines("game.txt");

                List<string> newData = new List<string>();

                if (number.ToString() == txt1.Content)
                {

                    foreach (string line in lines)
                    {
                        string[] parts = line.Split(',');

                        if (parts.Length == 3)
                        {
                            if (parts[2] == parts[2])
                            {
                                
                                decimal balance = decimal.Parse(parts[0]);
                                int win = int.Parse(parts[1]) + 1;
                                if (win == 0)
                                {
                                    //bool money1  = int.TryParse(parts[0], out int result);
                                    //int sum = money1;
                                    parts[2] = "0";
                                    //parts[0] = parts[0] + 500 ;
                                }
                                else if (win == 1)
                                {
                                    parts[2] = "1";
                                }
                                else if (win == 2)
                                {
                                    parts[2] = "2";
                                }
                                else if ((win >= 3) && (win <= 4))
                                {
                                    parts[2] = "3";
                                }
                                else if ((win >= 5) && (win <= 10))
                                {
                                    parts[2] = "4";
                                }
                                else
                                {
                                    parts[2] = "5";
                                }
                                
                                int card = int.Parse(parts[2]);
                                // สร้างข้อมูลใหม่ที่มีค่าใหม่แล้วเขียนลงใน List

                                _02Game member = new _02Game(balance, win, card);
                                string text = member.newData();


                                texts.Add(text);
                                file2.WriteFile("game.txt", texts);

                            }
                        }

                    }

                    MessageBox.Show("Congratulations, you win.", "winner", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close(); 
                    YourScore score = new YourScore();
                    score.Show(); 

                }

                else if (number.ToString() == txt2.Content)
                {
                    // วนลูปผ่านแต่ละบรรทัดในไฟล์ game.txt
                    foreach (string line in lines)
                    {
                        // แยกข้อมูลด้วยเครื่องหมาย ','
                        string[] parts = line.Split(',');

                        if (parts.Length == 3)
                        {
                            // เช็คว่าเราอยู่ที่อาร์เรย์ที่ 2 หรือไม่
                            if (parts[2] == parts[2])
                            {
                                // แปลงข้อมูลในอาร์เรย์ที่ 2 เป็นตัวเลขแล้วบวกด้วย 10
                                decimal balance = decimal.Parse(parts[0]);
                                int win = int.Parse(parts[1]) + 1;
                                if (win == 0) {
                                    parts[0] = "0" ;
                                }
                                else if (win == 1)
                                {
                                    parts[0] = "1";
                                }
                                else if ((win >= 2) && (win <= 4))
                                {
                                    parts[0] = "2";
                                }
                                else if ((win >= 5) && (win <= 9))
                                {
                                    parts[0] = "3";
                                }
                                else if ((win >= 10) && (win < 20))
                                {
                                    parts[0] = "4";
                                }
                                else
                                {
                                    parts[0] = "5";
                                }
                                int card = int.Parse(parts[0]);
                                // สร้างข้อมูลใหม่ที่มีค่าใหม่แล้วเขียนลงใน List

                                _02Game member = new _02Game(balance, win, card);
                                string text = member.newData();


                                texts.Add(text);
                                file2.WriteFile("game.txt", texts);

                            }
                        }

                    }

                    MessageBox.Show("Congratulations, you win.", "winner", MessageBoxButton.OK, MessageBoxImage.Information); 
                    this.Close(); // ปิดหน้าต่างปัจจุบัน
                    YourScore score = new YourScore();
                    score.Show(); // เปิดหน้าต่าง YourScore

                }
                else if (number.ToString() == txt3.Content)
                {
                    // วนลูปผ่านแต่ละบรรทัดในไฟล์ game.txt
                    foreach (string line in lines)
                    {
                        // แยกข้อมูลด้วยเครื่องหมาย ','
                        string[] parts = line.Split(',');

                        if (parts.Length == 3)
                        {
                            // เช็คว่าเราอยู่ที่อาร์เรย์ที่ 2 หรือไม่
                            if (parts[2] == parts[2])
                            {
                                // แปลงข้อมูลในอาร์เรย์ที่ 2 เป็นตัวเลขแล้วบวกด้วย 10
                                decimal balance = decimal.Parse(parts[0]);
                                int win = int.Parse(parts[1]) + 1;
                                if (win == 0)
                                {
                                    parts[0] = "0";
                                }
                                else if (win == 1)
                                {
                                    parts[0] = "1";
                                }
                                else if ((win >= 2) && (win <= 4))
                                {
                                    parts[0] = "2";
                                }
                                else if ((win >= 5) && (win <= 9))
                                {
                                    parts[0] = "3";
                                }
                                else if ((win >= 10) && (win < 20))
                                {
                                    parts[0] = "4";
                                }
                                else
                                {
                                    parts[0] = "5";
                                }
                                int card = int.Parse(parts[0]);
                                // สร้างข้อมูลใหม่ที่มีค่าใหม่แล้วเขียนลงใน List

                                _02Game member = new _02Game(balance, win, card);
                                string text = member.newData();


                                texts.Add(text);
                                file2.WriteFile("game.txt", texts);
                            }
                        }

                    }

                    MessageBox.Show("Congratulations, you win.", "winner", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close(); // ปิดหน้าต่างปัจจุบัน
                    YourScore score = new YourScore();
                    score.Show(); // เปิดหน้าต่าง YourScore


                }
                }
                else
                {
                    MessageBox.Show("Sorry you lost. Play again!!!", "loser", MessageBoxButton.OK, MessageBoxImage.Error);
                    this.Close(); // ปิดหน้าต่างปัจจุบัน
                    YourScore score = new YourScore();
                    score.Show(); // เปิดหน้าต่าง YourScore
                }
            }
        

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void btnRandom_Click(object sender, RoutedEventArgs e)
        {
            GenerateRandomNumber();
        }
    }
}
