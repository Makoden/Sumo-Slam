using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SpawnManager : MonoBehaviour
{
    

    [SerializeField]
    private GameObject enemyPrefab;
    
    [SerializeField]
    float spawnRange = 9.0f;
    [SerializeField]
    int enemyCount= 1;
    [SerializeField]
    int waveNumber = 1;
    [SerializeField]
    GameObject powerUpPrefab;
    [SerializeField]
    GameObject deathPipe;
    [SerializeField]
    GameObject player;
    
    public GameObject spawnedPipe;
    public Text waveNum;
   
    
    public bool gameIsOn = true;
   
    
    // Start is called before the first frame update
    void Start()
    {
        
        //this actually spawns the enemy
        SpawnEnemyWave(waveNumber);
        Instantiate(powerUpPrefab, GenerateSpawnPosition(), powerUpPrefab.transform.rotation);
        spawnedPipe = Instantiate(deathPipe, GenerateSpawnPosition(), deathPipe.transform.rotation);
        
    }

    // Update is called once per frame
    void Update()
    {
       
        enemyCount = FindObjectsOfType<Enemy>().Length;
        
        if (enemyCount == 0 )
        {
            //adjusts number of enemies per wave and spawns powerup with each wave
            
            if (gameIsOn == true)
            {
                waveNumber++;
                SpawnEnemyWave(waveNumber);
                
                
                spawnedPipe = Instantiate(deathPipe, GenerateSpawnPosition(), deathPipe.transform.rotation);

                Instantiate(powerUpPrefab, GenerateSpawnPosition(), powerUpPrefab.transform.rotation);
            }
        
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            gameIsOn = true;
            waveNum.text = "Wave Number 1";
            DestroyPipes();
        }
        if (player.transform.position.y < -15)
        {
            
            gameIsOn = false;
            waveNumber = 0;
        }

    }
    void SpawnEnemyWave(int enemiesToSpawn)
    {
        waveNum.text = "Wave Number " + waveNumber;
        for (int i = 0; i < enemiesToSpawn; i++)
            {
                Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
            }
        
    }
    // Randomly Generates Enemy Position
    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);

        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);

        return randomPos;
    }
    void DestroyPipes()
    {
        GameObject.FindGameObjectsWithTag("Pipe");
        {
            Destroy(gameObject);
        }
    }
}
