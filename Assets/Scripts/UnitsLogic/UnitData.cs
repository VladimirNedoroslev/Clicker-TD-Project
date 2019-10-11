using System.Collections.Generic;
using UnityEngine;

public class UnitData : MonoBehaviour
{
    public List<BaseUnitLevel> Levels;
    public BaseUnitLevel CurrentLevel
    {
        get
        {
            return _currentLevel;
        }
        set
        {
            _currentLevel = value;
            CurrentLevelIndex = Levels.IndexOf(_currentLevel);

            GameObject levelVisualization = Levels[CurrentLevelIndex].Visualization;

            gameObject.GetComponent<Animator>().runtimeAnimatorController = _currentLevel.Visualization.GetComponent<Animator>().runtimeAnimatorController;
            gameObject.GetComponent<SpriteRenderer>().color = _currentLevel.Visualization.GetComponent<SpriteRenderer>().color;

        }
    }
    public int CurrentLevelIndex;

    private BaseUnitLevel _currentLevel;

    void OnEnable()
    {
        CurrentLevel = Levels[0];
    }

    public bool isAtMaxLevel()
    {
        return CurrentLevelIndex == Levels.Count - 1;
    }

    public void InitializeComponents()
    {
        gameObject.GetComponent<Animator>().SetFloat("AttackSpeed", 1 / _currentLevel.AttackSpeed);
        gameObject.GetComponent<CircleCollider2D>().radius = _currentLevel.AttackRadius;
    }
}
