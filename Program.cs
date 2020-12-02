using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CircleApp
{
    class Program
    {
        static int Menu()
        {
            Console.Clear(); // 메뉴가 불러질 때마다 화면 청소
            Console.WriteLine("[0] 프로그램 종료 [1] 원 그리기 [2] 그린 원 출력");

            try
            {
                return int.Parse(Console.ReadLine()); //메뉴 입력받아서 리턴
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.GetBaseException()); //에러 출력
                return -1;
            }
        }

        static void InputOriginCircleInfo(CoordinatePlane cp)
        {
            int radius = 0 , cnt = 0 , cx = 0 , cy = 0;
            // 반지름, 등분, 원점 X, 원점 Y
            try  
            {
                Console.Write("그릴 원의 반지름을 입력하세요 : ");
                radius = int.Parse(Console.ReadLine());

                Console.Write("원을 몇 등분 하시겠습니까? : ");
                cnt = int.Parse(Console.ReadLine());

                Console.Write("원점 X 좌표 값 입력 : ");
                cx = int.Parse(Console.ReadLine());
                
                Console.Write("원점 Y 좌표 값 입력 : ");
                cy = int.Parse(Console.ReadLine());
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.GetBaseException());
                return;
            }

            cp.MakeCircle(radius, cnt,cx,cy);// 좌표평면에 원을 만들때 필요한 원점과 반지름, 등분수를 보냄
        }

       
        static void PrintPoint(CoordinatePlane cp)
        {
            var subset = from i in cp.PtList select i; 
            // ptList로부터 LINQ를 통해 원 위의 임의의 등분한 점을 출력
            foreach (var s in subset)
            {
                Console.WriteLine(s);
            }
        }

        static void Main(string[] args)
        {
            CoordinatePlane cp = new CoordinatePlane(); //좌표평면
            int key = 0; // 메뉴 입력 변수
    
            for(;;)
            if ((key = Menu()) != -1)
            {
                switch (key)
                {
                    case 1: InputOriginCircleInfo(cp); break; //원점에 대한 원을 그리고 저장된 원의 좌표를 출력
                    case 2: PrintPoint(cp); break;  //좌표 평면 원 위의 등분한 임의의 점을 출력
                    case 0: return ; //종료
                }
                Console.WriteLine("아무키나 누르세요");
                Console.ReadLine(); //무한루프 대기 입력
            }
        }
    }
}
