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
#region 설명
/*
 * LINQ (Language Integrated Query)
 * 컬렉션 데이터를 편리하게 필터링, 정렬, 변환 등 처리할 수 있도록 도와주는 문법
 * 
 * - skip()
 *   ㄴ 앞에서부터 N개를 건너뛰고 그 이후부터 반환
 *   
 * - ToList()
 *   ㄴ IEnumerable 형식의 데이터를 List<T> 로 변환
 *   ㄴ 열거할 수 있는" (하나씩 반복해서 꺼내쓸 수 있는) 데이터를 의미하는 **인터페이스**
 */

#endregion