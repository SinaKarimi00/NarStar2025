using DefaultNamespace.Controllers;
using DefaultNamespace.UI_System;


namespace Game_Session_System
{
    public class GameSessionController : IControllers
    {
        public GameSessionController()
        {
            UIManager uiManager = new UIManager();
            uiManager.InitializeMenuUi(); // TODO: This can be moved into the UIManager itself
        }
    }
}