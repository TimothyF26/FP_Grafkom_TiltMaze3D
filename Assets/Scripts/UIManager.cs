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

        // Tampilkan bintang di level complete panel
        levelCompleteStars.text = "";
        for (int i = 0; i < stars; i++)
            levelCompleteStars.text += "⭐";
    }
}