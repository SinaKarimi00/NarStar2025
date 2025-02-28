using System.Collections.Generic;
using DefaultNamespace.Controllers;
using DefaultNamespace.Updater;
using LightBot.Factory;
using UnityEngine;


namespace DefaultNamespace
{
    public class Main : MonoBehaviour
    {
        private List<IControllers> controllers;
        private List<IUpdater> neededUpdateClasses;

        private void Awake()
        {
            FactoryClass factory = new FactoryClass();
            controllers = factory.GetControllers();
        }
    }
}