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
            GameObject buttonGameObject =
                Object.Instantiate(GetButtonPrefab(), canvas.transform.Find("UI/Commands/Viewport/Content"));
            if (buttonGameObject == null)
                return;
            FixedLevelButtonListener fixedLevelButtonListener =
                new FixedLevelButtonListener(canvas, levelConfig, playCommands);
            buttonGameObject.GetComponent<Button>().onClick.AddListener(() =>
            {
                fixedLevelButtonListener.GetFunction(functionName, typeof(FixedLevelButtonListener)).Invoke();
                var contentTransform = canvas.transform.Find("UI/SelectedCommands");
                var childCount = contentTransform.childCount;
                if (childCount >= 1)
                {
                    for (int i = 0; i < childCount; i++)
                    {
                        Object.Destroy(contentTransform.transform.GetChild(i).gameObject);
                    }
                }
            });
            SetButtonName(buttonGameObject, buttonName);
        }
    }
}