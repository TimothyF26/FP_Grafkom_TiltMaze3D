using UnityEngine;

public class StarCollect : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            GameManager.Instance.AddStar();
            UIManager.Instance.UpdateStarsUI(GameManager.Instance.collectedStars);
            Destroy(gameObject);
        }
    }
}