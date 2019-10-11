using UnityEngine;

public class FireMageShootBehavior : BaseShootBehavior
{
    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void OnEnemyDestroy(GameObject enemy)
    {
        base.OnEnemyDestroy(enemy);
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
    }

    protected override void OnTriggerExit2D(Collider2D other)
    {
        base.OnTriggerExit2D(other);
    }

    protected override void Shoot()
    {
        if (_target != null)
        {
            GameObject projectile = Instantiate(_unitData.CurrentLevel.Projectile);
            FireMageUnitLevel unitLevel = (FireMageUnitLevel) _unitData.CurrentLevel;

            projectile.GetComponent<FireMageProjectileBehavior>().Initialize(
                _target.gameObject,
                unitLevel.ProjectileSpeed, 
                unitLevel.Damage, 
                unitLevel.AOE, 
                unitLevel.AOEDamageCoefficient,
                gameObject.transform.position, 
                _target.transform.position
                );

            //TO DO: add attack sound
        }
    }

    protected override void FaceEnemy()
    {
        base.FaceEnemy();
    }
}
