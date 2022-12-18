using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public GameObject returnButton;
    public bool isPaused;
    public GameObject pauseMenu;
    public GameObject startSreen;
    public GameObject player;
    public PlayerControlz playerC;
    public spawner spawnerL;
    public bool startZeG;
    public Animator animaScreen;
    

    // Start is called before the first frame update
    void Start()
    {
        
        startSreen.SetActive(true);
        //pauseMenu.SetActive(false);
        startZeG = false;
        isPaused = true;
        player.SetActive(false);
        playerC = GetComponent<PlayerControlz>();
        spawnerL = GetComponent<spawner>();


    }
    
    void Update()
    {
        if(!startZeG && returnButton)
        {
            Time.timeScale = 0f;
            

        }else
        {
            Time.timeScale = 1f;
            BeginGame();
        }
       /* if (isPaused)
        {

            if (Input.GetKeyDown(KeyCode.JoystickButton7))
            {
                PauseGame();
            }
            else
            {
                UnPausedGame();
            }

        }*/
    }

    public void BeginGame()
    {
        
        startSreen.SetActive(false);
       //pauseMenu.SetActive(false);
        startZeG = true;
        isPaused= false;
        player.SetActive(true);
        playerC.Playing();
        spawnerL.SpawnLollies();

    }
  

    public void PauseGame()
    {
        //pauseMenu.SetActive(true);
        
        Time.timeScale = 0f;

    }
  
    public void UnPausedGame()
    {
       
       // menuForPaused.SetActive(false);
        Time.timeScale = 1f;

    }
    //public void PauseMenuUnPauseButton()
    //{
      //  player.canPause = false;
       // preventDeselection.SelectNewButton(startButton);
    //}

    // public void GameOver()
    // {
      //  animaScreen.SetBool("Lose");
    // }*/
}
