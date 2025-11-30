using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public GameObject levelCompletePanel;
    public Text timerText;
    public Text starText;

    void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        timerText.text = GameManager.Instance.levelTimer.ToString("F2");
        starText.text = "Stars: " + GameManager.Instance.collectedStars;
    }

    public void ShowLevelComplete()
    {
        levelCompletePanel.SetActive(true);
    }
}