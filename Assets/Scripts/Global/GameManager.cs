using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Transform Player { get; private set; }
    [SerializeField] private string playerTag = "Player";
    private HealthSystem playerHealthSystem;

    [SerializeField] private TextMeshProUGUI waveText;
    [SerializeField] private Slider hpGaugeSlider;
    [SerializeField] private GameObject gameOverUI;

    [SerializeField] private int currentWaveIndex = 0;
    private int currentSpawnCount = 0;
    private int waveSpawnCount = 0;
    private int waveSpawnPosCount = 0;

    public float spawnInterval = 0.5f;
    public List<GameObject> enemyPrefabs = new List<GameObject>();

    [SerializeField] private Transform spawnPositionRoot;
    private List<Transform> spawnPositions = new List<Transform>();

    private void Awake()
    {
        instance = this;
        Player = GameObject.FindGameObjectWithTag(playerTag).transform;

        playerHealthSystem = Player.GetComponent<HealthSystem>();
        playerHealthSystem.OnDamage += UpdateHealthUI;
        playerHealthSystem.OnHeal += UpdateHealthUI;
        playerHealthSystem.OnDeath += GameOver;

        gameOverUI.SetActive(false);
        
        for (int i =0; i< spawnPositionRoot.childCount; i++)
        {
            spawnPositions.Add(spawnPositionRoot.GetChild(i));
        }
    }

    private void Start()
    {
        StartCoroutine(nameof(StartNextWave));
    }

    IEnumerator StartNextWave()
    {
        while (true)
        {
            if (currentSpawnCount == 0)
            {
                UpdateWaveUI();
                yield return new WaitForSeconds(2f);

                if (currentWaveIndex % 20 == 0)
                {
                    // RandomUpgrade();
                }

                if (currentWaveIndex % 10 == 0)
                {
                    waveSpawnPosCount = waveSpawnPosCount + 1 > spawnPositions.Count ? waveSpawnPosCount : waveSpawnPosCount + 1;
                    waveSpawnCount = 0;
                }

                if (currentWaveIndex % 5 == 0)
                {
                    // CreateReward();
                }

                if (currentWaveIndex % 3 == 0)
                {
                    waveSpawnCount += 1;
                }


                for (int i = 0; i < waveSpawnPosCount; i++)
                {
                    int posIdx = Random.Range(0, spawnPositions.Count);
                    for (int j = 0; j < waveSpawnCount; j++)
                    {
                        int prefabIdx = Random.Range(0, enemyPrefabs.Count);
                        GameObject enemy = Instantiate(enemyPrefabs[prefabIdx], spawnPositions[posIdx].position, Quaternion.identity);
                        enemy.GetComponent<HealthSystem>().OnDeath += OnEnemyDeath;
                        currentSpawnCount++;
                        yield return new WaitForSeconds(spawnInterval);
                    }
                }

                currentWaveIndex++;
            }

            yield return null;
        }
    }

    private void OnEnemyDeath()
    {
        currentSpawnCount--;
    }

    private void UpdateHealthUI()
    {
        hpGaugeSlider.value = playerHealthSystem.CurrentHealth / playerHealthSystem.MaxHealth;
    }

    private void GameOver()
    {
        gameOverUI.SetActive(true);
        StopAllCoroutines();
    }

    private void UpdateWaveUI()
    {
        waveText.text = (currentWaveIndex + 1).ToString();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
