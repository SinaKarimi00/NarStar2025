using Service_Locator;
using UnityEngine;


namespace Animation_System
{
    public class AnimationPlayer : IAnimationService
    {
        private readonly Animator animator;
        public AnimationPlayer(Animator animator)
        {
            this.animator = animator;
        }

        public void PlayAnimation(string stateName)
        {
            animator.SetTrigger(stateName);
        }
    }
}