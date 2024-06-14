using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public static class Desk
    {
        // Массив позиций на доске (1 - фигуры белых, 0 - пустая клетка, -1 - фигуры чёрных)
        public static int[,] TakenPositions = new int[8,8];
        // Проверка на допустимость позиции
        public static bool IsValidPosition(int[] position)
        {
            if (position.Length > 2 || position[0] > 7 || position[0] < 0 || position[1] > 7 || position[1] < 0) return false;
            else return true;
        }
    }
}
