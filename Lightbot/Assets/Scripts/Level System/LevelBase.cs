using System;
using CharacterSystem;
using DefaultNamespace;
using DefaultNamespace.Character_System;
using DefaultNamespace.Level_System;
using UnityEngine;


namespace Level_System
{
    public abstract class LevelBase
    {
        protected readonly Robot robot;
        protected readonly CommandPlayer commandPlayer;
        protected readonly Action initializeLevelUi;
        protected GameObject levelGameObject;
        protected readonly GameObject robotGameObject;
        private const string LEVEL_CONFIG_ADDRESS_ROOT = "Level Configs";
        protected const string LEVEL_PREFAB_ROOT_ADDRESS = "Prefabs/Levels";

        protected LevelBase(string levelName, Action initializeLevelUi)
        {
            LevelConfig levelConfig = Resources.Load<LevelConfig>(LEVEL_CONFIG_ADDRESS_ROOT + $"/{levelName}");
            RobotController robotController = new RobotController();
            robotGameObject = robotController.CreateCharacter();
            robot = robotController.RobotComponent;
            commandPlayer = new CommandPlayer(robot.GetComponent<Animator>(), levelConfig);
            this.initializeLevelUi = initializeLevelUi;
        }
    }
}