using UnityEngine;

public class StarSpin : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(0f, 90f * Time.deltaTime, 0f);
    }
}