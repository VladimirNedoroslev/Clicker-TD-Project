using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class GameManager : Singleton<GameManager>
{
    public int Gold;
    public int LifePoints;
    public int CurrentWave;
    public int CurrentLevel = 0;

    public EnemyPath LevelPath;
    public UnitSpots LevelUnitSpots;

    // (Optional) Prevent non-singleton constructor use.
    protected GameManager() { }


    private void Update()
    {
        if (LifePoints < 0)
        {
            StartCoroutine(Defeated());
        }
    }

    private void OnEnable()
    {
        InitializseUnitSpots();
        GetComponentInChildren<EnemySpawner>().enabled = false;

    }

    public void StartTheGame()
    {
        GetComponentInChildren<EnemySpawner>().enabled = true;
    }

    private void InitializseUnitSpots()
    {
        var unitSpotsParent = new GameObject
        {
            name = "UnitSpotsParent"
        };
        unitSpotsParent.transform.position = new Vector3(0, 0, 0);
        GameObject unitSpot;
        for (int i = 0; i < LevelUnitSpots.Length; i++)
        {
            unitSpot = Instantiate(LevelUnitSpots.unitSpotPrefab, LevelUnitSpots.unitSpotPositions[i], Quaternion.identity);
            unitSpot.transform.SetParent(unitSpotsParent.transform);
        }
        GetComponentInChildren<EnemySpawner>().enabled = false;
    }

    public IEnumerator Defeated()
    {
        GUIManager.Instance.ShowDefeatedText();
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
