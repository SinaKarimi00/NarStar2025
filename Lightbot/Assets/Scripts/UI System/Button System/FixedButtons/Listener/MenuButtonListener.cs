using System;
using UI_System.Button_System.FixedButtons.Listener;
using UnityEngine;
using UnityEngine.Scripting;
using Object = UnityEngine.Object;


namespace UI_System.Button_System.AbstractClass
{
    public class MenuButtonListener : ListenerBase
    {
        public MenuButtonListener(GameObject canvas, Action onStartGameClicked) : base(canvas, onStartGameClicked)
        {
        }

        [Preserve]
        public void StartGameButton()
        {
            Object.Destroy(canvas);
            onStartGameClicked.Invoke();
        }

        [Preserve]
        public void NextLevel()
        {
            PlayerPrefs.SetInt("LevelNumber", PlayerPrefs.GetInt("LevelNumber") + 1);
            Object.Destroy(canvas);
            onStartGameClicked.Invoke(); // TODO: Fix this
        }
    }
}