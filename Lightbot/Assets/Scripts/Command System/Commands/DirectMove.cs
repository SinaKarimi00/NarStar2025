using Animation_System;
using CharacterSystem;
using BlockSystem;
using DefaultNamespace.Level_System;
using UnityEngine.Scripting;


namespace CommandSystem
{
    [Preserve]
    public class DirectMove : AbstractCommand
    {
        private readonly BlockReport blockReport;

        public DirectMove(Robot robot, LevelConfig levelConfig) : base(robot, levelConfig)
        {
            blockReport = new BlockReport(this.robot);
        }

        public override void Execute()
        {
            serviceLocator.GetService<AnimationPlayer>().PlayAnimation(!blockReport.BlockValidation() ? "Move" : "JumpNormal");
        }
    }
}