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
            #region try - catch
            //try
            //{
            //    Console.Write("숫자를 입력하세요: ");
            //    string input = Console.ReadLine();

            //    // 문자열을 정수로 변환
            //    // [오류] (FormatException 발생 가능)
            //    int number = int.Parse(input);

            //    // 입력 받은 숫자로 100을 나눔.
            //    // [오류] (DivideByZeroException 발생 가능)
            //    int result = 100 / number;

            //    // [추가] throw: 개발자가 직접 의도적으로 예외를 발생시킴
            //    if (number < 0)
            //    {
            //        throw new Exception("예외 발생! 이건 개발자가 일부러 던진 에러입니다!");
            //    }

            //    Console.WriteLine($"100 / {number} = {result}");

            //}
            //// .NET이 제공하는 기본 예외 클래스 中 일부
            //catch (DivideByZeroException ex)
            //{
            //    Console.WriteLine("오류: 0으로 나눌 수 없습니다.");
            //    Console.WriteLine($"[예외 메시지]: {ex.Message}");
            //}
            //catch (FormatException ex)
            //{
            //    Console.WriteLine("오류: 숫자가 아닌 값을 입력하셨습니다.");
            //    Console.WriteLine($"[예외 메시지]: {ex.Message}");
            //}
            //catch (Exception ex)
            //{
            //    /*
            //     * 그 외 모든 예외 처리 (예외의 최상위 클래스 Exception 사용)
            //     * 발생한 예외 객체를 Exception 타입으로 받아서 ex라는 객체명을 사용.
            //     * 
            //     * Exception ex 객체로 할 수 있는 것? (자주 사용 되는 것)
            //     * ex.Message: 예외 메시지 (사람이 읽을 수 있는 오류 설명)
            //     * ex.StackTrace: 예외가 어디서 발생했는지 추적 정보
            //     * ex.GetType(): 발생한 예외의 정확한 타입 반환
            //     */
            //    Console.WriteLine("오류: 예기치 못한 오류가 발생했습니다.");
            //    Console.WriteLine($"[예외 메시지]: {ex.Message}");
            //    Console.WriteLine($"[예외 타입]: {ex.GetType()}");
            //    Console.WriteLine($"[스택 정보]: {ex.StackTrace}");

            //    Console.WriteLine("=========================");
            //    // [참고 1] Console.WriteLine(ex);

            //    /*
            //     * [주의 사항]
            //     * 1. catch (Exception ex)는 마지막에 배치해야 한다.
            //     *    ㄴ 구체적인 예외를 먼저, 범용적인 Exception은 마지막에!
            //     * 2. 예외를 너무 광범위하게 처리하면, 디버깅이 어려워지고
            //     *    어떤 예외가 발생했는지 정확히 알기 어려워진다!
            //     */

            //}
            //finally
            //{
            //    // 예외 발생 여부와 관계없이 무조건 실행되는 블록
            //    Console.WriteLine("프로그램을 종료합니다. 감사합니다");
            //    Console.ReadLine();
            //}

            #endregion

            #region 실습

            try
            {
                // 1. 사용자로부터 닉네임 입력 받기
                Console.Write("닉네임을 입력하세요: ");
                string nickname = Console.ReadLine();

                // 2. 예외 조건 검사 & 예외 발생

                // #1. 입력 값이 비어있는 경우
                if (string.IsNullOrWhiteSpace(nickname))
                {
                    // 다음 셋 중 하나에 해당하는 경우 true를 반환.
                    // null 인 경우
                    // 빈 문자열 ("") 인 경우
                    // 공백 문자만 포함된 문자열인 경우 (" ")
                    throw new Exception("닉네임을 입력해주세요.");
                }

                // #2. 길이가 2글자 미만인 경우
                if (nickname.Length < 2)
                {
                    throw new Exception("닉네임은 2글자 이상이어야 합니다.");
                }

                // #3. 'admin'이 포함된 경우
                if (nickname.ToLower().Contains("admin"))
                {
                    throw new Exception("닉네임에 'admin'은 포함할 수 없습니다.");
                }

                // 3. 모든 조건을 통과하면 성공 메시지 출력
                Console.WriteLine("닉네임 등록 완료!");
            }
            catch (Exception ex) 
            {
                // 4. 예외 발생 시 사용자에게 메시지 출력.
                Console.WriteLine($" *경고* : {ex.Message}");
            }
            finally
            {
                // 5. 예외 여부와 관계없이 항상 출력.
                Console.WriteLine("프로그램을 종료합니다.");
            }
            Console.ReadLine();
            #endregion

        }
        /*
         * [참고 1]
         * ex 객체 찍어볼 수 있다.
         * Exception 객체는 .NET Framework의 내부 클래스 이긴 하지만,
         * "우리가 직접 볼 수 없는 건 아니다"
         * But, 내부적인 모든 내용을 볼 수 있는건 아니다.
         * 
         * 사실, Exception 클래스는 "마이크로소프트가 제공하는 공식 문서와 오픈 소스 레포(Github)를
         * 통해 전체 속성, 메서드, 구조까지 전부 확인이 가능합니다.
         */
    }
}
