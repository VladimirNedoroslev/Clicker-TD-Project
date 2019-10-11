using UnityEngine;

[CreateAssetMenu(fileName = "Archer", menuName = "New archer")]
public class BaseUnitLevel : ScriptableObject
{
    public string Name;
    public string Description;
    public int Cost;
    public GameObject Visualization;
    public GameObject Projectile;
    public int ProjectileSpeed;
    public int Damage;
    public float AttackRadius;
    public float AttackSpeed;
    public int AwakeTime;
}
