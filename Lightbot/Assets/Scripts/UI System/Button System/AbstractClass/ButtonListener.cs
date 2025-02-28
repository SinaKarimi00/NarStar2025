using CharacterSystem;


namespace UI_System.Button_System.AbstractClass
{
    public abstract class ButtonListener
    {
        protected readonly Robot robot;

        protected ButtonListener(Robot robot)
        {
            this.robot = robot;
        }
    }
}