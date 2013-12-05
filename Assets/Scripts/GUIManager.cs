using UnityEngine;
using System.Collections;


public class GUIManager : MonoBehaviour {

    public GUIText boostsText, distanceText, gameOverText, instructionsText, runnerText;
    void Start()
    {
        GameEventManager.GameStart += GameStart;
        GameEventManager.GameOver += GameOver;
        gameOverText.enabled = false;
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            GameEventManager.TriggerGameStart();
        }
    }
    private void GameStart()
    {
        gameOverText.enabled = false;
        instructionsText.enabled = false;
        runnerText.enabled = false;
        enabled = false;
    }
    private void GameOver()
    {
        gameOverText.enabled = true;
        instructionsText.enabled = true;
        enabled = true;
    }
}
