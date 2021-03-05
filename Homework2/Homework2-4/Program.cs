using System;

namespace Homework2_4
{
    class Program
    {
        public static string defMatrix(int[,] mat)//if its the right matirx return true, else false
        {
            int i = 0, j = 0;
            for (; i < mat.GetLength(0) && j < mat.GetLength(1) && mat[0,0] == mat[i,j]; i++, j++) ;
            if (i == mat.GetLength(0) || j == mat.GetLength(1))
            {
                return "Yes";
            }
            else
            {
                return "No";
            }
        }
        static void Main(string[] args)
        {
            int[,] matA = new int[,] { { 1, 2, 3, 4 }, { 5, 1, 2, 3 }, { 9, 5, 1, 2 } };
            int[,] matB = new int[,] { { 1, 2, 3 }, { 1, 2, 3 }, { 1, 2, 3 } };
            Console.WriteLine("matA:" + defMatrix(matA));
            Console.WriteLine("matB:" + defMatrix(matB));
        }
    }
}
