using System;
using System.Collections.Generic;
using System.Linq;
using CharacterSystem;
using CommandSystem;
using DefaultNamespace.Level_System;
using UnityEngine;


namespace SaveLoadSystem
{
    public class LoadCommand
    {
        private static readonly List<Type> CommandsType = new List<Type>();
        private static int count;

        public static void LoadData(Robot robot, LevelConfig levelConfig)
        {
            levelConfig.SelectedCommands.Clear();
            FindCommandsType();
            foreach (ICommand command in CommandsType.Select(item => (ICommand) Activator.CreateInstance(item, new object[] {robot})))
            {
                levelConfig.SelectedCommands.Add(command);
            }
        }

        private static void FindCommandsType()
        {
            MakeListReady();
            for (int commandNumber = 0; commandNumber < count; commandNumber++)
                CommandsType.Add(Type.GetType(PlayerPrefs.GetString("Command " + commandNumber)));
        }

        private static void MakeListReady()
        {
            CommandsType.Clear();
            count = PlayerPrefs.GetInt("CommandCount");
        }
    }
}