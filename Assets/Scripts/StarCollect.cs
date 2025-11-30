using UnityEngine;

public class StarCollect : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            GameManager.Instance.AddStar();
            Destroy(gameObject);
        }
    }
}