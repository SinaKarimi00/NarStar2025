using Animation_System;
using CharacterSystem;
using BlockSystem;
using DefaultNamespace.Level_System;
using DefaultNamespace.TextureRepo;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Scripting;


namespace CommandSystem
{
    [Preserve]
    public class DirectMove : AbstractCommand
    {
        private readonly BlockReport blockReport;
        private readonly int _id;

        public DirectMove(Robot robot, LevelConfig levelConfig, int id) : base(robot, levelConfig, id)
        {
            blockReport = new BlockReport(this.robot);
            _id = id;
        }

        public override void Execute()
        {
            serviceLocator.GetService<AnimationPlayer>()
                .PlayAnimation(!blockReport.BlockValidation() ? "Move" : "JumpNormal");
            ChangeBlockMaterial();
        }

        private void ChangeBlockMaterial()
        {
            var textureRepo = Resources.Load<TextureRepo>("TextureRepo");
            serviceLocator.GetService<AnimationPlayer>().PlayAnimation("ChangeLampState");
            // Color blockColor = blockReport.GetHittedGameObject(blockTag: "LampGround").GetComponent<Renderer>().material
            //     .color;
            // blockColor = blockColor == Color.yellow ? Color.red : Color.yellow;
            // var material = textureRepo.GetMaterial(_id);

            if (blockReport.GetHittedGameObject(blockTag: "LampGround"))
            {
                if (blockReport.GetHittedGameObject(blockTag: "LampGround").transform.Find("Top/GameObject").GetComponent<SpriteRenderer>().enabled)
                {
                    blockReport.GetHittedGameObject(blockTag: "LampGround").transform.Find("Top/GameObject").GetComponent<SpriteRenderer>().enabled =
                        false;
                    levelConfig.turnedOnLightblokNumber++;
                }
                else
                {
                    // levelConfig.turnedOnLightblokNumber--;
                }

                // blockReport.GetHittedGameObject(blockTag: "LampGround").GetComponent<Renderer>().material = material;
            }


            // blockReport.GetHittedGameObject(blockTag: "LampGround").GetComponent<Renderer>().material.color =
            //     blockColor;
        }
    }
}