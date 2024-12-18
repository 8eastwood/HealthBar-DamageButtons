public class DamageButton : ButtonListener
{
    private int _damage = 20;

    protected override void ClickOnButton()
    {
        Health.TakeDamage(_damage);
    }
}
