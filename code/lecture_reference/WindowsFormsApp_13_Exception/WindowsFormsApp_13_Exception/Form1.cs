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

            // [참고] 다양한 오류 타입별로 catch문 여러개 작성
            /*
             * .NET이 제공하는 기본 예외 클래스 中 일부
             */
            catch (DivideByZeroException ex)
            // [참고] 사실 뜯어보면, System.DivideByZeroException 이라는 네임스페이스 내의 클래스.
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
                // [참고] ㄴ 모든 예외 클래스의 최상위 부모이기에, 모든 예외를 하나로 받아서 처리 가능
                Console.WriteLine("오류: 예기치 못한 오류가 발생했습니다.");
                // Console.WriteLine($"Ex: {ex}");
                // 밑에 [참고] ex 찍어보기 설명.

                /*
                 * Exception ex 객체로 할 수 있는것? (자주 사용 되는 것)
                 * ex.Message: 예외 메시지 (사람이 읽을 수 있는 오류 설명)
                 * ex.StackTrace: 예외가 어디서 발생했는지 추적 정보
                 * ex.GetType(): 발생한 예외의 정확한 타입 반환
                 */
                Console.WriteLine($"[예외 메시지]: {ex.Message}");
                Console.WriteLine($"예외 타입: {ex.GetType()}");
                Console.WriteLine($"스택 정보: {ex.StackTrace}");

                /*
                 * [주의 사항]
                 * 1. catch (Exception ex)는 마지막에 배치해야 한다.
                 *    ㄴ 구체적인 예외를 먼저, 범용적인 Exception은 마지막에!
                 * 2. 예외를 너무 광범위하게 처리하면, 디버깅이 어려워지고
                 *    어떤 예외가 발생했는지 정확히 알기 어려워진다.
                 */
                // 밑에 [참고] 설명 추가로 하기!
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

        /*
         * Exception           // 모든 예외의 조상 클래스 ( 모든 예외는 여기서 부터 출발. )
         * ㄴ SystemException  // 시스템 관련 예외들의 부모 클래스
         *      ㄴ ~~~
         *          ㄴ Divide~
         * - 계층적 구조.
        */

        /*
         * [참고] ex 객체 찍어보기.
         * Exception 객체는.NET Framework의 내부 클래스이긴 하지만,
         * "우리가 직접 볼 수 없는 건 아니다" 라는 게 핵심입니다.
         * 
         * 사실, Exception 클래스는 **마이크로소프트가 제공하는 공식 문서와 오픈소스 레포지토리(GitHub)** 를 통해
         * 전체 속성(Property), 메서드(Method), 구조까지 전부 확인이 가능합니다.
         */

        /* [참고] catch 블록을 분리해서 조건 처리
            catch (Exception ex)
            {
                if (ex is DivideByZeroException)
                {
                    Console.WriteLine("0으로 나눈 예외!");
                }
                else if (ex is FormatException)
                {
                    Console.WriteLine("입력 형식 오류!");
                }
                else
            {
                Console.WriteLine("기타 예외 발생");
            }
        */
    }

}
