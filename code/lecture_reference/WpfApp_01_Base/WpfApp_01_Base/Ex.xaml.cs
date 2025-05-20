using System;
using System.Collections.Generic;
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

namespace WpfApp_01_Base
{
    /// <summary>
    /// Interaction logic for Ex.xaml
    /// </summary>
    public partial class Ex : Window
    {
        public Ex()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string id = txtId.Text;
            string pw = txtPw.Password;

            if (string.IsNullOrWhiteSpace(id) || string.IsNullOrWhiteSpace(pw))
            {
                MessageBox.Show("아이디와 비밀번호를 모두 입력해주세요.", "경고", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // 실제 로그인 처리 대신 테스트 메시지
            MessageBox.Show($"로그인 시도: {id} / {pw}", "로그인 정보");
        }
    }
}
