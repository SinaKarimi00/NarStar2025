using System;
using UI_System.Button_System.AbstractClass;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;


namespace UI_System.Button_System
{
    public class FixedMenuButton : ButtonBase
    {
        public FixedMenuButton(GameObject canvas, string levelName) : base(canvas, levelName)
        {
        }

        public void CreateFixedButton(string buttonName, string functionName, Action onStartGameClicked)
        {
            GameObject buttonGameObject = Object.Instantiate(GetButtonPrefab(), canvas.transform.GetChild(0), true);
            if (buttonGameObject == null)
                return;
            MenuButtonListener fixedButtonListener = new MenuButtonListener(canvas, onStartGameClicked);
            buttonGameObject.GetComponent<Button>().onClick.AddListener(() => fixedButtonListener.GetFunction(functionName, typeof(MenuButtonListener)).Invoke());
            SetButtonName(buttonGameObject, buttonName);
        }
    }
}