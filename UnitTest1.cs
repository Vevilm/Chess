using NUnit.Framework;
using Chess;

namespace ChessTest
{
    public class TestPawn
    {
        // Метод для тестирования конструктора для пешки
        [Test]
        public void TestCreate()
        {
            // Проверки на то, что входные значения позиции должны принадлежать интервалу [0; 7]
            Assert.That(() => new Pawn(true, new int[] {1, -1}), Throws.Exception);
            Assert.That(() => new Pawn(true, new int[] {-1, 1}), Throws.Exception);
            Assert.That(() => new Pawn(true, new int[] {-1, -1}), Throws.Exception);
            Assert.That(() => new Pawn(true, new int[] { 9, 1 }), Throws.Exception);
            Assert.That(() => new Pawn(true, new int[] { 1, 9 }), Throws.Exception);
            Assert.That(() => new Pawn(true, new int[] { 9, 9 }), Throws.Exception);
            
            // Проверка на то, что массив, отражающий позицию, должен содержать только два элемента
            Assert.That(() => new Pawn(true, new int[] { 3, 2, 4}), Throws.Exception);

            // Проверка корректного создания пешки
            Pawn pawn = new Pawn(true, new int[] {1, 3});
            Assert.That(pawn.isWhite == true);
            Assert.That(pawn.Pos[0] == 1);
            Assert.That(pawn.Pos[1] == 3);

            // Проверка на то, что нельзя создать фигуру на занятой позиции
            Assert.That(() => new Pawn(true, new int[] { 1, 3 }), Throws.Exception);
        }

        [Test]
        public void TestCanMoveWhite()
        {
            Pawn pawn = new Pawn(true, new int[] { 1, 1 });

            // Переход на две клетки вперёд. Ни одна клетка на пути не занята
            bool actual = pawn.CanMove(new int[] { 1, 3 });
            Assert.True(actual);

            // Переход на одну клетку вперёд. Она не занята
            actual = pawn.CanMove(new int[] { 1, 2 });
            Assert.True(actual);

            // Переход на одну клетку по диагонали. Она не занята
            actual = pawn.CanMove(new int[] { 2, 2 });
            Assert.False(actual);
            actual = pawn.CanMove(new int[] { 0, 2 });
            Assert.False(actual);

            // Переход на две клетки вперёд. Вторая клетка на пути занята, первая свободна
            Pawn pawn1 = new Pawn(false, new int[] { 1, 3 });
            actual = pawn.CanMove(new int[] { 1, 3 });
            Assert.False(actual);
            Desk.TakenPositions[1, 3] = 0;
            
            // Переход на две клетки вперёд. Первая клетка на пути занята
            Pawn pawn2 = new Pawn(false, new int[] { 1, 2 });
            actual = pawn.CanMove(new int[] { 1, 3 });
            Assert.False(actual);

            // Переход на одну клетку вперёд. Она занята
            actual = pawn.CanMove(new int[] { 1, 2 });
            Assert.False(actual);

            // Переход на одну клетку по диагонали. Она занята фигурой нашей команды
            Pawn pawn3 = new Pawn(true, new int[] { 2, 2 });
            Pawn pawn4 = new Pawn(true, new int[] { 0, 2 });
            actual = pawn.CanMove(new int[] { 2, 2 });
            Assert.False(actual);
            actual = pawn.CanMove(new int[] { 0, 2 });
            Assert.False(actual);

            // Переход на одну клетку по диагонали. Она занята фигурой противоположной команды
            Desk.TakenPositions[2, 2] *= -1;
            Desk.TakenPositions[0, 2] *= -1;
            actual = pawn.CanMove(new int[] { 2, 2 });
            Assert.True(actual);
            actual = pawn.CanMove(new int[] { 0, 2 });
            Assert.True(actual);
        }
    }
}