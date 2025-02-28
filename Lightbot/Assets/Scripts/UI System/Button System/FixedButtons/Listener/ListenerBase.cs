using System;
using System.Reflection;
using UnityEngine;


namespace UI_System.Button_System.FixedButtons.Listener
{
    public abstract class ListenerBase
    {
        protected readonly GameObject canvas;
        protected readonly Action onStartGameClicked;

        protected ListenerBase(GameObject canvas, Action onStartGameClicked)
        {
            this.canvas = canvas;
            this.onStartGameClicked = onStartGameClicked;
        }

        public Action GetFunction(string functionName, Type classType)
        {
            MethodInfo methodInfo = classType.GetMethod(functionName);
            return (Action) Delegate.CreateDelegate(typeof(Action), this, methodInfo);
        }
    }
}