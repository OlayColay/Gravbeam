using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Transform spawnPoint;
    Rigidbody2D rb;
    private void Awake()
    {
        rb = player.GetComponent<Rigidbody2D>();
    }

    /*
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    */

    private void OnTriggerEnter2D(Collider2D collision)
    {
        player.transform.position = spawnPoint.transform.position;
        rb.velocity = Vector2.zero;
    }
}
