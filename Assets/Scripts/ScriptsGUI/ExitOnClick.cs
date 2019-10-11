using UnityEngine;
public class ExitOnClick : MonoBehaviour
{
    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Game is exiting.");
    }
}
