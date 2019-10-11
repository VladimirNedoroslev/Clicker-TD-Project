using System.Collections.Generic;
using UnityEngine;
public class BaseShootBehavior : MonoBehaviour
{
    public List<GameObject> EnemiesInRange;
    public Animator PrefabAnimator;

    protected float _lastShotTime;
    protected UnitData _unitData;
    protected Collider2D _target;
    protected AwakeBehavior _awakeBehavior;

    protected virtual void Start()
    {
        EnemiesInRange = new List<GameObject>();
        _lastShotTime = Time.time;
        _unitData = gameObject.GetComponent<UnitData>();

        _awakeBehavior = gameObject.GetComponentInChildren<AwakeBehavior>();
        PrefabAnimator = GetComponent<Animator>();
    }

    protected virtual void Update()
    {
        if (_awakeBehavior.isAwake)
        {
            GameObject enemy = null;
            float minimalEnemyDistance = float.MaxValue;

            foreach (GameObject enemyInRange in EnemiesInRange)
            {
                float distanceToGoal = enemyInRange.GetComponent<MoveEnemy>().DistanceToGoal();
                if (distanceToGoal < minimalEnemyDistance)
                {
                    enemy = enemyInRange;
                    minimalEnemyDistance = distanceToGoal;
                }
            }

            if (enemy != null)
            {
                if (Time.time - _lastShotTime > _unitData.CurrentLevel.AttackSpeed)
                {
                    _target = enemy.GetComponent<Collider2D>();
                    FaceEnemy();
                    PrefabAnimator.SetBool("IsAttacking", true);
                    _lastShotTime = Time.time;
                }
            }
            else
            {
                PrefabAnimator.SetBool("IsAttacking", false);
            }
        }
    }

    protected virtual void OnEnemyDestroy(GameObject enemy)
    {
        PrefabAnimator.Play("Attack", -1, 0);
        EnemiesInRange.Remove(enemy);
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Enemy"))
        {
            EnemiesInRange.Add(other.gameObject);
            EnemyDestructionDelegate del = other.gameObject.GetComponent<EnemyDestructionDelegate>();
            del.enemyDelegate += OnEnemyDestroy;
        }
    }

    protected virtual void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Enemy"))
        {
            EnemiesInRange.Remove(other.gameObject);
            EnemyDestructionDelegate del = other.gameObject.GetComponent<EnemyDestructionDelegate>();
            del.enemyDelegate -= OnEnemyDestroy;
        }
    }

    protected virtual void Shoot()
    {
        if (_target != null)
        {
            GameObject projectile = Instantiate(_unitData.CurrentLevel.Projectile);
            BaseUnitLevel unitLevel = _unitData.CurrentLevel;

            projectile.GetComponent<BaseProjectileBehavior>().Initialize(
                _target.gameObject,
                unitLevel.ProjectileSpeed,
                unitLevel.Damage,
                gameObject.transform.position,
                _target.transform.position
                );

            //TO DO: add attack sound
        }
    }

    protected virtual void FaceEnemy()
    {

        if (gameObject.transform.position.x < _target.transform.position.x)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
    }
}
    
