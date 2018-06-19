// Copyright (c) Xenko contributors (https://xenko.com) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Xenko.Input
{
    /// <summary>
    /// Provides a virtual mouse and keyboard that generate input events like a normal mouse/keyboard when any of the functions (Simulate...) are called
    /// </summary>
    public class InputSourceSimulated : InputSourceBase
    {
        private List<GamePadSimulated> gamePads = new List<GamePadSimulated>();
        private List<MouseSimulated> mice = new List<MouseSimulated>();
        private List<KeyboardSimulated> keyboards = new List<KeyboardSimulated>();
        
        public IReadOnlyList<KeyboardSimulated> Keyboards => keyboards;
        public IReadOnlyList<MouseSimulated> Mice => mice;
        public IReadOnlyList<GamePadSimulated> GamePads => gamePads;
        
        public override void Initialize(InputManager inputManager)
        {
        }

        public override void Dispose()
        {
            base.Dispose();
            keyboards.Clear();
            mice.Clear();
            gamePads.Clear();
        }

        public GamePadSimulated AddGamePad()
        {
            var gamePad = new GamePadSimulated(this);
            gamePads.Add(gamePad);
            RegisterDevice(gamePad);
            return gamePad;
        }

        public void RemoveGamePad(GamePadSimulated gamePad)
        {
            if (!gamePads.Contains(gamePad))
                throw new InvalidOperationException("Simulated GamePad does not exist");
            UnregisterDevice(gamePad);
            gamePads.Remove(gamePad);
        }

        public void RemoveAllGamePads()
        {
            foreach (var gamePad in gamePads)
                UnregisterDevice(gamePad);
            gamePads.Clear();
        }

        public MouseSimulated AddMouse()
        {
            var mouse = new MouseSimulated(this);
            mice.Add(mouse);
            RegisterDevice(mouse);
            return mouse;
        }

        public void RemoveMouse(MouseSimulated mouse)
        {
            if (!mice.Contains(mouse))
                throw new InvalidOperationException("Simulated Mouse does not exist");
            UnregisterDevice(mouse);
            mice.Remove(mouse);
        }

        public void RemoveAllMice()
        {
            foreach (var mouse in mice)
                UnregisterDevice(mouse);
            mice.Clear();
        }

        public KeyboardSimulated AddKeyboard()
        {
            var keyboard = new KeyboardSimulated(this);
            keyboards.Add(keyboard);
            RegisterDevice(keyboard);
            return keyboard;
        }

        public void RemoveKeyboard(KeyboardSimulated keyboard)
        {
            if (!keyboards.Contains(keyboard))
                throw new InvalidOperationException("Simulated Keyboard does not exist");
            UnregisterDevice(keyboard);
            keyboards.Remove(keyboard);
        }

        public void RemoveAllKeyboards()
        {
            foreach (var keyboard in keyboards)
                UnregisterDevice(keyboard);
            keyboards.Clear();
        }

        private enum DeviceEventType
        {
            Add,
            Remove
        }
    }
}
