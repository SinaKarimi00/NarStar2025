using System.Collections.Generic;
using DefaultNamespace.Character_System;
using DefaultNamespace.Controllers;
using Game_Session_System;


namespace LightBot.Factory
{
    public class FactoryClass
    {
        public List<IControllers> GetControllers()
        {
            List<IControllers> controllers = new List<IControllers>();
            controllers.Add(new GameSessionController());
            controllers.Add(new RobotController());
            return controllers;
        }
    }
}