using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Conway;

namespace Conway.Tests
{
    [TestClass]
    public class BoardTests
    {
        [TestMethod]
        public void Board_Renders_Correctly()
        {
            var board = new Board(3);

            board.SetCell(0, true);
            board.SetCell(1, false);
            board.SetCell(2, false);
            board.SetCell(3, false);
            board.SetCell(4, true);
            board.SetCell(5, true);
            board.SetCell(6, false);
            board.SetCell(7, true);
            board.SetCell(8, false);

            string expected = "X--\r\n-XX\r\n-X-\r\n";
            string actual = board.Render();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Board_Updates_Correctly_Glider()
        {
            var board = new Board(5);

            board.SetCell(6, true);
            board.SetCell(13, true);
            board.SetCell(16, true);
            board.SetCell(17, true);
            board.SetCell(18, true);
            board.Update();

            var expectedBoard = new Board(5);
            expectedBoard.SetCell(11, true);
            expectedBoard.SetCell(13, true);
            expectedBoard.SetCell(17, true);
            expectedBoard.SetCell(18, true);
            expectedBoard.SetCell(22, true);

            string expected = expectedBoard.Render();
            string actual = board.Render();

            Assert.AreEqual(expected, actual);

        }
    }
}
