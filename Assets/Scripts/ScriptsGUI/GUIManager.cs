using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GUIManager : Singleton<GUIManager>
{
    static public bool GameIsPaused = false;

    public GameObject TextGold;
    public GameObject TextLifePoints;
    public GameObject TextCurrentWave;
    public GameObject TextNextWave;
    public GameObject TextDefeated;    
    public GameObject NotEnoughGoldLabel;

    public Canvas canvas;

    private bool notEnoughGoldErrorIsShown = false;    
    
    void Update()
    {
        TextGold.GetComponent<Text>().text = " GOLD: " + GameManager.Instance.Gold;
        TextLifePoints.GetComponent<Text>().text = " LIFE: " + GameManager.Instance.LifePoints;
        TextCurrentWave.GetComponent<Text>().text = " WAVE: " + (GameManager.Instance.CurrentWave + 1);
    }

    public IEnumerator ShowNotEnoughGoldError()
    {
        if (!notEnoughGoldErrorIsShown)
        {
            notEnoughGoldErrorIsShown = true;
            NotEnoughGoldLabel.SetActive(true);
            NotEnoughGoldLabel.GetComponent<AudioSource>().Play();

            yield return new WaitForSeconds(3);

            NotEnoughGoldLabel.SetActive(false);
            notEnoughGoldErrorIsShown = false;
        }
    }

    public void CreatePopupText(string text, Transform location)
    {
        PopupText popupText = Instantiate(Resources.Load<PopupText>("Prefabs/GUI/PopupTextParent"));
        Vector2 screenPosition = Camera.main.WorldToScreenPoint(location.position);

        popupText.transform.SetParent(canvas.transform, false);
        popupText.transform.position = new Vector2(screenPosition.x + Random.Range(-0.5f, 0.5f), screenPosition.y + Random.Range(-0.5f, 0.5f));
        popupText.SetText(text);
    }

    public IEnumerator ShowNextWaveText()
    {
        TextNextWave.GetComponent<Text>().text = "WAVE " + (GameManager.Instance.CurrentWave + 1) + " IS COMING!";
        TextNextWave.SetActive(true);
        yield return new WaitForSeconds(2);
        TextNextWave.SetActive(false);
    }


    public void ShowDefeatedText()
    {
        TextDefeated.SetActive(true);
    }
}
