using UnityEngine;
[CreateAssetMenu(fileName = "UnitSpots", menuName = "New unit spots")]
public class UnitSpots : ScriptableObject
{
    public Vector3[] unitSpotPositions;
    public GameObject unitSpotPrefab;
    public int Length { get { return unitSpotPositions.Length; } }
}
