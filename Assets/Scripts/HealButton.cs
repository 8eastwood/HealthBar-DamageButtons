public class HealButton : ButtonListener
{
    private int _healAmount = 10;

    protected override void ClickOnButton()
    {
        Health.TakeHeal(_healAmount);
    }
}
