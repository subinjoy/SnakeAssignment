using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    [SerializeField] MainMenu mainMenu;
    [SerializeField] SinglePlayerScreen singlePlayerScreen;
    [SerializeField] MultiplayerScreen MultiplayerScreen;
    [SerializeField] GameOverScreen gameOverScreen;
    [SerializeField] ObjectPooler objectPooler;
    [SerializeField] GameController gameController;
    [SerializeField] public static bool isMultiplayer;
    [SerializeField] GameObject resultDisplay;
    [SerializeField] private Text resultTxt;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
    private void OnEnable()
    {
        mainMenu.Activate();
    }

    public void OnSinglePlayerClick()
    {
        isMultiplayer = false;
        singlePlayerScreen.Activate();
        mainMenu.Deactivate();
        objectPooler.enabled = true;
        gameController.enabled = true;
    }
    public void OnMultiPlayerClick()
    {
        isMultiplayer = true;
        MultiplayerScreen.Activate();
        mainMenu.Deactivate();
        objectPooler.enabled = true;
       
    }
    public void OnMenuClick()
    {
        SceneManager.LoadScene(0);
        singlePlayerScreen.Deactivate();
        MultiplayerScreen.Deactivate();
        mainMenu.Activate();
    }
    public void ShowGameOver(string resultMessage)
    {
        gameOverScreen.Activate();
        if (GetMultiplayerStatus())
        {
            resultDisplay.SetActive(true);
            resultTxt.text = resultMessage;
        }
        else
            resultDisplay.SetActive(false);
    }
    public bool GetMultiplayerStatus()
    {
      
        return isMultiplayer;
    }
}
