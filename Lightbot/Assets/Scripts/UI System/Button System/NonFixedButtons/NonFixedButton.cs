using System;
using CharacterSystem;
using UI_System.Button_System.AbstractClass;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;


namespace UI_System.Button_System
{
    public class NonFixedButton : ButtonBase
    {
        public NonFixedButton(GameObject canvas, string levelName) : base(canvas, levelName)
        {
        }

        public void CreateNonFixedButtons(Robot robot)
        {
            foreach (string item in levelConfig.fullNameOfNeededCommands)
            {
                NonFixedButtonListener nonFixedButtonListener = new NonFixedButtonListener(robot, levelConfig);
                GameObject newButton = Object.Instantiate(GetButtonPrefab(), canvas.transform.GetChild(0), true);
                if (newButton == null)
                    continue;
                newButton.GetComponent<Button>().onClick.AddListener(() => nonFixedButtonListener.SetCommandListener(item));
                SetButtonName(newButton, Type.GetType(item)?.Name);
            }
        }
    }
}