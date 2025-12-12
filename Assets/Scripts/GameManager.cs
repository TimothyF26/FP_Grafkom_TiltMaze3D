using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int collectedStars = 0;
    public int collectedKeys = 0;  // BARU: Variable untuk tracking kunci
    public float levelTimer = 0f;
    public bool counting = true;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (counting)
            levelTimer += Time.deltaTime;
    }

    public void AddStar()
    {
        collectedStars++;
    }

    // BARU: Method untuk tambah kunci
    public void AddKey(int keyID)
    {
        collectedKeys++;
        Debug.Log("Key " + keyID + " collected! Total keys: " + collectedKeys);
    }

    public void LevelComplete()
    {
        counting = false;
        UIManager.Instance.ShowLevelComplete(collectedStars);
        Time.timeScale = 0f;
    }

    public void RestartLevel()
    {
        ResetState();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadNextLevel()
    {
        ResetState();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadLevelSelect()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("LevelSelect");
    }

    public void ResetState()
    {
        collectedStars = 0;
        collectedKeys = 0;  // BARU: Reset kunci saat level restart
        levelTimer = 0f;
        counting = true;
        Time.timeScale = 1f;
    }
}
