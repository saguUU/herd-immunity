﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class checkWin : MonoBehaviour
{
    private GameObject[] detectors;
    public bool winState = false;

    public AudioSource winSound;

    public GameObject loseMessage;

    public GameObject winMessage;

    public float gameTime;

    public Text timerText;

    private float gameLost;

    public int sceneIndex;

    private float gameWon;

    // Start is called before the first frame update
    void Start()
    {
        detectors = GameObject.FindGameObjectsWithTag("Detector");
        loseMessage.SetActive(false);
        winMessage.SetActive(false);
        gameLost = 0;
        gameWon = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(!winState){
            foreach(GameObject detector in detectors){
                if(detector.GetComponent<detectAnimal>().winnable){
                    winState = true;
                }
                else{
                    winState = false;
                    break;
}
            }
            if(winState && gameLost==0){
            UnityEngine.Debug.Log("WIN!");
            gameWon = 1;
            winSound.Play();
            winMessage.SetActive(true);
}
        }
        gameTime -= 1 * Time.deltaTime;

        string minutes = ((int) gameTime/60).ToString();
        string seconds = (gameTime % 60).ToString("f0");

        if(gameTime > 0){

        timerText.text= minutes + ":" + seconds;
        }
        else if(gameTime<0)
        {
            timerText.text= "";
        }


        if(gameTime < 0 && gameWon== 0)
        { //LOSE
            loseMessage.SetActive(true);
            gameLost = 1;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneLoader(sceneIndex);
            }
        }
    }

    public void SceneLoader(int SceneIndex)
    {
        SceneManager.LoadScene(SceneIndex);
    }
}
