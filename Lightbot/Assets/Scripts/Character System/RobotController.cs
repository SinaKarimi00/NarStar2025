using CharacterSystem;
using DefaultNamespace.Controllers;
using UnityEngine;


namespace DefaultNamespace.Character_System
{
    public class RobotController : IControllers
    {
        private const string CHARACTER_PREFAB_ROOT_ADDRESS = "Prefabs/Character";
        private Robot robotComponent;
        public Robot RobotComponent => robotComponent;

        public GameObject CreateCharacter()
        {
            GameObject characterPrefab = Resources.Load<GameObject>(CHARACTER_PREFAB_ROOT_ADDRESS + "/Robot");
            GameObject robotCharacter = Object.Instantiate(characterPrefab);
            robotComponent = robotCharacter.GetComponent<Robot>();
            return robotCharacter;
        }
    }
}