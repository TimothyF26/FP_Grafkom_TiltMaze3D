using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public GameObject levelCompletePanel;
    public UnityEngine.UI.Text timerText;
    public UnityEngine.UI.Text starCountText;

    void Awake()
    {
        Instance = this;
    }

    public void ShowLevelComplete()
    {
        levelCompletePanel.SetActive(true);
        starCountText.text = GameManager.Instance.collectedStars.ToString();
        timerText.text = GameManager.Instance.levelTimer.ToString("F2");
    }
}