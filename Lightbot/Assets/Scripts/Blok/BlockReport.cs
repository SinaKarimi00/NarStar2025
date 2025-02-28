using UnityEngine;
using CharacterSystem;


namespace BlockSystem
{
    public class BlockReport
    {
        private readonly Robot robot;
        private readonly int raycastLength = 2;
        private RaycastHit raycastHit;
        private bool isHit;

        public BlockReport(Robot robot)
        {
            this.robot = robot;
        }

        public bool BlockValidation()
        {
            HitRaycast(robot.transform.forward);
            return isHit;
        }

        public string GetTagOfHittedBlock()
        {
            HitRaycast(Vector3.down);
            return raycastHit.collider.tag;
        }

        public bool IsChangeAbleBlock()
        {
            HitRaycast(Vector3.down);
            return raycastHit.collider.CompareTag("LampGround");
        }

        public GameObject GetHittedGameObject(string blockTag)
        {
            HitRaycast(Vector3.down);
            return raycastHit.collider.CompareTag(blockTag) ? raycastHit.collider.gameObject : null;
        }

        private void HitRaycast(Vector3 direction)
        {
            isHit = Physics.Raycast(robot.transform.position, direction, out raycastHit, raycastLength);
        }

    }
}