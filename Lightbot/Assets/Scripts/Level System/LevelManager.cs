using System;
using Level_System;
using UI_System.Button_System;
using UnityEngine;
using Object = UnityEngine.Object;


namespace LightBot.UI_System
{
    public class LevelManager : LevelBase
    {
        public LevelManager(string levelName, Action initializeLevelUi) : base(levelName, initializeLevelUi)
        {
            CreatLevel(levelName);
        }

        private void CreatLevel(string levelName)
        {
            GameObject levelPrefab = Resources.Load<GameObject>(LEVEL_PREFAB_ROOT_ADDRESS + $"/{levelName}");
            levelGameObject = Object.Instantiate(levelPrefab);
        }

        private void InitializeNextLevel()
        {
            Object.Destroy(levelGameObject);
            Object.Destroy(robotGameObject);
            initializeLevelUi.Invoke();
        }

        public void ManageButtons(GameObject canvas, string levelName)
        {
            FixedLevelButton fixedLevelButton = new FixedLevelButton(canvas, levelName, commandPlayer.Play);
            fixedLevelButton.CreateFixedButton("Play", "PlayButton");
            fixedLevelButton.CreateFixedButton("Reset", "ResetGame");
            fixedLevelButton.CreateFixedButton("Save", "SaveGame");
            fixedLevelButton.CreateFixedButton("Load", "LoadGame");
            FixedMenuButton fixedMenuButton = new FixedMenuButton(canvas, levelName);
            fixedMenuButton.CreateFixedButton("Next Level", "NextLevel", InitializeNextLevel);
            NonFixedButton nonFixedButton = new NonFixedButton(canvas, levelName);
            nonFixedButton.CreateNonFixedButtons(robot);
        }
    }
}