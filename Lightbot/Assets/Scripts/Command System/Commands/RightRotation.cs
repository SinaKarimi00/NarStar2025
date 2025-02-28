using Animation_System;
using CharacterSystem;
using DefaultNamespace.Level_System;
using UnityEngine.Scripting;


namespace CommandSystem
{
    [Preserve]
    public class RightRotation : AbstractCommand
    {
        public RightRotation(Robot robot, LevelConfig levelConfig, int id) : base(robot, levelConfig, id)
        {
        }

        public override void Execute()
        {
            serviceLocator.GetService<AnimationPlayer>().PlayAnimation("TurnRight");
        }
    }
}