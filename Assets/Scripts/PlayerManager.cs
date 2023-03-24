using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerManager : MonoBehaviour {

    public static bool gameOver;
    public GameObject gameOverPanel;

    public static bool isGameStarted;
    public GameObject startingText;

    public static int numGems;
    public TextMeshProUGUI gemsText;

    // Start is called before the first frame update
    void Start() {

        Time.timeScale = 1;
        gameOver = false;
        isGameStarted = false;
        numGems = 0;
    }

    // Update is called once per frame
    void Update() {

        gemsText.text = "Gems: " + numGems;

        if (gameOver) {

            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
        }

        if (Input.GetMouseButtonDown(0) || Input.anyKeyDown) {

            if (isGameStarted == false) {
                isGameStarted = true;
                Destroy(startingText);
                FindObjectOfType<AudioManager>().playSound("Theme");
            }
            
           
        }


        
    }
}
