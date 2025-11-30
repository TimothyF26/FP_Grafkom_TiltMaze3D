using UnityEngine;

public class BoardTiltController : MonoBehaviour
{
    public float maxTilt = 10f;
    public float tiltSpeed = 5f;
    public float resetSpeed = 3f;

    private float inputX;
    private float inputZ;

    void Update()
    {
        inputX = Input.GetAxis("Horizontal");   // A = -1 , D = 1
        inputZ = Input.GetAxis("Vertical");     // W = 1 , S = -1

        Vector3 targetRotation;

        if (Mathf.Abs(inputX) > 0.01f || Mathf.Abs(inputZ) > 0.01f)
        {
            targetRotation = new Vector3(
                inputZ * maxTilt,
                0f,
                -inputX * maxTilt
            );
        }
        else
        {
            targetRotation = Vector3.zero;
        }
        transform.rotation = Quaternion.Lerp(
            transform.rotation,
            Quaternion.Euler(targetRotation),
            Time.deltaTime * tiltSpeed
        );
    }
}