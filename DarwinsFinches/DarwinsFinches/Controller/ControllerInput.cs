using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;


namespace DarwinsFinches
{
    class ControllerInput
    {
        static ControllerInput input;
        Dictionary<Keys, Button> KeyboardButtons;
        Dictionary<Buttons, Button> ButtonsButtons;

        ControllerInput() {
            KeyboardButtons = new Dictionary<Keys, Button>();
            AddKey(Keys.A);
            AddKey(Keys.B);
            AddKey(Keys.Up);
            AddKey(Keys.Down);
            AddKey(Keys.Left);
            AddKey(Keys.Right);
            AddKey(Keys.X);
            AddKey(Keys.Z);
            AddKey(Keys.Space);

            ButtonsButtons = new Dictionary<Buttons, Button>();
            AddButton(Buttons.A);
            AddButton(Buttons.B);
            AddButton(Buttons.X);
            AddButton(Buttons.Y);
            AddButton(Buttons.LeftShoulder);
            AddButton(Buttons.RightShoulder);
            AddButton(Buttons.LeftTrigger);
            AddButton(Buttons.RightTrigger);
        }

        public static ControllerInput Instance() {
            if (input == null) {
                input = new ControllerInput();
            }
            return input;
        }

        public void Update() {
            foreach (KeyValuePair<Buttons, Button> button in ButtonsButtons)
            {
                button.Value.Update();
            }
            foreach (KeyValuePair<Keys, Button> button in KeyboardButtons)
            {
                button.Value.Update();
            }
        }

        void AddButton(Buttons Button)
        {
            if (!ButtonsButtons.ContainsKey(Button))
            {
                ButtonsButtons[Button] = new Button(Button);
            }
        }

        void AddKey(Keys Key)
        {
            if(!KeyboardButtons.ContainsKey(Key)){
            KeyboardButtons[Key] = new Button(Key);
            }
        }

        public Button GetButton(Buttons Button) {
            return ButtonsButtons[Button];
        }

        public Button GetKey(Keys Button)
        {
            return KeyboardButtons[Button];
        }

        public GamePadThumbSticks Sticks
        {
            get { return GamePad.GetState(PlayerIndex.One).ThumbSticks; }
        }

        public GamePadTriggers Triggers
        {
            get { return GamePad.GetState(PlayerIndex.One).Triggers; }
        }
    }
}
