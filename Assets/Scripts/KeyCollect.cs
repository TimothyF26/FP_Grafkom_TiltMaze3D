using UnityEngine;

public class KeyCollect : MonoBehaviour
{
    // Variable untuk tahu ini kunci nomor berapa (1 atau 2)
    public int keyID = 1;

    private void OnTriggerEnter(Collider other)
    {
        // Cek apakah bola menyentuh kunci
        if (other.CompareTag("Ball"))
        {
            // Tambahkan kunci ke GameManager
            GameManager.Instance.AddKey(keyID);
            
            // Update UI untuk tampilkan berapa kunci sudah dikumpulkan
            UIManager.Instance.UpdateKeysUI(GameManager.Instance.collectedKeys);
            
            // Hapus kunci dari game
            Destroy(gameObject);
        }
    }
}
