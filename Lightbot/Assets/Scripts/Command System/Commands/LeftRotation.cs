using Animation_System;
using CharacterSystem;
using DefaultNamespace.Level_System;
using UnityEngine.Scripting;


namespace CommandSystem
{
    [Preserve]
    public class LeftRotation : AbstractCommand
    {

        public LeftRotation(Robot robot, LevelConfig levelConfig, int id) : base(robot, levelConfig, id)
        {
        }

        public override void Execute() => serviceLocator.GetService<AnimationPlayer>().PlayAnimation("TurnLeft");
    }
}