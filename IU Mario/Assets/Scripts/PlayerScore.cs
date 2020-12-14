using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerScore : MonoBehaviour
{
    // Start is called before the first frame update
    
    public int playerScore = 0;
    public GameObject playerScoreUI;
    public GameObject _gameWinText;
    public bool gameWin = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //playerScoreUI.gameObject.GetComponent<Text>().text = ("Score: " + playerScore);
        if (Input.GetKeyDown(KeyCode.R) && gameWin)
            SceneManager.LoadScene("Level1");

    
    }

    void OnTriggerEnter2D (Collider2D trig) {
        if (trig.gameObject.name == "Banner1") {
            SceneManager.LoadScene("Level2");
            //CountScore();
        }
        if (trig.gameObject.name == "Banner2"){
            SceneManager.LoadScene("Level3");
            //CountScore();
        }
        if (trig.gameObject.name == "Banner3"){
            SceneManager.LoadScene("Level4");
            //CountScore();
        }
        if (trig.gameObject.name == "Banner4"){
            SceneManager.LoadScene("Level5");
            //CountScore();
        }
        if (trig.gameObject.name == "Banner5"){
            _gameWinText.SetActive(true);
            gameWin = true;
            _gameWinText.SetActive(true);


            //CountScore();
        }
    }

    void CountScore() {
        //playerScore += 100;
    }
}
