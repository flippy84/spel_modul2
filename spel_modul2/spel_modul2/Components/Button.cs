﻿namespace GameEngine
{
    public class Button
    {
        private bool isDown;
        public Button()
        {
            isDown = false;
        }

        public bool IsButtonDown()
        {
            return isDown;
        }

        public bool IsButtonUp()
        {
            return !isDown;
        }

        public void SetButton(bool isDown)
        {
            this.isDown = isDown;
        }

    }
}
