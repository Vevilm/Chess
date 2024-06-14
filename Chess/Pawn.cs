using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class Pawn : Figure
    {
        // Переменная, указывающая на то, двигалась ли пешка
        bool hasMoved;
        // Переменная, отражающая модификатор для команды
        int movementModifier;
        
        public Pawn(bool isWhite, int[] position)
        {
            if (!Desk.IsValidPosition(position)) throw new Exception("Позиция была задана неверно");
            if (Desk.TakenPositions[position[0], position[1]] == 0)
            {
                movementModifier = isWhite ? 1 : -1;
                Desk.TakenPositions[position[0], position[1]] = movementModifier;
                this.isWhite = isWhite;
                Pos = position;
            }
            else
            {
                throw new Exception("Невозможно поставить фигуру на занятую позицию");
            }
        }

        public override void Move()
        {
            
        }
        public override int[][] GetPossibleMoves()
        {
            throw new NotImplementedException();
        }
        public override bool CanMove(int[] Target)
        {
            int delta = (Target[1] - Pos[1]) * movementModifier;
            if (Target[0] == Pos[0] && Desk.TakenPositions[Pos[0], Pos[1] + 1] == 0)
            {
                if (delta == 1 || (delta == 2 && !hasMoved && Desk.TakenPositions[Target[0], Target[1]] == 0))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if ((Math.Abs(Target[0] - Pos[0]) == 1) && (delta == 1) && (Desk.TakenPositions[Target[0], Target[1]] == -1 * movementModifier))
            {
                return true;
            }
            else 
            {
                return false;
            }
        }
    }
}
