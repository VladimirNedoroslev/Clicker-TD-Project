using UnityEngine;
using UnityEngine.UI;
public class PopupText : MonoBehaviour
{
    public Animator animator;
    private Text textComponent;

    private void OnEnable()
    {
        textComponent = animator.GetComponent<Text>();
        Destroy(gameObject, animator.GetCurrentAnimatorClipInfo(0).Length);        
    }

    public void SetText(string text)
    {
        textComponent.text = text;
    }
}
