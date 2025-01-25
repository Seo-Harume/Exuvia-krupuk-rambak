using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private StarterAssets.StarterAssetsInputs _input;
    public GameObject pauseMenuUI;
    public GameObject settingsMenuUI;
    private bool isPaused = false;

    // Variabel untuk melacak panel aktif
    private enum ActivePanel { None, PauseMenu, Settings }
    private ActivePanel currentPanel = ActivePanel.None;

    //Variabel Buat Underline Effect
    public UnderlineEffect[] underlineEffects;

    void Start()
    {
        _input = FindObjectOfType<StarterAssets.StarterAssetsInputs>();
        if (_input == null)
        {
            Debug.LogError("StarterAssetsInputs not found. Ensure it's added to the player character.");
        }

        // Pastikan kursor terkunci dan tidak terlihat di awal permainan
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (_input != null && _input.pause)
        {
            if (currentPanel == ActivePanel.Settings)
            {
                // Tutup Settings dan kembali ke Pause Menu
                OpenPauseMenu();
            }
            else if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }

            _input.pause = false;
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        settingsMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        currentPanel = ActivePanel.None;
        ResetUnderlines();

        // Kembalikan kursor ke kondisi terkunci dan tidak terlihat
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        settingsMenuUI.SetActive(false);
        Time.timeScale = 0f;
        isPaused = true;
        currentPanel = ActivePanel.PauseMenu;
        ResetUnderlines();

        // Bebaskan kursor dan buat terlihat
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Setting()
    {
        settingsMenuUI.SetActive(true);
        pauseMenuUI.SetActive(false);
        currentPanel = ActivePanel.Settings;
        Debug.Log("Setting Menu Dibuka");
        ResetUnderlines();
    }

    public void OpenPauseMenu()
    {
        settingsMenuUI.SetActive(false);
        pauseMenuUI.SetActive(true);
        currentPanel = ActivePanel.PauseMenu;
        Debug.Log("Kembali ke Pause Menu");
    }

    public void QuitToMenu()
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true; // Bebaskan kursor di menu utama
        SceneManager.LoadScene("Main Menu");
        ResetUnderlines();
    }

    private void ResetUnderlines()
    {
        if (underlineEffects != null)
        {
            foreach (UnderlineEffect underline in underlineEffects)
            {
                underline.HideUnderline(); // Sembunyikan semua underline
            }
        }
    }
}
