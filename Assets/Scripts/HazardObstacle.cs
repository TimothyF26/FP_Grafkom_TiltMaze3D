using UnityEngine;

public class HazardObstacle : MonoBehaviour
{
    // =================== SECTION 1: DEKLARASI VARIABLE ===================
    // Variable untuk menyimpan posisi awal player
    private Vector3 playerStartPosition;
    
    // Referensi ke Rigidbody player untuk reset velocity
    private Rigidbody playerRigidbody;
    
    // Referensi ke Transform player untuk mengubah posisi
    private Transform playerTransform;
    
    // Flag untuk mencegah multiple collision dalam 1 frame
    private float lastCollisionTime = -1f;
    private float collisionCooldown = 0.5f; // Cooldown 0.5 detik
    
    // =================== SECTION 2: INITIALIZATION ===================
    private void Start()
    {
        // Cari player dengan tag "Ball"
        // CompareTag() lebih efficient daripada GetComponent
        GameObject playerObject = GameObject.FindWithTag("Ball");
        
        if (playerObject == null)
        {
            Debug.LogError("Tidak ada objek dengan tag 'Ball' di scene!");
            return;
        }
        
        // Ambil component yang diperlukan dari player
        playerTransform = playerObject.transform;
        playerRigidbody = playerObject.GetComponent<Rigidbody>();
        
        // Simpan posisi awal player
        playerStartPosition = playerTransform.position;
        
        Debug.Log($"Hazard initialized. Player start position: {playerStartPosition}");
    }
    
    // =================== SECTION 3: COLLISION DETECTION ===================
    // OnTriggerEnter dipanggil sekali saat pertama kali collider lain masuk
    private void OnTriggerEnter(Collider other)
    {
        // Cek apakah objek yang menyentuh adalah player (dengan tag "Ball")
        if (other.CompareTag("Ball"))
        {
            // Cek cooldown untuk mencegah multiple reset dalam waktu singkat
            if (Time.time - lastCollisionTime < collisionCooldown)
            {
                return; // Keluar jika masih dalam cooldown
            }
            
            // Update waktu collision terakhir
            lastCollisionTime = Time.time;
            
            // Panggil fungsi untuk reset player
            ResetPlayerToStart(other.gameObject);
        }
    }
    
    // =================== SECTION 4: RESET LOGIC ===================
    private void ResetPlayerToStart(GameObject player)
    {
        // Cek apakah reference player masih valid
        if (playerTransform == null || playerRigidbody == null)
        {
            Debug.LogError("Player reference tidak valid!");
            return;
        }
        
        // STEP 1: Hentikan semua gerakan player
        // Set velocity (kecepatan linear) ke nol
        playerRigidbody.linearVelocity = Vector3.zero;
        
        // Set angular velocity (rotasi) ke nol
        playerRigidbody.angularVelocity = Vector3.zero;
        
        // STEP 2: Kembalikan posisi player ke posisi awal
        playerTransform.position = playerStartPosition;
        
        // Opsional: Reset rotasi player jika diperlukan
        // playerTransform.rotation = Quaternion.identity;
        
        // STEP 3: Feedback ke player
        Debug.Log("Player terkena hazard! Posisi di-reset.");
        
        // Opsional: Increment counter hazard hits (jika ada di GameManager)
        // GameManager.Instance.hazardHits++;
    }
    
    // =================== SECTION 5: GIZMOS (DEBUGGING) ===================
    // Fungsi ini hanya untuk debugging di Scene view, tidak mempengaruhi gameplay
    private void OnDrawGizmos()
    {
        // Gambar sphere merah di posisi hazard saat edit mode
        Gizmos.color = Color.red;
        
        // GetComponent hanya di editor, tidak di runtime
        Collider col = GetComponent<Collider>();
        if (col != null)
        {
            Gizmos.DrawWireCube(transform.position, Vector3.one);
        }
    }
}
