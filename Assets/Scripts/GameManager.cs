using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{   
    public Player player;
    public GameObject bullets;
    public GameObject playButton;
    public GameObject replayButton;
    public Text scoreTxt;
    public GameObject cannonHolder;
    public GameObject cannonHolder1;
    public GameObject cannonHolder2;
    public GameObject cannonHolder3;
    // Start is called before the first frame update
    int score = 0;
    bool isPlaying = true;
    bool isGameOver;

    private void Awake() {
        Application.targetFrameRate = 60;
        playButton.SetActive(true);
        Pause();
    }
    private void Update() {
        if(!isPlaying) {
            if(Input.GetKeyDown(KeyCode.Space)) {
                Play();
            }
        }
    }
    public void IncreasingScore() {
        if (!isGameOver) {
            
            score++;
            
            scoreTxt.text = "Score: " + score.ToString();
            if(score == 5) {
                cannonHolder1.SetActive(true);
            }
            if(score == 10) {
                cannonHolder2.SetActive(true);
            }
            if(score == 15) {
                cannonHolder3.SetActive(true);
            }
        }
        
    }
    public bool CheckGameOver() {
        return isGameOver;
    }
    public void GameOver() {
        isGameOver = true;
        Pause();
        replayButton.SetActive(true);
        cannonHolder.GetComponent<Animator>().enabled = false;
        cannonHolder.SetActive(false);
        cannonHolder1.SetActive(false);
        cannonHolder2.SetActive(false);
        cannonHolder3.SetActive(false);
        
    }
    public void Play() {
        score = 0;
        scoreTxt.text = "Score: " + score.ToString();
        
        isPlaying = true;
        isGameOver = false;

        Time.timeScale = 1f;
        player.enabled = true;
        playButton.SetActive(false);
        replayButton.SetActive(false);
        cannonHolder.SetActive(true);
    }
    public void Pause() {
        Time.timeScale = 0f;
        player.enabled = false; 
        isPlaying = false;
        isGameOver = true;
    }

    
}
