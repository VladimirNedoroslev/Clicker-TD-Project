using UnityEngine;
using UnityEngine.UI;

public class SideMenu : MonoBehaviour
{
    public GameObject ButtonPauseResume;
    public Button ButtonStart;
    public GameObject TextGameIsPaused;

    private bool _gameIsPaused = false;    

    public void PauseResume()
    {
        if (_gameIsPaused)
        {            
            TextGameIsPaused.SetActive(false);
            ButtonPauseResume.GetComponentInChildren<Text>().text = "Pause";
            Time.timeScale = 1f;
        }
        else
        {
            TextGameIsPaused.SetActive(true);
            ButtonPauseResume.GetComponentInChildren<Text>().text = "Resume";
            Time.timeScale = 0f;
        }
        _gameIsPaused = !_gameIsPaused;
    }

    public void StartTheGame()
    {
        GameManager.Instance.StartTheGame();
        ButtonStart.interactable = false;        
    }
}
