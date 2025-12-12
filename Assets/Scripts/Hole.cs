using UnityEngine;
using UnityEngine.SceneManagement;

public class Hole : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            Debug.Log("Ball fell into hole!");
            GameManager.Instance.RestartLevel();
        }
    }
}