using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject playersInfoPanel;
    public GameObject gameFinishedPanel;
    public TMP_Text playerWinnerText;
    public Button backMainMenuButton;
    public Button playAgainButton;    
    
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        ActivatePanel(playersInfoPanel.name);
        playAgainButton.onClick.AddListener(ReloadCurrentScene);
        backMainMenuButton.onClick.AddListener(BackToMainMenu);
    }
    private void ActivatePanel(string panelName)
    {
        playersInfoPanel.SetActive(playersInfoPanel.name.Equals(panelName));
        gameFinishedPanel.SetActive(gameFinishedPanel.name.Equals(panelName));
    }
    private void ReloadCurrentScene()
    {
        Time.timeScale = 1;
        SceneSwitcher.Instance.LoadGameScene();
    }
    private void BackToMainMenu()
    {
        Time.timeScale = 1;
        SceneSwitcher.Instance.LoadMainMenuScene();
    }
    public void ShowWinnerPlayer(PlayerType playerType)
    {
        ActivatePanel(gameFinishedPanel.name);
        if(playerType == PlayerType.Player1)
        {
            playerWinnerText.text = "PLAYER 1 WINS!";
        }
        else if(playerType == PlayerType.Player2)
        {
            playerWinnerText.text = "PLAYER 2 WINS!"; 
        }
    }
    
}
