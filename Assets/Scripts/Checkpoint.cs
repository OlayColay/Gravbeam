using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Checkpoint : MonoBehaviour
{
    void OnDrawGizmos()
    {
        GetComponent<BoxCollider2D>().offset = Vector2.zero;

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, GetComponent<BoxCollider2D>().size);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player" && Globals.curCheckpoint < transform.GetSiblingIndex())
        {
            Globals.curCheckpoint = transform.GetSiblingIndex();
            Debug.Log("Checkpoint number is now " + Globals.curCheckpoint);
        }
    }
}
