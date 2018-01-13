using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FGLib.InputHandling;

namespace FGLib.Tests
{
    [TestClass]
    public class InputManagerTests
    {
        [TestMethod]
        public void CanConstruct_Test()
        {
            InputManager<ConsoleKey> cKeyManager = new InputManager<ConsoleKey>();
            Assert.IsInstanceOfType(cKeyManager, typeof(InputManager<ConsoleKey>));
        }

        [TestMethod]
        public void thing_test()
        {
            InputManager<ConsoleKey> cKeyManager = new InputManager<ConsoleKey>();

            List<ConsoleKey> rawInputs = new List<ConsoleKey>()
            {
                ConsoleKey.LeftArrow,
                ConsoleKey.RightArrow,
                ConsoleKey.DownArrow,
                ConsoleKey.RightArrow,
                ConsoleKey.NumPad6,
                ConsoleKey.NumPad3
            };
            
            cKeyManager.ReceiveInputsForFrame(rawInputs);
        }
    }
}
