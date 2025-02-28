using System.Collections.Generic;
using CommandSystem;
using UnityEngine;


namespace DefaultNamespace.Level_System
{
    [CreateAssetMenu(fileName = "New Level", menuName = "Level config")]
    public class LevelConfig : ScriptableObject
    {
        public List<ICommand> SelectedCommands => selectedCommands;
        public List<string> fullNameOfNeededCommands = new List<string>();
        public string levelName;
        public int neededLightblokNumber;
        public int turnedOnLightblokNumber;
        private readonly List<ICommand> selectedCommands = new List<ICommand>();

    }
}