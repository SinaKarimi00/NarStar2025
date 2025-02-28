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
            return raycastHit.collider.transform.parent.tag;
        }

        public bool IsChangeAbleBlock()
        {
            HitRaycast(Vector3.down);
            return raycastHit.collider.transform.parent.CompareTag("LampGround");
        }

        public GameObject GetHittedGameObject(string blockTag)
        {
            HitRaycast(Vector3.down);
            return raycastHit.collider.transform.parent.CompareTag(blockTag) ? raycastHit.collider.gameObject : null;
        }

        private void HitRaycast(Vector3 direction)
        {
            // direction = new Vector3(0, -100, 0);
            Debug.DrawRay(robot.transform.position, direction,Color.blue,5f);
            isHit = Physics.Raycast(robot.transform.position, direction, out raycastHit, raycastLength);
        }

    }
}