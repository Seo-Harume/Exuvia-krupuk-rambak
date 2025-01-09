using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalCursorController : MonoBehaviour
{
    private void Start()
    {
        // Pastikan script tidak dihancurkan ketika scene berubah
        DontDestroyOnLoad(gameObject);

        // Atur pengaturan kursor saat scene dimulai
        UpdateCursorState(SceneManager.GetActiveScene().name);
    }

    private void OnEnable()
    {
        // Dengarkan event saat scene berubah
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        // Hentikan pendengaran event
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Update pengaturan kursor berdasarkan scene
        UpdateCursorState(scene.name);
    }

    private void UpdateCursorState(string sceneName)
    {
        if (sceneName == "GameScene")
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
