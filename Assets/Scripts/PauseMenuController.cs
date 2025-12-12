using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Controller untuk sistem Pause di dalam gameplay.
/// Mendeteksi ESC key untuk toggle pause/resume.
/// Menampilkan Pause Menu dengan opsi: Resume, Restart, Main Menu, Exit.
/// </summary>
public class PauseMenuController : MonoBehaviour
{
    [Header("UI References")]
    [Tooltip("Canvas atau Panel yang berisi UI Pause Menu")]
    public GameObject pauseMenuUI;

    [Header("Scene Configuration")]
    [Tooltip("Nama scene Main Menu untuk tombol 'Main Menu'")]
    public string mainMenuSceneName = "MainMenu";

    /// <summary>
    /// Status apakah game sedang di-pause atau tidak.
    /// </summary>
    public bool IsPaused { get; private set; }

    private void Awake()
    {
        // Pastikan game dimulai dalam keadaan tidak pause
        Time.timeScale = 1f;
        IsPaused = false;

        if (pauseMenuUI != null)
        {
            pauseMenuUI.SetActive(false);
        }
    }

    private void Update()
    {
        // Deteksi ESC key setiap frame
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    /// <summary>
    /// Toggle antara pause dan resume.
    /// </summary>
    public void TogglePause()
    {
        if (IsPaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }

    /// <summary>
    /// Pause game: freeze waktu dan tampilkan pause menu.
    /// </summary>
    public void PauseGame()
    {
        IsPaused = true;
        Time.timeScale = 0f; // Freeze semua Time.deltaTime

        if (pauseMenuUI != null)
        {
            pauseMenuUI.SetActive(true);
        }

        Debug.Log("[PauseMenuController] Game PAUSED");
    }

    /// <summary>
    /// Resume game: jalankan waktu kembali dan sembunyikan pause menu.
    /// Dipanggil oleh tombol RESUME.
    /// </summary>
    public void ResumeGame()
    {
        IsPaused = false;
        Time.timeScale = 1f; // Kembalikan waktu normal

        if (pauseMenuUI != null)
        {
            pauseMenuUI.SetActive(false);
        }

        Debug.Log("[PauseMenuController] Game RESUMED");
    }

    /// <summary>
    /// Restart level sekarang (reload scene aktif).
    /// Dipanggil oleh tombol RESTART.
    /// </summary>
    public void RestartLevel()
    {
        Debug.Log("[PauseMenuController] Restarting level...");

        Time.timeScale = 1f; // Pastikan waktu jalan
        IsPaused = false;

        // Reload scene yang sedang aktif
        Scene activeScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(activeScene.name);
    }

    /// <summary>
    /// Kembali ke Main Menu.
    /// Dipanggil oleh tombol MAIN MENU.
    /// </summary>
    public void LoadMainMenu()
    {
        if (string.IsNullOrEmpty(mainMenuSceneName))
        {
            Debug.LogError("[PauseMenuController] Main Menu scene name belum diisi di Inspector!");
            return;
        }

        Debug.Log("[PauseMenuController] Loading Main Menu...");

        Time.timeScale = 1f;
        IsPaused = false;

        SceneManager.LoadScene(mainMenuSceneName);
    }

    /// <summary>
    /// Keluar dari game.
    /// Dipanggil oleh tombol EXIT.
    /// </summary>
    public void ExitGame()
    {
        Debug.Log("[PauseMenuController] Exiting game...");

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
