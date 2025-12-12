using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Controller untuk Main Menu Scene.
/// Menangani navigasi: Start Game, Level Select, Exit.
/// </summary>
public class MainMenuController : MonoBehaviour
{
    [Header("Level Select Panel")]
    [Tooltip("Panel UI yang berisi tombol-tombol level select")]
    public GameObject levelSelectPanel;

    [Header("Scene Configuration")]
    [Tooltip("Nama scene level default yang akan diload saat Start Game")]
    public string defaultLevelSceneName = "lvl1";

    [Tooltip("Nama scene Main Menu ini (untuk load kembali dari level)")]
    public string mainMenuSceneName = "MainMenu";

    private void Start()
    {
        // Pastikan waktu berjalan normal dan panel level select tersembunyi
        Time.timeScale = 1f;
        
        if (levelSelectPanel != null)
        {
            levelSelectPanel.SetActive(false);
        }
    }

    /// <summary>
    /// Dipanggil oleh tombol START GAME.
    /// Load level default.
    /// </summary>
    public void OnStartGame()
    {
        if (string.IsNullOrEmpty(defaultLevelSceneName))
        {
            Debug.LogError("[MainMenuController] Default level scene name belum diisi di Inspector!");
            return;
        }

        Debug.Log("[MainMenuController] Loading default level: " + defaultLevelSceneName);
        Time.timeScale = 1f;
        SceneManager.LoadScene(defaultLevelSceneName);
    }

    /// <summary>
    /// Dipanggil oleh tombol SELECT LEVEL.
    /// Menampilkan panel level select.
    /// </summary>
    public void OnShowLevelSelect()
    {
        if (levelSelectPanel != null)
        {
            levelSelectPanel.SetActive(true);
            Debug.Log("[MainMenuController] Level Select Panel ditampilkan");
        }
        else
        {
            Debug.LogError("[MainMenuController] Level Select Panel belum di-assign di Inspector!");
        }
    }

    /// <summary>
    /// Dipanggil oleh tombol BACK di level select panel.
    /// Menyembunyikan panel level select.
    /// </summary>
    public void OnHideLevelSelect()
    {
        if (levelSelectPanel != null)
        {
            levelSelectPanel.SetActive(false);
            Debug.Log("[MainMenuController] Level Select Panel disembunyikan");
        }
    }

    /// <summary>
    /// Dipanggil oleh tombol level spesifik (misal: Level 1, Level 2).
    /// Parameter sceneName diisi dari Inspector Button OnClick.
    /// </summary>
    /// <param name="sceneName">Nama scene yang akan diload</param>
    public void OnSelectLevel(string sceneName)
    {
        if (string.IsNullOrEmpty(sceneName))
        {
            Debug.LogError("[MainMenuController] Scene name kosong!");
            return;
        }

        Debug.Log("[MainMenuController] Loading level: " + sceneName);
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneName);
    }

    /// <summary>
    /// Dipanggil oleh tombol MAIN MENU dari scene lain (opsional).
    /// Load kembali scene main menu.
    /// </summary>
    public void OnLoadMainMenu()
    {
        if (string.IsNullOrEmpty(mainMenuSceneName))
        {
            Debug.LogError("[MainMenuController] Main Menu scene name belum diisi!");
            return;
        }

        Debug.Log("[MainMenuController] Loading Main Menu");
        Time.timeScale = 1f;
        SceneManager.LoadScene(mainMenuSceneName);
    }

    /// <summary>
    /// Dipanggil oleh tombol EXIT.
    /// Keluar dari aplikasi.
    /// </summary>
    public void OnExitGame()
    {
        Debug.Log("[MainMenuController] Exiting game...");

#if UNITY_EDITOR
        // Jika di Unity Editor, stop play mode
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // Jika build, quit aplikasi
        Application.Quit();
#endif
    }
}
