using System;
using DefaultNamespace.Level_System;
using SaveLoadSystem;
using UI_System.Button_System.FixedButtons.Listener;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Scripting;
using Object = UnityEngine.Object;


namespace UI_System.Button_System
{
    public class FixedLevelButtonListener : ListenerBase
    {
        private readonly LevelConfig levelConfig;

        public FixedLevelButtonListener(GameObject canvas, LevelConfig levelConfig, Action buttonAction) : base(canvas, buttonAction)
        {
            this.levelConfig = levelConfig;
        }

        [Preserve]
        public void PlayButton()
        {
            onStartGameClicked.Invoke();
        }

        [Preserve]
        public void ResetGame()
        {
            levelConfig.SelectedCommands.Clear();
        }

        [Preserve]
        public void NextGame()
        {
            if (levelConfig.neededLightblokNumber == levelConfig.turnedOnLightblokNumber)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                onStartGameClicked();
            }
        }

        [Preserve]
        public void SaveGame() => SaveCommand.SaveData(levelConfig.SelectedCommands);

        //[Preserve]
        //public void LoadGame() => LoadCommand.LoadData(robot, levelConfig);

    }
}