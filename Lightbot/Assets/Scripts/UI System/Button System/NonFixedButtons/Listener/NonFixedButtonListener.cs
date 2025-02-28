using System;
using System.Linq;
using CharacterSystem;
using CommandSystem;
using DefaultNamespace.Level_System;
using DefaultNamespace.TextureRepo;
using TMPro;
using UI_System.Button_System.AbstractClass;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;


namespace UI_System.Button_System
{
    public class NonFixedButtonListener : ButtonListener
    {
        private readonly LevelConfig levelConfig;

        public NonFixedButtonListener(Robot robot, LevelConfig levelConfig) : base(robot)
        {
            this.levelConfig = levelConfig;
        }

        public void SetCommandListener(string commandName, int id, GameObject canvas)
        {
            if (levelConfig.SelectedCommands.Count >= levelConfig.maxCommands)
            {
                return;
            }

            levelConfig.SelectedCommands.Add((ICommand)Activator.CreateInstance(
                Type.GetType(commandName) ?? throw new InvalidOperationException(), robot, levelConfig, id));

            var button = Resources.Load<GameObject>("Prefabs/Levels/Button2");
            var newButton = Object.Instantiate(button, canvas.transform.Find("UI/SelectedCommands"));
            newButton.GetComponentInChildren<Button>().interactable = false;
            // SetButtonName(button, commandName);
            SetButtonTexture(button, id);
        }


        private GameObject GetButtonPrefab()
        {
            string buttonPrefabAddress = "Prefabs/Levels/Button";
            return Resources.Load<GameObject>(buttonPrefabAddress);
        }

        private void SetButtonName(GameObject button, string commandName)
        {
            button.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = commandName;
        }

        private void SetButtonTexture(GameObject button, int id)
        {
            var textureRepo = Resources.Load<TextureRepo>("TextureRepo");
            var sprite = textureRepo.GetSprite(id);
            button.GetComponent<Image>().sprite = sprite;
        }
    }
}