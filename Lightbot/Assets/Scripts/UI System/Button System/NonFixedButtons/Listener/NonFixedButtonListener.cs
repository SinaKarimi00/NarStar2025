using System;
using CharacterSystem;
using CommandSystem;
using DefaultNamespace.Level_System;
using UI_System.Button_System.AbstractClass;


namespace UI_System.Button_System
{
    public class NonFixedButtonListener : ButtonListener
    {
        private readonly LevelConfig levelConfig;

        public NonFixedButtonListener(Robot robot, LevelConfig levelConfig) : base(robot)
        {
            this.levelConfig = levelConfig;
        }

        public void SetCommandListener(string commandName)
        {
            levelConfig.SelectedCommands.Add((ICommand) Activator.CreateInstance(Type.GetType(commandName) ?? throw new InvalidOperationException(), robot, levelConfig));
        }
    }
}