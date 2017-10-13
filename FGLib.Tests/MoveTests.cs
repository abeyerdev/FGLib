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
            List<string> commandList = new List<string>() { "d", "df", "f" };
            Move fireball = new Move("Hadouken", new CommandSequence(commandList));

            Assert.IsInstanceOfType(fireball, typeof(Move));
            Assert.AreEqual(fireball.Name, "Hadouken");
        }
    }
}
