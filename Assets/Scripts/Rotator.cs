using UnityEngine;

public class Rotator : MonoBehaviour
{
    // SerializeField agar bisa diedit di Inspector tanpa harus public
    [SerializeField] private float rotationSpeed = 50f;
    
    // Opsi untuk memilih sumbu rotasi jika ingin lebih fleksibel
    [SerializeField] private Vector3 rotationAxis = Vector3.up;

    void Update()
    {
        // Vector3.up berarti sumbu Y (hijau), cocok untuk objek di tanah seperti di gambar
        transform.Rotate(rotationAxis * rotationSpeed * Time.deltaTime);
    }
}
