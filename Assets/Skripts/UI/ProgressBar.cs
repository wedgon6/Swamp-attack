using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBar : Bar
{
    [SerializeField] private Spawner _spawner;

    private void OnEnable()
    {
        _spawner.EnemyCountChenget += OnValueChenged;
        Slider.value = 0;

    }

    private void OnDisable()
    {
        _spawner.EnemyCountChenget -= OnValueChenged;
    }
}
