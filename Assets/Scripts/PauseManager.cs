using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Script untuk mengatur Pause Menu di dalam game
/// Attached ke: PauseManager_Controller (GameObject kosong di lvl1 scene)
/// 
/// Fitur:
/// - Tekan ESC untuk pause/resume
/// - Panel pause muncul saat di-pause
/// - Tombol Lanjutkan, Main Menu, Exit Game
/// </summary>
public class PauseManager : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseMenuPanel;
    
    private bool isPaused = false;

    /// <summary>
    /// Update dipanggil setiap frame
    /// Di sini kita deteksi input tombol ESC
    /// </summary>
    private void Update()
    {
        // Jika pemain tekan ESC (KeyCode.Escape)
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Toggle antara pause dan resume
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    /// <summary>
    /// Fungsi untuk menghentikan permainan (Pause)
    /// Dihubungkan ke tombol "Lanjutkan" (jika dipanggil dari Resume)
    /// atau otomatis dipanggil saat ESC ditekan
    /// </summary>
    public void PauseGame()
    {
        isPaused = true;
        
        // KUNCI: Atur Time.timeScale ke 0 untuk stop semua Update()
        // yang menggunakan Time.deltaTime
        Time.timeScale = 0f;
        
        // Tampilkan panel pause
        if (pauseMenuPanel != null)
        {
            pauseMenuPanel.SetActive(true);
            Debug.Log("Game Paused! (Time.timeScale = 0)");
        }
        else
        {
            Debug.LogWarning("⚠️ Pause Menu Panel belum diassign di Inspector!");
        }
    }

    /// <summary>
    /// Fungsi untuk melanjutkan permainan (Resume)
    /// Dihubungkan ke tombol "Lanjutkan"
    /// atau otomatis dipanggil saat ESC ditekan di pause state
    /// </summary>
    public void ResumeGame()
    {
        isPaused = false;
        
        // Kembalikan Time.timeScale ke 1 untuk resume normal gameplay
        Time.timeScale = 1f;
        
        // Sembunyikan panel pause
        if (pauseMenuPanel != null)
        {
            pauseMenuPanel.SetActive(false);
            Debug.Log("Game Resumed! (Time.timeScale = 1)");
        }
    }

    /// <summary>
    /// Fungsi untuk kembali ke Main Menu
    /// Dihubungkan ke tombol "Main Menu" di pause panel
    /// </summary>
    public void GoToMainMenu()
    {
        // PENTING: Restore Time.timeScale sebelum load scene
        Time.timeScale = 1f;
        
        // Muat scene MainMenu
        SceneManager.LoadScene("MainMenu");
        
        Debug.Log("Loading Main Menu...");
    }

    /// <summary>
    /// Fungsi untuk keluar dari aplikasi
    /// Dihubungkan ke tombol "Exit Game" di pause panel
    /// </summary>
    public void ExitGame()
    {
        // Restore time sebelum exit
        Time.timeScale = 1f;
        
        // Untuk di Unity Editor: hentikan Play Mode
        // Untuk di Build: tutup aplikasi
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
        
        Debug.Log("Exiting Game...");
    }
}
