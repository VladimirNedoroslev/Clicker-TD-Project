using UnityEngine;

public class BaseProjectileBehavior : MonoBehaviour
{
    protected GameObject _target;
    protected float _speed;
    protected int _damage;
    protected Vector3 _startPosition;
    protected Vector3 _targetPosition;

    public void Initialize(GameObject target, float projectileSpeed, int damage,
                           Vector3 projectilePosition, Vector3 targetPosition)
    {
        _target = target;
        _damage = damage;
        _speed = projectileSpeed;
        _startPosition = projectilePosition;
        _targetPosition = targetPosition;

        gameObject.transform.position = _startPosition;
    }

    protected void Start()
    {
        Vector3 direction = gameObject.transform.position - _target.transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * _speed);
    }

    protected virtual void Update()
    {
        if (_target.GetComponentInChildren<HealthBar>() != null)
        {
            MoveTowardTarget(_target.transform.position);
            DealDamage();
        }
        else Destroy(gameObject);
    }

    protected void MoveTowardTarget(Vector3 targetPosition)
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, _speed * Time.deltaTime);
        Vector3 direction = gameObject.transform.position - _target.transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 100);

    }

    protected virtual void DealDamage()
    {
        if (gameObject.transform.position.Equals(_target.transform.position))
        {
            var healthBar = _target.GetComponentInChildren<HealthBar>();
            if (_target != null && healthBar != null)
            {
                Destroy(gameObject);
                healthBar.DealDamage(_damage);
            }
        }
    }
}
