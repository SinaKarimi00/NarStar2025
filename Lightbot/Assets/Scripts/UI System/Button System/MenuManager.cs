using System;
using UI_System.Button_System;
using UnityEngine;


namespace UI_System
{
    public class MenuManager
    {
        public MenuManager(GameObject canvas, Action onStartGameRequested)
        {
            ManageButtons();

            void ManageButtons()
            {
                FixedMenuButton fixedMenuButton = new FixedMenuButton(canvas, "Level1");
                fixedMenuButton.CreateFixedButton("PlayGame", "StartGameButton", onStartGameRequested);
            }
        }
    }
}