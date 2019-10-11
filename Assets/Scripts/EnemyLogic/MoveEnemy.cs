using System.Collections;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    [HideInInspector]
    public EnemyPath Path;
    public string CurrentDirection;

    private Animator _prefabAnimator;
    private float _currentSpeed = 1.0f;
    private float _coreSpeed;
    private int _currentWaypoint = 0;
    private Vector3 _endPosition;
    
    void Start()
    {
        _currentSpeed = gameObject.GetComponent<EnemyData>().baseEnemyData.Speed;
        _coreSpeed = _currentSpeed;
        gameObject.transform.position = Path.WayPoints[0];
        _prefabAnimator = gameObject.GetComponent<Animator>();
        _prefabAnimator.SetBool(CurrentDirection, true);
        _endPosition = Path.WayPoints[_currentWaypoint + 1];
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _endPosition, _currentSpeed * Time.deltaTime);

        if (gameObject.transform.position.Equals(_endPosition))
        {
            if (_currentWaypoint < Path.WayPoints.Length - 2)
            {
                _currentWaypoint++;
                _endPosition = Path.WayPoints[_currentWaypoint + 1];
                RotateEnemy();
            }
            else
            {
                GameManager.Instance.LifePoints--;
                Destroy(gameObject);
            }
        }
    }

    public float DistanceToGoal()
    {
        float distance = 0;
        distance += Vector2.Distance(
            gameObject.transform.position,
            Path.WayPoints[_currentWaypoint + 1]);
        for (int i = _currentWaypoint + 1; i < Path.WayPoints.Length - 1; i++)
        {
            distance += Vector2.Distance(Path.WayPoints[i], Path.WayPoints[i + 1]);
        }
        return distance;
    }

    public void StartSlowing(float slowCoefficient, float slowDuration)
    {
        Debug.Log("APPLYING SLOWING, slow coefficient = " + slowCoefficient + " slowDuration = " + slowDuration);
        StartCoroutine(SlowEnemy(slowCoefficient, slowDuration));
    }

    private IEnumerator SlowEnemy(float slowCoefficient, float slowDuration)
    {
        var initialColor = GetComponent<SpriteRenderer>().color;
        _currentSpeed = _coreSpeed * slowCoefficient;
        GetComponent<SpriteRenderer>().material.color = new Color(0.2f, 0.5f, 1, 1);

        yield return new WaitForSeconds(slowDuration);

        GetComponent<SpriteRenderer>().material.color = initialColor;
        _currentSpeed = _coreSpeed;
    }

    private void RotateEnemy()
    {
        if (Path.WayPoints[_currentWaypoint + 1].x > Path.WayPoints[_currentWaypoint].x)
        {
            ResetDirection("IsMovingRight");
        }
        else if (Path.WayPoints[_currentWaypoint + 1].x < Path.WayPoints[_currentWaypoint].x)
        {
            ResetDirection("IsMovingLeft");
        }
        else if (Path.WayPoints[_currentWaypoint + 1].y > Path.WayPoints[_currentWaypoint].y)
        {
            ResetDirection("IsMovingUp");
        }
        else
        {
            ResetDirection("IsMovingDown");
        }
    }

    private void ResetDirection(string newDirection)
    {
        _prefabAnimator.SetBool(CurrentDirection, false);
        _prefabAnimator.SetBool(newDirection, true);
        CurrentDirection = newDirection;
    }
}
