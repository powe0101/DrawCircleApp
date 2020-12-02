using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
//using System.Drawing; 

namespace CircleApp
{
    static class test
    {
        public static double ToRadians(this int val) //확장메서드
        {
            return (0.017453292519943295 * val); //1라디안 * 각도
        }
    }
    
    struct Point
    {
        private readonly double _x; //초기화시만 수정가능한(readonly) 가능한 변수
        private readonly double _y;
        public Point(double x, double y)
        {
            _x = x;
            _y = y;
        }

        public override string ToString()
        {
            return "X : " + _x + " Y : " + _y;
        }
    } //double PointStruct
    class CoordinatePlane
    {
        const int MAX_RADIAN = 360; // 원의 최대 각도
        List<Point> ptList = new List<Point>(); //원 위의 점 좌표를 관리할 리스트 컬렉션

        public List<Point> PtList {get { return ptList; }} //외부에서 리스트 컬렉션에 읽기 만 가능하도록.

        public bool MakeCircle(int radian, int cnt, int cx = 0, int cy =0)//원점 x,y는 디폴트로 0,0
        {
            ptList.Clear();// 이미 그린 원이 있을 수 있으므로 컬렉션 클리어
            double angle = MAX_RADIAN / cnt; // 원의 최대 각도에서 등분을 나누어서 각도를 구함.

            try
            {
                for (int i = 0; i < MAX_RADIAN; i += (int)angle) //i = 0 부터 360도까지 각도 나눠서 더함
                {

                    double x = Math.Round((double)(Math.Cos(i.ToRadians()) * radian), 3) - cx;
                    double y = Math.Round((double)(Math.Sin(i.ToRadians()) * radian), 3) - cy;
                    //반올림 소수 셋째자리까지
                    //반지름 * Cos - 원점X = 원점으로부터 원 위의 x좌표 
                    //반지름 * Sin - 원점 Y = 원 위의 y좌표
                    ptList.Add(new Point(x, y));
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.GetBaseException());
                return false; //실패
            }
            return true; //원을 제대로 만듬
        }
    }
}
