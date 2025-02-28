using System.Collections.Generic;
using CommandSystem;
using UnityEngine;


namespace DefaultNamespace.Level_System
{
    [CreateAssetMenu(fileName = "New Level", menuName = "Level config")]
    public class LevelConfig : ScriptableObject
    {
        public int maxCommands;
        public List<ICommand> SelectedCommands => selectedCommands;
        public List<int> MaterialID => materialID;
        public List<string> fullNameOfNeededCommands = new List<string>();
        public string levelName;
        public int neededLightblokNumber;
        public int turnedOnLightblokNumber;
        private readonly List<ICommand> selectedCommands = new List<ICommand>();
        [SerializeField] private List<int> materialID = new List<int>();
    }
}