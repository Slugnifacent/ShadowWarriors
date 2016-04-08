using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace DarwinsFinches
{
    class Button
    {
        delegate void UPDATE();
        UPDATE update;

        Buttons button;
        Keys key;
        

        bool justPressed;
        bool justReleased;
        bool held;

        public Button(Keys Key)
        {
            update = KeyUpdate;
            key = Key;
        }

        public Button(Buttons Butt)
        {
            update = ButtonUpdate;
            button = Butt;
        }

        public void Update()
        {
            justPressed = false;
            justReleased = false;
            update();
        }


        void KeyUpdate()
        {
            if (Keyboard.GetState().IsKeyDown(key) && !held)
            {
                if (justPressed == false) {
                    justPressed = true;
                }
                held = true;
            }

            if (Keyboard.GetState().IsKeyUp(key))
            {
                if (held)
                {
                    justReleased = true;
                }
                held = false;
            }
           
        }


        void ButtonUpdate()
        {
            if (GamePad.GetState(PlayerIndex.One).IsButtonDown(button) && !held)
            {
                if (justPressed == false)
                {
                    justPressed = true;
                }
                held = true;
            }

            if (GamePad.GetState(PlayerIndex.One).IsButtonUp(button))
            {
                if (held)
                {
                    justReleased = true;
                }
                held = false;
            }
        }


        public bool Held
        { 
            get{return held;}
        }

        public bool Pressed
        {
            get { return justPressed; }
        }

        public bool Released
        {
            get { return justReleased; }
        }




    }
}
