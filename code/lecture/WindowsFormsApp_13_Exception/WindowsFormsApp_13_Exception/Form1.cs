using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp_13_Exception
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            try
            {
                Console.Write("숫자를 입력하세요: ");
                string input = Console.ReadLine();

                // 문자열을 정수로 변환 
                // [오류] (FormatException 발생 가능)
                int number = int.Parse(input);

                // 입력 받은 숫자로 100을 나눔.
                // [오류] (DivideByZeroException 발생 가능)
                int result = 100 / number;

                // [추가] throw : 개발자가 직접 의도적으로 예외를 발생시킴
                if (number < 0)
                {
                    throw new Exception("예외 발생! 이건 개발자가 일부러 던진 에러입니다!");
                }

                Console.WriteLine($"100 / {number} = {result}");
            }

            
            catch (DivideByZeroException ex)
            {
                // 0으로 나누려 할 때 발생하는 예외 처리
                Console.WriteLine("오류: 0으로 나눌 수 없습니다.");
                Console.WriteLine($"[예외 메시지]: {ex.Message}");
            }
            //catch (FormatException ex)
            //{
            //    // 잘못된 형식의 입력 (예: 문자를 숫자로 변환 시도할 때)
            //    Console.WriteLine("오류: 숫자가 아닌 값을 입력하셨습니다.");
            //    Console.WriteLine($"[예외 메시지]: {ex.Message}");
            //}
            catch (Exception ex)
            {
                // #1.
                // 그 외 모든 예외 처리 (예외의 최상위 클래스 Exception 사용)
                // 발생한 예외 객체를 Exception 타입으로 받아서 ex라는 객체명으로 사용.
                Console.WriteLine("오류: 예기치 못한 오류가 발생했습니다.");
                // Console.WriteLine($"Ex: {ex}");

                Console.WriteLine($"[예외 메시지]: {ex.Message}");
                Console.WriteLine($"예외 타입: {ex.GetType()}");
                Console.WriteLine($"스택 정보: {ex.StackTrace}");

                
            }

            finally
            {
                // 예외 발생 여부와 관계없이 무조건 실행되는 블록
                Console.WriteLine("프로그램을 종료합니다. 감사합니다.");
                Console.ReadLine();
            }

            try
            {
                // 1. 사용자로부터 닉네임 입력 받기
                Console.Write("닉네임을 입력하세요: ");
                string nickname = Console.ReadLine();

                // 2. 예외 조건 검사 및 예외 발생

                // (1) 비어있는 경우
                if (string.IsNullOrWhiteSpace(nickname))
                {
                    // 다음 셋 중 하나에 해당하는 경우 true를 반환
                    // null인 경우
                    // 빈 문자열("")인 경우
                    // 공백 문자만 포함된 문자열인 경우 (예: " ")
                    throw new Exception("닉네임을 입력해주세요.");

                }

                // (2) 길이가 2글자 미만인 경우
                if (nickname.Length < 2)
                {
                    throw new Exception("닉네임은 2글자 이상이어야 합니다.");
                }

                // (3) 'admin'이 포함된 경우
                if (nickname.ToLower().Contains("admin"))
                {
                    throw new Exception("닉네임에 'admin'은 포함할 수 없습니다.");
                }

                // 3. 모든 조건을 통과하면 성공 메시지 출력
                Console.WriteLine("닉네임 등록 완료!");
            }
            catch (Exception ex)
            {
                // 4. 예외 발생 시 사용자에게 메시지 출력
                Console.WriteLine($"❗ {ex.Message}");
            }
            finally
            {
                // 5. 예외 여부와 관계없이 항상 출력
                Console.WriteLine("프로그램을 종료합니다.");
            }

            Console.ReadLine(); // 콘솔 창 유지
        }
    }

}
