# Fix: PLAY Button → Level Select Menu

## 🎯 Tujuan
Ketika tombol PLAY ditekan, tampilkan menu pemilihan level (bukan langsung ke lvl1).

## 🔍 Diagnosis

Proyek Anda memiliki **dua script menu yang berbeda**:

### ❌ MenuManager.cs
```csharp
public void StartGame()
{
    // LANGSUNG LOAD lvl1 - SALAH!
    SceneManager.LoadScene("lvl1");
}
```

### ✅ MainMenuController.cs
```csharp
public void OnStartGame()
{
    // Menampilkan level select panel - BENAR!
    OnShowLevelSelect();
}
```

## 📝 Solusi

### **OPSI A: Update MainMenu Scene (Rekomendasi)**

Edit `Assets/Scenes/MainMenu.unity`:

1. **Pilih tombol "PLAY" di Hierarchy**
2. **Di Inspector → Button → On Click ()**
3. **Hapus referensi ke `MenuManager.StartGame()`**
4. **Tambahkan:**
   - Object: Select GameObject yang memiliki `MainMenuController` component
   - Function: `MainMenuController > OnStartGame()`

**Hasil:**
- Click PLAY → `OnStartGame()` dipanggil
- `OnStartGame()` → Panggil `OnShowLevelSelect()`
- Level select panel muncul ✅

---

### **OPSI B: Update MenuManager.cs** (Jika MainMenu Scene pakai MenuManager)

Ganti method `StartGame()` menjadi:

```csharp
public void StartGame()
{
    // Tampilkan level select panel terlebih dahulu
    if (levelSelectPanel != null)
    {
        levelSelectPanel.SetActive(true);
        Debug.Log("[MenuManager] Level Select Panel ditampilkan");
    }
    else
    {
        Debug.LogError("[MenuManager] Level Select Panel belum di-assign!");
    }
}

// Tambahkan reference ke Level Select Panel
[SerializeField] private GameObject levelSelectPanel;
```

---

### **OPSI C: Hapus MenuManager.cs**

Jika tidak digunakan di tempat lain:
1. Delete `Assets/Scripts/MenuManager.cs`
2. Delete `Assets/Scripts/MenuManager.cs.meta`
3. Pastikan semua button di MainMenu Scene pakai `MainMenuController`

---

## ✅ Checklist Setelah Fix

- [ ] Tombol PLAY tersambung ke method yang benar (lihat Console saat Click)
- [ ] Level Select Panel muncul saat PLAY ditekan
- [ ] Tombol Level (1, 2, 3, dst) berfungsi memuat scene yang tepat
- [ ] Tombol BACK menghilangkan Level Select Panel
- [ ] Tidak ada error di Console

---

## 🔧 Debug Tips

1. **Lihat Console saat tekan PLAY:**
   - Harus ada: `"[MainMenuController] Level Select Panel ditampilkan"`
   - Jika ada: `"[MainMenuController] Level Select Panel belum di-assign"` → Assign di Inspector

2. **Debug OnClick di Button:**
   - Click button → Select button GameObject
   - Lihat Inspector panel Button
   - Di "On Click ()" section, pastikan function yang correct terpilih

3. **Verifikasi GameObject Assignment:**
   - `MainMenuController` component harus di-assign di method selector
   - `levelSelectPanel` harus di-assign di Inspector `MainMenuController`

---

## 📚 Flow Diagram

```
MainMenu Scene
    ↓
[PLAY Button Click]
    ↓
MainMenuController.OnStartGame()
    ↓
MainMenuController.OnShowLevelSelect()
    ↓
levelSelectPanel.SetActive(true) ← Panel Level Select Muncul
    ↓
[User Click Level]
    ↓
MainMenuController.OnSelectLevel("lvl2")
    ↓
SceneManager.LoadScene("lvl2")
```

---

**Estimated Time:** 5 menit
**Difficulty:** ⭐ Easy
