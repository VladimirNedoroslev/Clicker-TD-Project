using UnityEngine;

public class UpgradeController : MonoBehaviour
{
    private UnitData _unitData;
    public AudioSource UpgradeSound;
    
    void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        _unitData = gameObject.GetComponentInParent<UnitData>();
    }

    public BaseUnitLevel GetNextLevel()
    {

        if (!_unitData.isAtMaxLevel())
        {
            return _unitData.Levels[_unitData.CurrentLevelIndex + 1];
        }
        else
        {
            return null;
        }

    }

    public void UpgradeUnit()
    {
        if (GetNextLevel() != null)
        {
            _unitData.CurrentLevel = _unitData.Levels[_unitData.CurrentLevelIndex + 1];
            GameManager.Instance.Gold -= _unitData.CurrentLevel.Cost;
            UpgradeSound.Play();
            _unitData.InitializeComponents();
        }
    }


    public void OnMouseOver()
    {
        var awakeBehavior = GetComponent<AwakeBehavior>();
        if (Input.GetMouseButtonDown(1) && awakeBehavior.isAwake)
        {
            if (GameManager.Instance.Gold < GetNextLevel().Cost)
            {
                Debug.Log("Not enough gold");
                StartCoroutine(GUIManager.Instance.ShowNotEnoughGoldError());
                return;
            }
            if (GetNextLevel() != null)
            {
                Debug.Log("Upgraded!");
                UpgradeUnit();
            }
        }
    }

}
