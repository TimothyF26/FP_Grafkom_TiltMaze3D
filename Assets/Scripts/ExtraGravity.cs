using UnityEngine;

public class ExtraGravity : MonoBehaviour
{
    public float extraGravity = 15f;   // nilai normalnya 0 → kita tambah 15
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Tambah gravitasi ke bawah secara manual
        rb.AddForce(Vector3.down * extraGravity, ForceMode.Acceleration);
    }
}