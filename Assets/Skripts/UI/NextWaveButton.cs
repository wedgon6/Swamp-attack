using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextWaveButton : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Button _nexWaveButton;

    private void OnEnable()
    {
        _spawner.AllEnemySpawned += OnAllEnemySpawned;
        _nexWaveButton.onClick.AddListener(OnNextWaveButtonClick);
    }

    private void OnDisable()
    {
        _spawner.AllEnemySpawned -= OnAllEnemySpawned;
        _nexWaveButton.onClick.RemoveListener(OnNextWaveButtonClick);
    }

    public void OnAllEnemySpawned()
    {
        _nexWaveButton.gameObject.SetActive(true);
    }

    public void OnNextWaveButtonClick()
    {
        _spawner.NextWave();
        _nexWaveButton.gameObject.SetActive(false);
    }
}
