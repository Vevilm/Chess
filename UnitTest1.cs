using NUnit.Framework;
using Chess;

namespace ChessTest
{
    public class TestPawn
    {
        // ����� ��� ������������ ������������ ��� �����
        [Test]
        public void TestCreate()
        {
            // �������� �� ��, ��� ������� �������� ������� ������ ������������ ��������� [0; 7]
            Assert.That(() => new Pawn(true, new int[] {1, -1}), Throws.Exception);
            Assert.That(() => new Pawn(true, new int[] {-1, 1}), Throws.Exception);
            Assert.That(() => new Pawn(true, new int[] {-1, -1}), Throws.Exception);
            Assert.That(() => new Pawn(true, new int[] { 9, 1 }), Throws.Exception);
            Assert.That(() => new Pawn(true, new int[] { 1, 9 }), Throws.Exception);
            Assert.That(() => new Pawn(true, new int[] { 9, 9 }), Throws.Exception);
            
            // �������� �� ��, ��� ������, ���������� �������, ������ ��������� ������ ��� ��������
            Assert.That(() => new Pawn(true, new int[] { 3, 2, 4}), Throws.Exception);

            // �������� ����������� �������� �����
            Pawn pawn = new Pawn(true, new int[] {1, 3});
            Assert.That(pawn.isWhite == true);
            Assert.That(pawn.Pos[0] == 1);
            Assert.That(pawn.Pos[1] == 3);

            // �������� �� ��, ��� ������ ������� ������ �� ������� �������
            Assert.That(() => new Pawn(true, new int[] { 1, 3 }), Throws.Exception);
        }

        [Test]
        public void TestCanMoveWhite()
        {
            Pawn pawn = new Pawn(true, new int[] { 1, 1 });

            // ������� �� ��� ������ �����. �� ���� ������ �� ���� �� ������
            bool actual = pawn.CanMove(new int[] { 1, 3 });
            Assert.True(actual);

            // ������� �� ���� ������ �����. ��� �� ������
            actual = pawn.CanMove(new int[] { 1, 2 });
            Assert.True(actual);

            // ������� �� ���� ������ �� ���������. ��� �� ������
            actual = pawn.CanMove(new int[] { 2, 2 });
            Assert.False(actual);
            actual = pawn.CanMove(new int[] { 0, 2 });
            Assert.False(actual);

            // ������� �� ��� ������ �����. ������ ������ �� ���� ������, ������ ��������
            Pawn pawn1 = new Pawn(false, new int[] { 1, 3 });
            actual = pawn.CanMove(new int[] { 1, 3 });
            Assert.False(actual);
            Desk.TakenPositions[1, 3] = 0;
            
            // ������� �� ��� ������ �����. ������ ������ �� ���� ������
            Pawn pawn2 = new Pawn(false, new int[] { 1, 2 });
            actual = pawn.CanMove(new int[] { 1, 3 });
            Assert.False(actual);

            // ������� �� ���� ������ �����. ��� ������
            actual = pawn.CanMove(new int[] { 1, 2 });
            Assert.False(actual);

            // ������� �� ���� ������ �� ���������. ��� ������ ������� ����� �������
            Pawn pawn3 = new Pawn(true, new int[] { 2, 2 });
            Pawn pawn4 = new Pawn(true, new int[] { 0, 2 });
            actual = pawn.CanMove(new int[] { 2, 2 });
            Assert.False(actual);
            actual = pawn.CanMove(new int[] { 0, 2 });
            Assert.False(actual);

            // ������� �� ���� ������ �� ���������. ��� ������ ������� ��������������� �������
            Desk.TakenPositions[2, 2] *= -1;
            Desk.TakenPositions[0, 2] *= -1;
            actual = pawn.CanMove(new int[] { 2, 2 });
            Assert.True(actual);
            actual = pawn.CanMove(new int[] { 0, 2 });
            Assert.True(actual);
        }
    }
}