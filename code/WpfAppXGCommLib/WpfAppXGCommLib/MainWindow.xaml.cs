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
using System.Windows.Navigation;
using System.Windows.Shapes;
using XGCommLib;

namespace WpfAppXGCommLib
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            CommObjectFactory20 factory = new CommObjectFactory20();
        }

        private void ButtonConnect_Click(object sender, RoutedEventArgs e)
        {
            //연결
            CommObjectFactory20 factory = new CommObjectFactory20();
            CommObject20 oCommDriver = factory.GetMLDPCommObject20("192.168.0.224:2004");

            if (0 == oCommDriver.Connect(""))
            {
                MessageBox.Show("연결 실패");
                return;
            }
            else
            {
                MessageBox.Show("연결 성공");
            }

            //버퍼 초기화
            int nMaxBuf = 1400;
            byte[] bufWrite = new byte[nMaxBuf];

            int nTotal_len = 0;

            //데이터 설정
            XGCommLib.DeviceInfo oDevice = factory.CreateDevice();

            ComboBoxItem item = (ComboBoxItem)ComboBox_DataType.SelectedValue;
            char dataType = item.Content.ToString()[0];
            oDevice.ucDataType = (byte)dataType;

            item = (ComboBoxItem)ComboBox_DeviceType.SelectedValue;
            char deviceType = item.Content.ToString()[0];
            oDevice.ucDeviceType = (byte)deviceType;
        
            oDevice.lOffset = int.Parse(TextBox_ByteOffset.Text);

            byte[] bWriteBuf = null;
            if (dataType == 'B')
            {
                nTotal_len = int.Parse(TextBox_BitOffset.Text);
                oDevice.lSize = nTotal_len;
                oCommDriver.AddDeviceInfo(oDevice);

                bufWrite[0] = (byte)int.Parse(TextBox_1or0.Text);

                //데이터 전송
                bWriteBuf = new byte[nTotal_len];
                Array.Copy(bufWrite, 0, bWriteBuf, 0, nTotal_len);
            }
            else if (dataType == 'X')
            {
                nTotal_len = int.Parse(TextBox_BitOffset.Text);
                oDevice.lSize = nTotal_len;
                oCommDriver.AddDeviceInfo(oDevice);

                
                bufWrite[0] = (byte)int.Parse(TextBox_1or0.Text);

                //데이터 전송
                bWriteBuf = new byte[1];
                Array.Copy(bufWrite, 0, bWriteBuf, 0, 1);
            }

            int ret = oCommDriver.WriteRandomDevice(bWriteBuf);
            Console.WriteLine($"ret {ret}");
            if (1 == oCommDriver.WriteRandomDevice(bWriteBuf))
            {
                MessageBox.Show("데이터 전송 성공");
            }
            else
            {
                MessageBox.Show("데이터 전송 실패");
            }

            //데이터 읽기
            byte[] bufRead = null;

            if (dataType == 'B')
            {
                bufRead = new byte[nTotal_len];
            }
            else if (dataType == 'X')
            {
                bufRead = new byte[1];
            }
            if (1 == oCommDriver.ReadRandomDevice(bufRead))
            {
                Console.WriteLine($"buf read {bufRead}, {bufRead.Length}");
                for (int i = 0; i < bufRead.Length; i++)
                {
                    TextBox_Result.AppendText(bufRead[i].ToString("X2"));
                }
                MessageBox.Show("데이터 읽기 성공");
            }
            else
            {
                MessageBox.Show("데이터 읽기 실패");
            }

            if (false == bWriteBuf.SequenceEqual(bufRead))
            {
                TextBox_Result.AppendText("Mismatch\r\n");
            }
            else
            {
                TextBox_Result.AppendText("Match\r\n");
            }

            //연결 종료
            int nRetn = oCommDriver.Disconnect();
            if (nRetn == 1)
            {
                MessageBox.Show("연결 종료");
            }
            else
            {
                MessageBox.Show("연결 종료 실패");
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_BitOffset_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
