using Animation_System;
using CharacterSystem;
using BlockSystem;
using DefaultNamespace.Level_System;
using DefaultNamespace.TextureRepo;
using UnityEngine;
using UnityEngine.Scripting;


namespace CommandSystem
{
    [Preserve]
    public class ChangeLampState : AbstractCommand
    {
        private readonly BlockReport blockReport;
        private readonly int _id;

        public ChangeLampState(Robot robot, LevelConfig levelConfig, int id) : base(robot, levelConfig, id)
        {
            blockReport = new BlockReport(this.robot);
            _id = id;
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
            var textureRepo = Resources.Load<TextureRepo>("TextureRepo");
            serviceLocator.GetService<AnimationPlayer>().PlayAnimation("ChangeLampState");
            // Color blockColor = blockReport.GetHittedGameObject(blockTag: "LampGround").GetComponent<Renderer>().material
            //     .color;
            // blockColor = blockColor == Color.yellow ? Color.red : Color.yellow;
            var material = textureRepo.GetMaterial(_id);
            if (blockReport.GetHittedGameObject(blockTag: "LampGround").GetComponent<Renderer>().material == material)
            {
                levelConfig.turnedOnLightblokNumber++;
            }
            else
            {
                levelConfig.turnedOnLightblokNumber--;
            }

            // blockReport.GetHittedGameObject(blockTag: "LampGround").GetComponent<Renderer>().material.color =
            //     blockColor;
            blockReport.GetHittedGameObject(blockTag: "LampGround").GetComponent<Renderer>().material = material;
        }
    }
}