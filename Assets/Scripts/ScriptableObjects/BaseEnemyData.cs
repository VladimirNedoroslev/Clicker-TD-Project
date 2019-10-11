using UnityEngine;
[CreateAssetMenu (fileName = "NewEnemy", menuName = "New enemy")]
public class BaseEnemyData : ScriptableObject
{
    public float Speed;
    public int Health;
    public int Reward;
}
