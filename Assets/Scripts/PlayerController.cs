using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private GameObject focalPoint;
    [SerializeField]
    float speed = 5.0f;
    [SerializeField]
    float powerUpStrength = 15f;
    [SerializeField]
    private bool hasPowerUps = false;
    [SerializeField]
    private GameObject powerUpIndicator;
    [SerializeField]
    private AudioSource powerBang;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        //moves the player forwards and backwards
        float forwardInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * forwardInput * speed);
        powerUpIndicator.transform.position = transform.position + new Vector3(0, 0.5f, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            //this sets the powerup onto the player and begins the countdown to when the powerup is lost
            hasPowerUps = true;
            powerUpIndicator.gameObject.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
            
        }
    }
    IEnumerator PowerupCountdownRoutine()
    {
        // timer for how long the power up lasts
        yield return new WaitForSeconds(7);
        hasPowerUps = false;
        powerUpIndicator.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerUps)
        {
            // this code causes the enemy to be launched from the player when the player is empowered
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;
            enemyRigidbody.AddForce(awayFromPlayer * powerUpStrength, ForceMode.Impulse);
            Debug.Log("Collided with " + collision.gameObject.name + " with PowerUp set to " + hasPowerUps);
            powerBang.Play();
        } 
    }

}
