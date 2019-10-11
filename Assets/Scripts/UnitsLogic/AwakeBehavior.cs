using UnityEngine;

public class AwakeBehavior : MonoBehaviour
{
    public bool isAwake;
    public Animator prefabAnimator;
    public AudioSource hitSound;

    private UnitData _unitData;
    private float _lastAwakeningTime;
    
    void Start()
    {
        isAwake = true;
        _unitData = gameObject.GetComponentInParent<UnitData>();    
        _lastAwakeningTime = Time.time;
    }

    void Update()
    {
        if (Time.time - _lastAwakeningTime > _unitData.CurrentLevel.AwakeTime)
        {
            isAwake = false;
            prefabAnimator.SetBool("IsAwake", false);
        }
    }

    private void OnMouseUp()
    {
        if (Input.GetMouseButtonUp(0))
        { Debug.Log("Awaken! ");
            isAwake = true;
            _lastAwakeningTime = Time.time;
            prefabAnimator.SetBool("IsAwake", true);
            Instantiate(Resources.Load("Prefabs/GUI/HitEffect"));
            hitSound.Play();
        }
    }
}
