using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FGLib.Tests
{
    [TestClass]
    public class MoveTests
    {
        [TestMethod]
        public void CanCreateMove_Test()
        {
            List<ConsoleKey> commandList = new List<ConsoleKey>()
            {
                ConsoleKey.DownArrow,
                ConsoleKey.RightArrow,
                ConsoleKey.P
            };
            Move fireball = new Move(new CommandSequence<ConsoleKey>(commandList), "Hadouken");

            Assert.IsInstanceOfType(fireball, typeof(Move));
            Assert.AreEqual(fireball.Name, "Hadouken");
        }
    }
}
