using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FGLib.InputHandling;

namespace FGLib.Tests
{
    [TestClass]
    public class MoveTests
    {
        [TestMethod]
        public void CanCreateMove_Test()
        {
            List<Input> commandList = new List<Input>()
            {
            };
            Move fireball = new Move(new CommandSequence(commandList), "Hadouken");

            Assert.IsInstanceOfType(fireball, typeof(Move));
            Assert.AreEqual(fireball.Name, "Hadouken");
        }
    }
}
