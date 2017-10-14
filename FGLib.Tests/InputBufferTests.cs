using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FGLib.CharacterData;

namespace FGLib.Tests
{
    /// <summary>
    /// Summary description for InputBufferTests
    /// </summary>
    [TestClass]
    public class InputBufferTests
    {
        Character ryu;
        PlayerInfo player;
        InputBuffer buffer;
            
        [TestInitialize]
        public void SetUp()
        {
            ryu = new Character("Ryu", Ryu.GetMoveList());
            player = new PlayerInfo(1, ryu);
            buffer = new InputBuffer(player, 100);
        }

        [TestMethod]
        public void CanCreateInputBuffer_Test()
        {
            Assert.IsInstanceOfType(buffer, typeof(InputBuffer));
            Assert.AreEqual(buffer.Size, 100);
        }

        [TestMethod]
        public void CanResolveValidInput_Test()
        {          
            Move executedMove = null;
            List<ConsoleKey> inputs = new List<ConsoleKey>()
            {
                ConsoleKey.LeftArrow,
                ConsoleKey.RightArrow,
                ConsoleKey.DownArrow,
                ConsoleKey.RightArrow,
                ConsoleKey.P
            };

            foreach(ConsoleKey key in inputs)
            {
                executedMove = buffer.AddAndResolveInput(key);
            }

            Assert.IsNotNull(executedMove);
            Assert.AreEqual("Hadouken", executedMove.Name);
        }

        [TestMethod]
        public void CannotResolveInvalidInput_Test()
        {
            Move executedMove = null;
            List<ConsoleKey> inputs = new List<ConsoleKey>()
            {
                ConsoleKey.A,
                ConsoleKey.R,
                ConsoleKey.Spacebar,
                ConsoleKey.DownArrow,
                ConsoleKey.P
            };

            foreach (ConsoleKey key in inputs)
            {
                executedMove = buffer.AddAndResolveInput(key);
            }

            Assert.IsNull(executedMove);
        }
    }
}
