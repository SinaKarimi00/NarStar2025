using Animation_System;
using CharacterSystem;
using BlockSystem;
using DefaultNamespace.Level_System;
using UnityEngine.Scripting;


namespace CommandSystem
{
    [Preserve]
    public class Jump : AbstractCommand
    {
        private readonly BlockReport blockReport;

        public Jump(Robot robot, LevelConfig levelConfig) : base(robot, levelConfig)
        {
            blockReport = new BlockReport(this.robot);
        }

        public override void Execute()
        {
            if (blockReport.GetTagOfHittedBlock() == "JumpUpBlock" && blockReport.BlockValidation())
                serviceLocator.GetService<AnimationPlayer>().PlayAnimation("JumpUp");
            else if (blockReport.GetTagOfHittedBlock() == "JumpDownBlock")
                serviceLocator.GetService<AnimationPlayer>().PlayAnimation("JumpDown");
            else
                serviceLocator.GetService<AnimationPlayer>().PlayAnimation("JumpNormal");
        }
    }
}