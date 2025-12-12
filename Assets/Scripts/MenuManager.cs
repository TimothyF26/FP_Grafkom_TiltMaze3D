using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Script untuk mengatur Main Menu
/// Attached ke: MenuManager_Controller (GameObject kosong di MainMenu scene)
/// </summary>
public class MenuManager : MonoBehaviour
{
    /// <summary>
    /// Fungsi untuk memulai game
    /// Dihubungkan ke tombol "Mulai"
    /// </summary>
    public void StartGame()
{
    // Pastikan game tidak dalam state pause
    Time.timeScale = 1f;
    
    // Tampilkan level selection panel INSTEAD of loading lvl1
    LevelSelectPanelController levelSelectController = 
        FindObjectOfType<LevelSelectPanelController>();
    
    if (levelSelectController != null)
    {
        levelSelectController.ShowLevelSelect();
    }
    else
    {
        Debug.LogError("LevelSelectPanelController tidak ditemukan di scene!");
    }
    
    Debug.Log("Opening Level Selection...");
}

    /// <summary>
    /// Fungsi untuk membuka panel Tentang Kami
    /// Dihubungkan ke tombol "Tentang Kami"
    /// 
    /// TODO: Implementasi panel About Us kemudian
    /// </summary>
    public void OpenAboutUs()
    {
        Debug.Log("Opening About Us Panel...");
        
        // Placeholder untuk sekarang
        // Bisa dikembangkan menjadi panel dengan informasi game/developer
    }

    /// <summary>
    /// Fungsi untuk keluar dari game
    /// Dihubungkan ke tombol "Keluar"
    /// </summary>
    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
        
        // Untuk di Unity Editor: hentikan Play Mode
        // Untuk di Build: tutup aplikasi
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
