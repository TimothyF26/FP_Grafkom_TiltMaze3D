using UnityEngine;

public class LevelSelectPanelController : MonoBehaviour
{
    [SerializeField] private GameObject levelSelectPanel;

    public void ShowLevelSelect()
    {
        if (levelSelectPanel != null)
        {
            levelSelectPanel.SetActive(true);
        }
    }

    public void HideLevelSelect()
    {
        if (levelSelectPanel != null)
        {
            levelSelectPanel.SetActive(false);
        }
    }
}
