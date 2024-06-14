using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public abstract class Figure
    {
        // Вес фигуры
        public int cost;
        // Принадлежность к команде
        public bool isWhite;
        // Позиция на доске
        public int[] Pos;
        
        // Метод передвижения
        abstract public void Move();
        // Метод получения всех возможных позиций, на которые может сходить фигура
        abstract public int[][] GetPossibleMoves();
        // Метод проверки на то, есть ли у фигуры возможные ходы
        abstract public bool CanMove(int[] Target);
    }
}
