using UnityEngine;

public class IceMageProjectileBehavior : BaseProjectileBehavior
{
    protected float _slowCoefficient;
    protected float _slowDuration;

    public void Initialize(GameObject target, float projectileSpeed, int damage, float slowDuration,
        float slowCoefficient, Vector3 projectilePosition, Vector3 targetPosition)
    {
        Initialize(target, projectileSpeed, damage, projectilePosition, targetPosition);
        _slowCoefficient = slowCoefficient;
        _slowDuration = slowDuration;

    }


    protected new void Start()
    {
        base.Start();
    }

    protected override void Update()
    {

        if (_target.GetComponentInChildren<HealthBar>() != null)
        {
            MoveTowardTarget(_target.transform.position);
            DealDamage();
        }
        else Destroy(gameObject);
    }


    protected override void DealDamage()
    {
        if (gameObject.transform.position.Equals(_target.transform.position))
        {
            var healthBar = _target.GetComponentInChildren<HealthBar>();
            if (_target != null && healthBar != null)
            {
                _target.GetComponent<MoveEnemy>().StartSlowing(_slowCoefficient, _slowDuration);
                Destroy(gameObject);
                healthBar.DealDamage(_damage);
            }
        }
    }
}
