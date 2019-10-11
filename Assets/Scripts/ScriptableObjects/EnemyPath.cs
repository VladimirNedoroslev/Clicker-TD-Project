using UnityEngine;

[CreateAssetMenu(fileName = "Path", menuName = "New path")]
public class EnemyPath : ScriptableObject
{
    public Vector3[] WayPoints;
    public EnemyPath(Vector3[] path)
    {
        WayPoints = path;
    }

    public static EnemyPath GetShiftedPath(Vector3[] path)
    {
        var shifterPath = new Vector3[path.Length];
        float xShift = Random.Range(-1.0f, 1.0f);
        float yShift = Random.Range(-1.0f, 1.0f);
        for (int i = 0; i < shifterPath.Length; i++)
        {
            shifterPath[i] = new Vector3
            {
                x = path[i].x + xShift,
                y = path[i].y + yShift
            };
        }
        EnemyPath result = (EnemyPath)ScriptableObject.CreateInstance("EnemyPath");
        result.WayPoints = shifterPath;
        return result;
    }
}
