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
    [SerializeField]
    GameObject player;
    
    
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
            gameIsOn = true;
        }
        if (player.transform.position.y < -15)
        {
            gameOver.text = "GAME OVER";
            restart.text = "Press Z to Restart";
            Debug.Log("game is over");
            gameIsOn = false;
        }
        
    }
    private void ResetGame()
    {
        player.transform.position = new Vector3(0, 5, 0);
        gameOver.text = "";
        restart.text = "";
        
        
    }
}
