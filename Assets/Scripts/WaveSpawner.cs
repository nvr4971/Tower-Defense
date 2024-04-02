using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public static int enemiesAlive = 0;

    [Header("GameManager Reference")]
    public GameManager gameManager;

    [Header("Wave List")]
    public Wave[] waves;

    [Header("Spawnpoint Reference")]
    [SerializeField] private Transform spawnPoint;

    [Header("Time Between Waves")]
    [SerializeField] private float timeBetweenWaves = 5.5f;
    
    [Header("Wave Timer UI Reference")]
    [SerializeField] private Text waveCountdownTimer;

    private float countdown = 6.5f;
    private int waveIndex = 0;

    private void Start()
    {
        enemiesAlive = 0;
    }

    private void Update()
    {
        if (enemiesAlive > 0 || GameManager.gameIsOver)
        {
            return;
        }

        if (waveIndex == waves.Length)
        {
            gameManager.WinLevel();
            enabled = false;
        }

        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
        }

        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        waveCountdownTimer.text = string.Format("{0:00.00}", countdown);
    }

    private IEnumerator SpawnWave()
    {
        PlayerStats.rounds++;

        Wave wave = waves[waveIndex];

        enemiesAlive = wave.count;
        
        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }

        waveIndex++;
    }

    private void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    }
}
