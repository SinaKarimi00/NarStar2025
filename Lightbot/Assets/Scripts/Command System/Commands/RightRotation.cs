using Animation_System;
using CharacterSystem;
using DefaultNamespace.Level_System;
using UnityEngine.Scripting;


namespace CommandSystem
{
    [Preserve]
    public class RightRotation : AbstractCommand
    {
        public RightRotation(Robot robot, LevelConfig levelConfig) : base(robot,levelConfig)
        {
        }

        public override void Execute()
        {
            serviceLocator.GetService<AnimationPlayer>().PlayAnimation("TurnRight");
        }
    }
}