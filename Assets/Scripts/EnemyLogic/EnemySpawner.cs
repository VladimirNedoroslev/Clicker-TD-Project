using UnityEngine;

[System.Serializable]
public class EnemySpawner : MonoBehaviour
{
    public Wave[] Waves;
    public int timeBetweenWaves = 5;

    private float[] _lastSpawnTime;
    private int[] _enemiesSpawned;
    private float[] _timeInterval;

    void Start()
    {
        _lastSpawnTime = new float[Waves.Length];
        _enemiesSpawned = new int[Waves.Length];
        _timeInterval = new float[Waves.Length];
        for (int i = 0; i < Waves.Length; i++)
        {
            _lastSpawnTime[i] = Time.time;
            _enemiesSpawned[i] = 0;
        }
        StartCoroutine(GUIManager.Instance.ShowNextWaveText());
    }

    void Update()
    {
        if (GameManager.Instance.CurrentWave < Waves.Length)
        {

            for (int i = 0; i < Waves[GameManager.Instance.CurrentWave].Length(); i++)
            {
                _timeInterval[i] = Time.time - _lastSpawnTime[i];

                if (((_enemiesSpawned[i] == 0 && _timeInterval[i] >= timeBetweenWaves) ||
                     _timeInterval[i] >= Waves[GameManager.Instance.CurrentWave].spawnInterval[i]) &&
                    _enemiesSpawned[i] < Waves[GameManager.Instance.CurrentWave].maxEnemies[i])
                {
                    _lastSpawnTime[i] = Time.time;
                    GameObject enemy = Instantiate(Waves[GameManager.Instance.CurrentWave].enemyToSpawnPrefab[i]);
                    enemy.GetComponent<MoveEnemy>().Path = EnemyPath.GetShiftedPath(GameManager.Instance.LevelPath.WayPoints);
                    _enemiesSpawned[i]++;
                }                
            }

            if (IsWaveFinished())
            {
                GameManager.Instance.CurrentWave++;
                for (int i = 0; i < Waves.Length; i++)
                {
                    _enemiesSpawned[i] = 0;
                    _lastSpawnTime[i] = Time.time;
                }
                 if (GameManager.Instance.CurrentWave < Waves.Length)
                    StartCoroutine(GUIManager.Instance.ShowNextWaveText());
            }
        }

    }

    private bool IsWaveFinished()
    {
        for (int i = 0; i < Waves[GameManager.Instance.CurrentWave].enemyToSpawnPrefab.Length; i++)
        {
            if (_enemiesSpawned[i] != Waves[GameManager.Instance.CurrentWave].maxEnemies[i])
            {
                //GameObject.FindGameObjectWithTag("Enemy") == null
                return false;
            }
        }
        return true;
    }
}
