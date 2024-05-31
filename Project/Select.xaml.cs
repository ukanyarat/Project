using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Project
{
    /// <summary>
    /// Interaction logic for Select.xaml
    /// </summary>
    public partial class Select : Window
    {
        private Game label;

        public Select()
        {
            InitializeComponent();
            label = new Game();

            for (int i = 1; i <= 100; i++)
            {
                selectNum1.Items.Add(i);
                selectNum2.Items.Add(i);
                selectNum3.Items.Add(i);
            }
        }

        private void SendValuesToWPF2(string value1, string value2, string value3)
        {
            // ตรวจสอบว่าค่าไม่เป็น null
            if (value1 != null && value2 != null && value3 != null)
            {
                label.ComboBox1Value = value1;
                label.ComboBox2Value = value2;
                label.ComboBox3Value = value3;

                Game gamePage = new Game();
                gamePage.DataContext = label; // ตั้งค่า DataContext
                gamePage.Show();
            }
            else
            {
                MessageBox.Show("Please select a number", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if ((selectNum1.SelectedItem == null) || (selectNum2.SelectedItem == null) || (selectNum3.SelectedItem == null))
            {
                MessageBox.Show("Please enter number", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                string selectedValue1 = selectNum1.SelectedItem.ToString();
                string selectedValue2 = selectNum2.SelectedItem.ToString();
                string selectedValue3 = selectNum3.SelectedItem.ToString();

                // เรียกใช้เมธอดเพื่อส่งค่าไปยัง GamePage  
                SendValuesToWPF2(selectedValue1, selectedValue2, selectedValue3);
                this.Close();
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            selectNum1.SelectedIndex = -1;
            selectNum2.SelectedIndex = -1;
            selectNum3.SelectedIndex = -1;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Start start = new Start();
            start.Show();
        }
    }
}
