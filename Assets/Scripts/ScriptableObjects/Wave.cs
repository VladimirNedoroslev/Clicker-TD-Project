using UnityEngine;
[CreateAssetMenu(fileName = "Wave", menuName = "New wave")]
public class Wave : ScriptableObject
{
    public GameObject[] enemyToSpawnPrefab;
    public float[] spawnInterval;
    public int[] maxEnemies;

    public Wave(GameObject[] prefabs, float[] spawnInterval, int[] maxEnemies)
    {
        enemyToSpawnPrefab = prefabs;
        this.spawnInterval = spawnInterval;
        this.maxEnemies = maxEnemies;
    }

    public int Length()
    {
        return enemyToSpawnPrefab.Length;
    }
}
