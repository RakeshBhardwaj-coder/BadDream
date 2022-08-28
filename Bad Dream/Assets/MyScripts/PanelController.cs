using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PanelController : MonoBehaviour
{
    public GameObject mainMenuPanel;
    void Start(){
        mainMenuPanel.SetActive(false);
    }
    public void PauseBtn(){
        mainMenuPanel.SetActive(true);
        PauseGame();
    }
    void PauseGame(){
        Time.timeScale = 0f;
    }public void ResumeGame(){
        Time.timeScale = 1f;
    }public void RestartGame(){
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
     public void QuitBtn(){
        Application.Quit();
    }
}
