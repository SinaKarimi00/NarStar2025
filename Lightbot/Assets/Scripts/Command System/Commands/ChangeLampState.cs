using Animation_System;
using CharacterSystem;
using BlockSystem;
using DefaultNamespace.Level_System;
using UnityEngine;
using UnityEngine.Scripting;


namespace CommandSystem
{
    [Preserve]
    public class ChangeLampState : AbstractCommand
    {
        private readonly BlockReport blockReport;

        public ChangeLampState(Robot robot, LevelConfig levelConfig) : base(robot, levelConfig)
        {
            blockReport = new BlockReport(this.robot);
        }

        public override void Execute()
        {
            if (blockReport.IsChangeAbleBlock())
                ChangeBlockMaterial();
            else
                serviceLocator.GetService<AnimationPlayer>().PlayAnimation("ChangeLampState");
        }

        private void ChangeBlockMaterial()
        {
            serviceLocator.GetService<AnimationPlayer>().PlayAnimation("ChangeLampState");
            Color blockColor = blockReport.GetHittedGameObject(blockTag: "LampGround").GetComponent<Renderer>().material.color;
            blockColor = blockColor == Color.yellow ? Color.red : Color.yellow;
            if (blockColor == Color.yellow)
            {
                levelConfig.turnedOnLightblokNumber++;
            }
            else
            {
                levelConfig.turnedOnLightblokNumber--;
            }
            blockReport.GetHittedGameObject(blockTag: "LampGround").GetComponent<Renderer>().material.color = blockColor;
        }

    }
}