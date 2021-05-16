﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(BoxCollider2D))]
public class Respawn : MonoBehaviour
{
    private GameObject player;
    // [SerializeField] private Transform spawnPoint;
    private Rigidbody2D rb;
    private LoadingScreen ls;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = player.GetComponent<Rigidbody2D>();
        ls = GameObject.FindGameObjectWithTag("MainCamera").transform.GetChild(0).GetComponent<LoadingScreen>();
    }

    private void OnDrawGizmos()
    {
        //GetComponent<BoxCollider2D>().offset = Vector2.zero;

        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position + (Vector3)GetComponent<BoxCollider2D>().offset, GetComponent<BoxCollider2D>().size);    //Offset allowed
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            // Freeze Player if hit a spike (tag = lethal_freeze)
            if (gameObject.tag == "Lethal_Freeze")
            {
                rb.constraints = RigidbodyConstraints2D.FreezeAll;
            }

            ls.triggerFadeIn = true;
            player.GetComponent<PlatformerCharacter2D>().controls.Disable();
            StartCoroutine(WaitForDeath());
        }
    }

    private IEnumerator WaitForDeath()
    {        
        while(ls.triggerFadeIn)
        {
            yield return null;
        }
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
