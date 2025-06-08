using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace WpfApp_02_Advanced
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
        }

        public class Person
        {
            public string 이름 { get; set; }
            public int 나이 { get; set; }
            public string 설명 { get; set; }

        }
        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "CSV 파일 (*.csv)|*.csv";

            if (ofd.ShowDialog() == true)
            {
                lblPath.Content = ofd.FileName;
                List<Person> people = new List<Person>();

                try
                {
                    using (StreamReader reader = new StreamReader(ofd.FileName))
                    {
                        reader.ReadLine();

                        while (!reader.EndOfStream)
                        {
                            string line = reader.ReadLine();
                            var parts = line.Split(',');

                            if (parts.Length < 3) continue;

                            people.Add(new Person
                            {
                                이름 = parts[0],
                                나이 = int.Parse(parts[1]),
                                설명 = parts[2]
                            });
                        }
                    }
                    dataGrid.ItemsSource = people;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("파일 불러오는 도중 오류!" + ex.Message);
                }
            }
        }

        private void btnGetData_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem is Person selected)
            {
                MessageBox.Show("선택된 이름: " + selected.이름);
            }
            else
            {
                MessageBox.Show("선택된 행 없음.");
            }
        }
    }
}