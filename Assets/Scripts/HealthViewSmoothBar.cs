using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class smoothHealthbar : HealthView
{
    [SerializeField] private Slider _smoothHealthSlider;

    private Coroutine _coroutine;
    private float _step = 0.5f;
    private float _delay = 0.01f;
    private bool _isWorking = false;

    private void Awake()
    {
        _smoothHealthSlider.minValue = 0;
        _smoothHealthSlider.maxValue = _health.MaxHealth;
        _smoothHealthSlider.value = _health.MaxHealth;
    }

    protected override void UpdateHealth()
    {
        _coroutine = StartCoroutine(UpdateSlider());
    }

    private IEnumerator UpdateSlider()
    {
        WaitForSeconds wait = new WaitForSeconds(_delay);

        while (_smoothHealthSlider.value != _health.CurrentHealth)
        {
            _smoothHealthSlider.value = Mathf.MoveTowards(_smoothHealthSlider.value, _health.CurrentHealth, _step);

            yield return wait;
        }

        if (_smoothHealthSlider.value == _health.CurrentHealth)
        {
            StopAllCoroutines();
        }
    }
}
