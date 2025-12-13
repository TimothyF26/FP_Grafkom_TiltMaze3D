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
        
        // ✅ FIXED: Cari buttons dengan multiple strategies dan hubungkan ke GameManager methods
        
        // Strategy 1: Cari berdasarkan nama exact
        Button nextButton = levelCompletePanel.transform.Find("Next")?.GetComponent<Button>();
        Button replayButton = levelCompletePanel.transform.Find("Replay")?.GetComponent<Button>();
        Button selectLevelButton = levelCompletePanel.transform.Find("SelectLevel")?.GetComponent<Button>();
        Button mainMenuButton = levelCompletePanel.transform.Find("Main Menu")?.GetComponent<Button>();

        // Strategy 2: Jika tidak ketemu, cari berdasarkan komponen Button dan urutkan
        if (nextButton == null || replayButton == null || selectLevelButton == null || mainMenuButton == null)
        {
            Button[] allButtons = levelCompletePanel.GetComponentsInChildren<Button>();
            Debug.Log($"Found {allButtons.Length} buttons in level complete panel");
            
            // Assign berdasarkan urutan jika Find tidak berhasil
            if (allButtons.Length >= 4)
            {
                nextButton = allButtons[0];
                replayButton = allButtons[1];
                selectLevelButton = allButtons[2];
                mainMenuButton = allButtons[3];
            }
        }

        // Hubungkan button listeners ke GameManager methods (FIXED)
        if (nextButton != null)
        {
            nextButton.onClick.RemoveAllListeners(); // Clear existing listeners
            nextButton.onClick.AddListener(() => GameManager.Instance.LoadNextLevel());
            Debug.Log("Next button connected");
        }
        else
        {
            Debug.LogWarning("Next button not found!");
        }

        if (replayButton != null)
        {
            replayButton.onClick.RemoveAllListeners();
            replayButton.onClick.AddListener(() => GameManager.Instance.RestartLevel());
            Debug.Log("Replay button connected");
        }
        else
        {
            Debug.LogWarning("Replay button not found!");
        }

        if (selectLevelButton != null)
        {
            selectLevelButton.onClick.RemoveAllListeners();
            selectLevelButton.onClick.AddListener(() => GameManager.Instance.LoadLevelSelect());
            Debug.Log("SelectLevel button connected");
        }
        else
        {
            Debug.LogWarning("SelectLevel button not found!");
        }

        if (mainMenuButton != null)
        {
            mainMenuButton.onClick.RemoveAllListeners();
            mainMenuButton.onClick.AddListener(() => GameManager.Instance.LoadMainMenu());
            Debug.Log("Main Menu button connected");
        }
        else
        {
            Debug.LogWarning("Main Menu button not found!");
        }
    }
}
