using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFlow : MonoBehaviour
{
    public GameObject winPanel;
    public GameObject losePanel;
    public GameObject player;

    public void OnGameWin(){
        winPanel.SetActive(true);
        StopGame();
    }
    public void OnGameLose(){
        losePanel.SetActive(true);
        StopGame();
    }
    private void StopGame(){
        Time.timeScale = 0;
        player.GetComponent<MoveByMouse>().enabled = false;
        player.GetComponent<AutomaticShooting>().enabled = false;
    }
}
