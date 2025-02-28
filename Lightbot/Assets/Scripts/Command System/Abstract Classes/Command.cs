using Animation_System;
using CharacterSystem;
using DefaultNamespace.Level_System;
using Service_Locator;
using UnityEngine;


namespace CommandSystem
{
    public abstract class AbstractCommand : ICommand
    {
        protected readonly Robot robot;
        protected readonly LevelConfig levelConfig;
        protected readonly IServiceLocator serviceLocator = new ServiceLocator();

        protected AbstractCommand(Robot robot, LevelConfig levelConfig, int id)
        {
            this.robot = robot;
            this.levelConfig = levelConfig;
            serviceLocator.RegisterService(new AnimationPlayer(this.robot.GetComponent<Animator>()));
        }

        public abstract void Execute();
    }
}