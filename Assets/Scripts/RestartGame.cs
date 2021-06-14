using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RestartGame : SpawnManager 
{
    [SerializeField]
    Text gameOver;
    [SerializeField]
    Text restart;
   
    // Start is called before the first frame update
    void Start()
    {
        ResetGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            ResetGame();
        }

        if (player.transform.position.y < -15)
        {
            gameOver.text = "GAME OVER";
            restart.text = "Press Z to Restart";
        }
    }

    private void ResetGame()
    {
        gameOver.text = "";
        restart.text = ""; 
    }
}
