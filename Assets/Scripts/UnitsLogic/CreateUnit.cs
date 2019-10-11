using UnityEngine;
public class CreateUnit : MonoBehaviour
{
    public BoxCollider2D boxCollider2D;

    private static float _timeDelay = 0.1f;

    private void Update()
    {
        //Raycast depends on camera projection mode
        if (Input.GetMouseButtonUp(0) && CreateUnitMenu.CreateUnitMenuIsShown && Time.time - CreateUnitMenu.ClickTime > _timeDelay)
        {
            Vector2 origin = Vector2.zero;
            Vector2 dir = Vector2.zero;

            if (Camera.main.orthographic)
            {
                origin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
            else
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                origin = ray.origin;
                dir = ray.direction;
            }

            RaycastHit2D hit = Physics2D.Raycast(origin, dir);
            if (hit.collider != boxCollider2D)
            {
                GUIManager.Instance.GetComponent<CreateUnitMenu>().CreateUnitPanel.SetActive(false);
                CreateUnitMenu.CreateUnitMenuIsShown = false;
                Debug.Log("Clicked outside!");
            }
        }
    }

    private void OnMouseUp()
    {
        CreateUnitMenu.ClickTime = Time.time;
        CreateUnitMenu createUnitMenu = GUIManager.Instance.GetComponent<CreateUnitMenu>();
        createUnitMenu.CreateUnitPanel.SetActive(true);
        createUnitMenu.unitSpotTransform = transform;
        CreateUnitMenu.CreateUnitMenuIsShown = true;

        Debug.Log("Click!");
    }
}


