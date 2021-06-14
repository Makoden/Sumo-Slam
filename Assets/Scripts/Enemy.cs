using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{   [SerializeField]
    private float speed = 3f;
    private Rigidbody enemyRb;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.Find("Player");

        // Causes enemy to go towards player
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;

        enemyRb.AddForce(lookDirection * speed);
        if (transform.position.y <= -5)
        {
            Destroy(gameObject);
        }
    }
}
