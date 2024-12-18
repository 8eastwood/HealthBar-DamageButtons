using UnityEngine;
using UnityEngine.UI;

public abstract class ButtonListener : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Button _button;
    protected Health Health => _health;

    private void OnEnable()
    {
        _button.onClick.AddListener(ClickOnButton);
    }

    protected abstract void ClickOnButton();
    
}
