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

namespace WpfApp_04_DesignPattern
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Logger logger1 = Logger.GetInstance();

        }
    }

    public class Logger
    {
        // 1. 정적(static)으로 자기 자신 인스턴스로 저장.
        private static Logger instance;

        // 2. 외부에서 생성 못하도록 생성자 private
        private Logger()
        {
            Console.WriteLine("Logger 생성됨!");
        }

        // 3. 인스턴스를 외부에 제공하는 정적 메서드
        public static Logger GetInstance()
        {
            if (instance == null)
            {
                instance = new Logger();    // 처음 한 번만 생성
            }

            return instance;
        }

        // 4. 기능 예시
        public void Log(string msg)
        {
            Console.WriteLine(msg);
        }
    }

}