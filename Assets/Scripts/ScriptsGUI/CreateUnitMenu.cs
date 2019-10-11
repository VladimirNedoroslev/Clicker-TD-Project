using UnityEngine;

public class CreateUnitMenu : MonoBehaviour
{
    public static bool CreateUnitMenuIsShown = false;
    public static float ClickTime;

    public GameObject CreateUnitPanel;
    public GameObject ArcherPrefab;
    public GameObject IceMagePrefab;
    public GameObject FireMagePrefab;
    public Transform unitSpotTransform;
    
    public void CreateArcher()
    {
        TryBuildTower(ArcherPrefab);
    }

    public void CreateIceMage()
    {
        TryBuildTower(IceMagePrefab);
    }

    public void CreateFireMage()
    {
        TryBuildTower(FireMagePrefab);
    }

    public void TryBuildTower(GameObject unitPrefab)
    {
        var unitData = unitPrefab.GetComponent<UnitData>();
        if (GameManager.Instance.Gold < unitData.Levels[0].Cost)
        {
            StartCoroutine(GUIManager.Instance.ShowNotEnoughGoldError());
            return;
        }

        var instantiatedUnit =Instantiate(unitPrefab, unitSpotTransform.position, Quaternion.identity);

        GameManager.Instance.Gold -= instantiatedUnit.GetComponent<UnitData>().CurrentLevel.Cost;
        Debug.Log(unitSpotTransform.gameObject.name);
        Destroy(unitSpotTransform.gameObject);
        Cancel();
    }

    public void Cancel()
    {
        CreateUnitMenuIsShown = false;
        CreateUnitPanel.SetActive(false);
    }
}
