using DefaultNamespace.Level_System;
using DefaultNamespace.TextureRepo;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace UI_System.Button_System.AbstractClass
{
    public abstract class ButtonBase
    {
        protected readonly GameObject canvas;
        protected readonly LevelConfig levelConfig;
        private const string LEVEL_CONFIG_ADDRESS_ROOT = "Level Configs";

        protected ButtonBase(GameObject canvas, string levelName)
        {
            this.canvas = canvas;
            levelConfig = Resources.Load<LevelConfig>($"{LEVEL_CONFIG_ADDRESS_ROOT}/{levelName}");
        }

        protected GameObject GetButtonPrefab()
        {
            string buttonPrefabAddress = "Prefabs/Levels/Button";
            return Resources.Load<GameObject>(buttonPrefabAddress);
        }

        protected void SetButtonName(GameObject button, string commandName)
        {
            button.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = commandName;
        }

        protected void SetButtonTexture(GameObject button, int id)
        {
            var textureRepo = Resources.Load<TextureRepo>("TextureRepo");
            var sprite = textureRepo.GetSprite(id);
            button.GetComponent<Image>().sprite = sprite;
        }
    }
}