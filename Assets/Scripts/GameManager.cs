using System;
using UnityEngine;
using UnityEngine.InputSystem.HID;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager: Sounds
{
    public Button start, settings, quit, back;
    public GameObject menuPanel, staminaUI, inventoryPanel, batteryValue, healthBar;
    public GameObject continueButton, restart, menuSettings, mainMenu, menuQuit, menuBack;
    public string currentLevel;
    private bool isPaused;
    
    public void StartGame()
    {
        SceneManager.LoadScene("Hub");
    }

    private void Update()
    {
        currentLevel = SceneManager.GetActiveScene().name;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }

        if (currentLevel == "Main menu")
        {
            PlaySound(sounds[0], 0.25f, false);
        }
    }
    
    public void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            // Останавливаем время в игре
            Time.timeScale = 0f;
            AudioListener.pause = true;
            menuPanel.SetActive(true);
            if (SceneManager.GetActiveScene().name != "Hub")
            {
                staminaUI.SetActive(false);
                inventoryPanel.SetActive(false);
                batteryValue.SetActive(false);
                healthBar.SetActive(false);
            }
        }
        else
        {
            // Возобновляем игру
            Time.timeScale = 1f;
            AudioListener.pause = false;
            menuPanel.SetActive(false);
            if (SceneManager.GetActiveScene().name != "Hub")
            {
                staminaUI.SetActive(true);
                inventoryPanel.SetActive(true);
                batteryValue.SetActive(true);
                healthBar.SetActive(true);
            }
        }
    }

    public void Continue()
    {
        isPaused = false;
        Time.timeScale = 1f;
        AudioListener.pause = false;
        menuPanel.SetActive(false);
        if (SceneManager.GetActiveScene().name != "Hub")
        {
            staminaUI.SetActive(true);
            inventoryPanel.SetActive(true);
            batteryValue.SetActive(true);
            healthBar.SetActive(true);
        }
    }
    
    public void MainMenuSettings()
    {
        start.gameObject.SetActive(false);
        settings.gameObject.SetActive(false);
        quit.gameObject.SetActive(false);
        back.gameObject.SetActive(true);
    }

    public void MenuSettings()
    {
        continueButton.SetActive(false);
        restart.SetActive(false);
        menuSettings.SetActive(false);
        mainMenu.SetActive(false);
        menuQuit.SetActive(false);
        menuBack.SetActive(true);
    }

    public void MenuBack()
    {
        continueButton.SetActive(true);
        restart.SetActive(true);
        menuSettings.SetActive(true);
        mainMenu.SetActive(true);
        menuQuit.SetActive(true);
        menuBack.SetActive(false);
    }
    public void MainMenuBack()
    {
        start.gameObject.SetActive(true);
        settings.gameObject.SetActive(true);
        quit.gameObject.SetActive(true);
        back.gameObject.SetActive(false);
    }

    public void QuitToMainMenu()
    {
        SceneManager.LoadScene("Main menu");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
