using System;
using CharacterSystem;
using TMPro;
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
            // foreach (string item in levelConfig.fullNameOfNeededCommands)
            // {
            //     NonFixedButtonListener nonFixedButtonListener = new NonFixedButtonListener(robot, levelConfig);
            //     GameObject newButton = Object.Instantiate(GetButtonPrefab(), canvas.transform.GetChild(0), true);
            //     if (newButton == null)
            //         continue;
            //     newButton.GetComponent<Button>().onClick
            //         .AddListener(() => nonFixedButtonListener.SetCommandListener(item));
            //     SetButtonName(newButton, Type.GetType(item)?.Name);
            //     SetButtonTexture();
            // }

            for (int i = 0; i < levelConfig.fullNameOfNeededCommands.Count; i++)
            {
                string item = levelConfig.fullNameOfNeededCommands[i];
                NonFixedButtonListener nonFixedButtonListener =
                    new NonFixedButtonListener(robot, levelConfig);
                var button = Resources.Load<GameObject>("Prefabs/Levels/Button2");
                GameObject newButton = Object.Instantiate(button,
                    canvas.transform.Find("UI/Commands/Viewport/Content"));
                if (newButton == null)
                    continue;

                int materialId = (i < levelConfig.MaterialID.Count) ? levelConfig.MaterialID[i] : -1;

                newButton.GetComponent<Button>().onClick
                    .AddListener(() => nonFixedButtonListener.SetCommandListener(item, materialId, canvas));

                // SetButtonName(newButton, Type.GetType(item)?.Name);

                if (materialId != -1)
                {
                    SetButtonTexture(newButton, materialId);
                }
            }
        }
    }
}