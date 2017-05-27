﻿namespace GameEngine.Managers
{
    public enum MenuState { MainMenu, PauseMainMenu, MainOptionsMenu, PauseOptionsMenu, None};
    public class MenuStateManager
    {
        static MenuStateManager instance;
        public MenuState State { get; set; }


        static MenuStateManager()
        {
            instance = new MenuStateManager();
        }

        public static MenuStateManager GetInstance()
        {
            return instance;
        }
        
        // MAIN MENU //

        // PLAY
        public static void MainPlay()
        {
            GetInstance().State = MenuState.None;
            GameStateManager.GetInstance().State = GameState.Game;
        }
        
        // OPTIONS
        public static void MainOptions()
        {
            GetInstance().State = MenuState.MainOptionsMenu;
            GameStateManager.GetInstance().State = GameState.Menu;
        }

        // QUIT
        public static void MainQuit()
        {
            GetInstance().State = MenuState.None;
            GameStateManager.GetInstance().State = GameState.Exit;
        }

        // MAIN OPTIONS MENU //

        // 1 PLAYER - TODO
        //public static void 1PlayerOption()
        //{
        //}

        // 2PLAYERS - TODO
        //public static void 2PlayersOption()
        //{
        //}

        // OPTIONS BACK
        public static void OptionsBack()
        {
            GetInstance().State = MenuState.MainMenu;
        }

        // PAUSE MENU //

        // RESUME
        public static void PauseResume()
        {
            GetInstance().State = MenuState.None;
            GameStateManager.GetInstance().State = GameState.Game;
        }

        // PAUSE QUIT - TODO
        public static void PauseQuit()
        {
            GetInstance().State = MenuState.MainMenu;
        }

    }
}