using UnityEngine;
public class HitEffectBehavior : MonoBehaviour
{    
    public float aliveTime;
    private float creationTime;
            
    void Start()
    {
        creationTime = Time.time;
        var mousePosition = Input.mousePosition;
        var newPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, Camera.main.nearClipPlane));
        transform.position = newPosition;
    }
    
    void Update()
    {
        if (Time.time - creationTime >= aliveTime)
            Destroy(gameObject);
    } 
}
