using UnityEngine;

public class HealthBar : MonoBehaviour
{ 
    public GameObject healthBarBackground;
    public int MaxHealth;
    public int CurrentHealth;
    public float _originalScale;

    void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        var enemyData = gameObject.GetComponentInParent<EnemyData>();

        MaxHealth = enemyData.baseEnemyData.Health;
        CurrentHealth = enemyData.baseEnemyData.Health;
        _originalScale = gameObject.transform.localScale.x;
    }

    public void Update()
    {
        Vector3 tmpScale = gameObject.transform.localScale;
        tmpScale.x = (float)CurrentHealth / MaxHealth * _originalScale;
        gameObject.transform.localScale = tmpScale;

        if (IsDead())
        {
            GetComponentInParent<DeathBehavior>().OnDeathActions();
            Destroy(healthBarBackground);
            Destroy(gameObject);
            Debug.Log("Enemy is dying!");
        }
    }

    public void DealDamage(int damage)
    {
        CurrentHealth -= damage;
    }

    public bool IsDead()
    {
        return CurrentHealth <= 0;
    }

}