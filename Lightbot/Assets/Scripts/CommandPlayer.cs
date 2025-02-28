using System.Collections.Generic;
using System.Threading.Tasks;
using CommandSystem;
using DefaultNamespace.Level_System;
using UnityEngine;


namespace DefaultNamespace
{
    public class CommandPlayer
    {
        private readonly Animator animator;
        private readonly LevelConfig levelConfig;

        public CommandPlayer(Animator animator, LevelConfig levelConfig)
        {
            this.animator = animator;
            this.levelConfig = levelConfig;
        }


        public async void Play()
        {
            List<ICommand> selectedCommands = new List<ICommand>();
            selectedCommands.AddRange(levelConfig.SelectedCommands);
            foreach (var command in selectedCommands)
            {
                command.Execute();
                await Task.Delay(500);
                await WaitForAnimationToFinish(animator);
            }

            if (levelConfig.turnedOnLightblokNumber == levelConfig.neededLightblokNumber)
            {
                var gameObject = Resources.Load<GameObject>("WinCanvas");
                Object.Instantiate(gameObject);
            }
        }

        private async Task WaitForAnimationToFinish(Animator animator)
        {
            while (animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1)
            {
                await Task.Delay(5);
            }
        }
    }
}