using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class MainMenu : MonoBehaviour
{
    [Header("Canvas References")]
    public GameObject mainMenuCanvas;
    public GameObject settingsCanvas;
    public GameObject exitCanvas;
    public GameObject loadingScreenCanvas; // Tambahkan ini untuk Loading Screen

    [Header("Loading Screen UI")]
    public TMP_Text progressText;  // Text untuk persen progress

    public void StartGame()
    {
        // Nonaktifkan Main Menu dan aktifkan Loading Screen
        mainMenuCanvas.SetActive(false);
        loadingScreenCanvas.SetActive(true);

        // Mulai loading scene secara asinkron
        StartCoroutine(LoadSceneAsync("GameScene"));
    }

    private IEnumerator LoadSceneAsync(string sceneName)
    {
        // Mulai loading scene
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);

        // Pastikan scene tidak langsung diaktifkan
        operation.allowSceneActivation = false;

        while (!operation.isDone)
        {
            // Hitung progress
            float progress = Mathf.Clamp01(operation.progress / 0.9f);

            // Update UI
            progressText.text = $"Loading... {Mathf.RoundToInt(progress * 100)}%";

            // Jika progress sudah mencapai 90%, tunggu input user atau lanjutkan otomatis
            if (operation.progress >= 0.9f)
            {
                progressText.text = "Press any key to continue...";
                if (Input.anyKeyDown)
                {
                    operation.allowSceneActivation = true;
                }
            }

            yield return null;
        }
    }

    public void OpenSettings()
    {
        mainMenuCanvas.SetActive(false);
        settingsCanvas.SetActive(true);
    }

    public void BackToMainMenu()
    {
        settingsCanvas.SetActive(false);
        mainMenuCanvas.SetActive(true);
    }

    public void ExitPopup()
    {
        exitCanvas.SetActive(true);
    }

    public void CancelExit()
    {
        exitCanvas.SetActive(false);
    }

    public void ExitGame()
    {
        Debug.Log("Game exited.");
        Application.Quit();
    }
}
