using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [Header("Canvas References")]
    public GameObject mainMenuCanvas;
    public GameObject settingsCanvas;

    public void StartGame()
    {
        // Ganti "GameScene" dengan nama scene game Anda
        SceneManager.LoadScene("GameScene");
    }

    // Tampilkan Settings dan sembunyikan Main Menu
    public void OpenSettings()
    {
        mainMenuCanvas.SetActive(false);
        settingsCanvas.SetActive(true);
    }

    // Tampilkan Main Menu dan sembunyikan Settings
    public void BackToMainMenu()
    {
        settingsCanvas.SetActive(false);
        mainMenuCanvas.SetActive(true);
    }

    public void ExitGame()
    {
        Debug.Log("Game exited.");
        Application.Quit();
    }
}
