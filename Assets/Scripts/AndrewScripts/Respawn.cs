using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(BoxCollider2D))]
public class Respawn : MonoBehaviour
{
    private GameObject player;
    private Animator am;
    // [SerializeField] private Transform spawnPoint;
    private Rigidbody2D rb;
    private CapsuleCollider2D cc;
    private LoadingScreen ls;
    private Vector2 hitVelo = new Vector2(0f, 50f);
    private int faceRight = 1;

    private bool isGravity;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        am = player.GetComponent<Animator>();
        rb = player.GetComponent<Rigidbody2D>();
        cc = player.GetComponent<CapsuleCollider2D>();
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

            PlatformerCharacter2D script = player.GetComponent<PlatformerCharacter2D>();
            if (script == null)
                isGravity = false;
            else
                isGravity = true;

            // Freeze Player if hit a spike (tag = lethal_freeze)
            am.SetBool("Dead", true);
            // gameObject.GetComponent<BoxCollider2D>().enabled = false;
            player.GetComponent<PlatformerCharacter2D>().enabled = false;
            if (gameObject.tag == "Lethal_Freeze")
            {
                rb.velocity = Vector2.zero;
                // if (player.transform.rotation.y != 0f)
                //    faceRight = -1;
                // else
                //     faceRight = 1;
                // hitVelo.x = faceRight * 20f;
                // rb.velocity = hitVelo;
                // rb.constraints = RigidbodyConstraints2D.FreezeAll;
                if(isGravity)
                {
                    rb.velocity = hitVelo;
                    cc.enabled = false;
                }
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
