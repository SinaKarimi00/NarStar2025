using System;
using UI_System.Button_System.AbstractClass;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;


namespace UI_System.Button_System
{
    public class FixedLevelButton : ButtonBase
    {
        private readonly Action playCommands;

        public FixedLevelButton(GameObject canvas, string levelName, Action playCommands) : base(canvas, levelName)
        {
            this.playCommands = playCommands;
        }

        public void CreateFixedButton(string buttonName, string functionName)
        {
            GameObject buttonGameObject = Object.Instantiate(GetButtonPrefab(), canvas.transform.GetChild(0), true);
            if (buttonGameObject == null)
                return;
            FixedLevelButtonListener fixedLevelButtonListener = new FixedLevelButtonListener(canvas, levelConfig, playCommands);
            buttonGameObject.GetComponent<Button>().onClick.AddListener(() => fixedLevelButtonListener.GetFunction(functionName, typeof(FixedLevelButtonListener)).Invoke());
            SetButtonName(buttonGameObject, buttonName);
        }
    }
}