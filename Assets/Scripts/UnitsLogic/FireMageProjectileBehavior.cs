using UnityEngine;

public class FireMageProjectileBehavior : BaseProjectileBehavior
{
    public GameObject explosionPrefab;

    private float _AOE;
    private float _AOEDamageCoefficient;
    
    public void Initialize(GameObject target, float projectileSpeed, int damage, float AOE,
        float AOEDamageCoefficient, Vector3 projectilePosition, Vector3 targetPosition)
    {
        Initialize(target, projectileSpeed, damage, projectilePosition, targetPosition);        
        _AOE = AOE;
        _AOEDamageCoefficient = AOEDamageCoefficient;
    }

    protected new void Start()
    {
        base.Start();
        var tmp = new GameObject();
        tmp.transform.position = _target.transform.position;
        _target = new GameObject();
        _target.transform.position = tmp.transform.position;
    }

    protected override void Update()
    {
       
        MoveTowardTarget(_targetPosition);
        DealDamage();
       
    }

    private void Explosion()
    {
        var objectsWithinExplosionRadius = Physics2D.OverlapCircleAll(_target.transform.position, _AOE);

        var explosionObject = Instantiate(explosionPrefab, _target.transform.position, Quaternion.identity);
        Destroy(explosionObject, explosionObject.GetComponent<Animator>().GetCurrentAnimatorClipInfo(0).Length + 0.5f);

        foreach (Collider2D collider in objectsWithinExplosionRadius)
        {
            if (collider.gameObject.tag == "Enemy")
            {
                collider.GetComponentInChildren<HealthBar>().DealDamage((int)((float)_damage * _AOEDamageCoefficient));
                
            }
        }
    }

    protected override void DealDamage()
    {
        if (gameObject.transform.position.Equals(_targetPosition))
        {
            
            Explosion();
            if (_target != null )
            {                
                Destroy(gameObject);
                Destroy(_target);
                          
            }
        }
    }
    
}
