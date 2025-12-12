using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectPanelController : MonoBehaviour
{
    [SerializeField] private GameObject levelSelectPanel;

    public void ShowLevelSelect()
    {
        if (levelSelectPanel != null)
        {
            levelSelectPanel.SetActive(true);
            Debug.Log("Level Select Panel shown");
        }
    }

    public void HideLevelSelect()
    {
        if (levelSelectPanel != null)
        {
            levelSelectPanel.SetActive(false);
            Debug.Log("Level Select Panel hidden");
        }
    }

    /// <summary>
    /// Fungsi untuk load level berdasarkan nomor level
    /// Dihubungkan ke tombol pilihan level di UI
    /// </summary>
    public void SelectLevel(int levelNumber)
    {
        Time.timeScale = 1f; // Pastikan game berjalan normal
        
        string levelName = "lvl" + levelNumber;
        Debug.Log("Loading level: " + levelName);
        
        SceneManager.LoadScene(levelName);
    }

    /// <summary>
    /// Fungsi untuk kembali ke main menu
    /// </summary>
    public void BackToMainMenu()
    {
        HideLevelSelect();
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
