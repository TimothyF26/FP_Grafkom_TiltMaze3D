using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public GameObject levelCompletePanel;

    public Text timerText;
    public Text starsText; // ganti dari starText

    public Text levelCompleteStars; // UI di panel level complete
    public int maxStars = 3;

    void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        timerText.text = GameManager.Instance.levelTimer.ToString("F2");
    }

    public void UpdateStarsUI(int stars)
    {
        starsText.text = "⭐ " + stars + "/" + maxStars;
    }

    public void UpdateKeysUI(int keysCollected)
{
    // Untuk sekarang, kita print ke console
    // Di future, bisa bikin Text UI element untuk menampilkan ini
    Debug.Log("Keys collected: " + keysCollected + "/2");
}


    public void ShowLevelComplete(int stars)
{
    levelCompletePanel.SetActive(true);
    levelCompleteStars.text = "";
    for (int i = 0; i < stars; i++)
        levelCompleteStars.text += "⭐";
    
    // ✅ TAMBAHKAN INI:
    // Hubungkan button dengan callback functions
    Button nextButton = levelCompletePanel.transform.Find("Next").GetComponent<Button>();
    Button replayButton = levelCompletePanel.transform.Find("Replay").GetComponent<Button>();
    Button selectLevelButton = levelCompletePanel.transform.Find("SelectLevel").GetComponent<Button>();
    Button mainMenuButton = levelCompletePanel.transform.Find("Main Menu").GetComponent<Button>();
    
    if (nextButton != null) nextButton.onClick.AddListener(LoadNextLevel);
    if (replayButton != null) replayButton.onClick.AddListener(RestartLevel);
    if (selectLevelButton != null) selectLevelButton.onClick.AddListener(GoToLevelSelect);
    if (mainMenuButton != null) mainMenuButton.onClick.AddListener(GoToMainMenu);
}

}