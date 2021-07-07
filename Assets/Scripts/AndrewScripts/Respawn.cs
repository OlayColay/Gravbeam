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
    private BoxCollider2D cl;
    private LoadingScreen ls;
    private Vector2 hitVelo = new Vector2(0f, 40f);
    // private int faceRight = 1;
    private bool isGravity;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        am = player.GetComponent<Animator>();
        rb = player.GetComponent<Rigidbody2D>();
        cl = gameObject.GetComponent<BoxCollider2D>();
        ls = GameObject.FindGameObjectWithTag("MainCamera").transform.GetChild(0).GetComponent<LoadingScreen>();
    }

    private void OnDrawGizmos()
    {
        //GetComponent<BoxCollider2D>().offset = Vector2.zero;

        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position + (Vector3)GetComponent<BoxCollider2D>().offset, GetComponent<BoxCollider2D>().size * transform.localScale);    //Offset allowed
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlatformerCharacter2D script = player.GetComponent<PlatformerCharacter2D>();
            if (script == null)
            {
                isGravity = false;
                player.GetComponent<BeamScript>().controls.Disable();
            }
            else
            {
                isGravity = true;
                script.controls.Disable();
                player.GetComponent<RopeSystem>().ResetRope();
                player.GetComponent<RopeSystem>().enabled = false;
            }
            // Freeze Player if hit a spike (tag = lethal_freeze)
            // gameObject.GetComponent<BoxCollider2D>().enabled = false;
            // player.GetComponent<PlatformerCharacter2D>().enabled = false;
            if (gameObject.tag == "Lethal_Freeze")
            {
                cl.isTrigger = false;
                am.SetBool("Dead", true);

                rb.simulated = false;

                // // if (player.transform.rotation.y != 0f)
                // //    faceRight = -1;
                // // else
                // //     faceRight = 1;
                // // hitVelo.x = faceRight * 20f;
                // // rb.velocity = hitVelo;
                // // rb.constraints = RigidbodyConstraints2D.FreezeAll;
                // if (isGravity)
                // {
                //     rb.velocity = hitVelo;
                // }
                player.GetComponent<ParticleSystem>().Play(false);
                player.GetComponent<SpriteRenderer>().enabled = false;
            }

            ls.FadeIn();
            // player.GetComponent<PlatformerCharacter2D>().controls.Disable();
            StartCoroutine(WaitForDeath());
        }
    }

    private IEnumerator WaitForDeath()
    {        
        yield return new WaitForSeconds(1f);
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
