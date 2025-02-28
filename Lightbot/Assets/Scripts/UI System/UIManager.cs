using DefaultNamespace.Controllers;
using LightBot.UI_System;
using UI_System;
using UnityEngine;
using Object = UnityEngine.Object;


namespace DefaultNamespace.UI_System
{
    public class UIManager : IControllers
    {
        private const string CANVAS_PREFAB_ADDRESS_ROOT = "Prefabs/Levels";
        private GameObject canvas;

        public void InitializeMenuUi()
        {
            CreateCanvas();
            new MenuManager(canvas,
                onStartGameRequested: InitializeLevelUi /*, onNextLevelRequested: InitializeLevelUi*/);
        }

        private void CreateCanvas()
        {
            canvas = Object.Instantiate(GetCanvasPrefab());
        }

        private void InitializeLevelUi()
        {
            CreateCanvas();
            string levelName = $"Level{PlayerPrefs.GetInt("LevelNumber", 1)}";
            LevelManager levelManager = new LevelManager(levelName, InitializeLevelUi);
            levelManager.ManageButtons(canvas, levelName);
        }


        private GameObject GetCanvasPrefab()
        {
            string canvasPath = $"{CANVAS_PREFAB_ADDRESS_ROOT}/Canvas";
            return Resources.Load<GameObject>(canvasPath);
        }
    }
}