using System.Collections.Generic;
using CommandSystem;
using UnityEngine;


namespace SaveLoadSystem
{
    public class SaveCommand
    {
        public static void SaveData(List<ICommand> commandList)
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.SetInt("CommandCount", commandList.Count);
            for (int commandNumber = 0; commandNumber < commandList.Count; commandNumber++)
                PlayerPrefs.SetString("Command " + commandNumber, commandList[commandNumber].GetType().ToString());
        }
    }
}