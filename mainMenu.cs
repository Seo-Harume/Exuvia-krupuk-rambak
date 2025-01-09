using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [Header("Canvas References")]
    public GameObject mainMenuCanvas;
    public GameObject settingsCanvas;
    public GameObject exitCanvas;

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

    // Tampilkan Exit Popup
    public void ExitPopup()
    {
        exitCanvas.SetActive(true);
    }

    // Sembunyikan Exit Popup
    public void CancelExit()
    {
        exitCanvas.SetActive(false);
    }

    // Keluar dari Game
    public void ExitGame()
    {
        Debug.Log("Game exited.");
        Application.Quit();
    }
}
