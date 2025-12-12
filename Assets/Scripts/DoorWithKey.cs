using UnityEngine;

public class DoorWithKey : MonoBehaviour
{
    // Berapa kunci yang dibutuhkan untuk buka pintu
    public int keysRequired = 2;
    
    // Untuk tracking apakah pintu sudah terbuka
    private bool isOpen = false;
    
    // Kecepatan pintu naik saat dibuka
    public float openSpeed = 5f;
    
    // Posisi pintu saat sudah sepenuhnya terbuka
    private Vector3 openPosition;
    
    // Posisi pintu di awal game
    private Vector3 closedPosition;

    private void Start()
    {
        // Simpan posisi awal pintu
        closedPosition = transform.position;
        
        // Posisi terbuka = naik 3 unit ke atas
        openPosition = closedPosition + Vector3.up * 3f;
    }

    private void Update()
    {
        // Cek apakah sudah ada 2 kunci dan pintu belum terbuka
        if (GameManager.Instance.collectedKeys >= keysRequired && !isOpen)
        {
            OpenDoor();
        }

        // Jika pintu sedang terbuka, gerakkan ke atas
        if (isOpen && transform.position != openPosition)
        {
            transform.position = Vector3.Lerp(
                transform.position, 
                openPosition, 
                openSpeed * Time.deltaTime
            );
        }
    }

    private void OpenDoor()
    {
        isOpen = true;
        Debug.Log("Door opened! You collected all keys!");
        
        // Hapus collider sehingga bola bisa lewat
        Collider doorCollider = GetComponent<Collider>();
        if (doorCollider != null)
        {
            doorCollider.enabled = false;  // Nonaktifkan collider
        }
    }
}
