using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(BoxCollider2D))]
public class Checkpoint : MonoBehaviour
{
    private SpriteRenderer sr;
    [SerializeField] private Sprite checkedWeb;

    void Awake()
    {
        sr = GetComponentInChildren<SpriteRenderer>();
        if (Globals.curCheckpoint >= transform.GetSiblingIndex())
            sr.sprite = checkedWeb;
    }

    void OnDrawGizmos()
    {
        //GetComponent<BoxCollider2D>().offset = Vector2.zero;

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position + (Vector3)GetComponent<BoxCollider2D>().offset, GetComponent<BoxCollider2D>().size);    //Offset allowed
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player" && Globals.curCheckpoint < transform.GetSiblingIndex())
        {
            sr.sprite = checkedWeb;
            Globals.curCheckpoint = transform.GetSiblingIndex();
            // Debug.Log("Checkpoint number is now " + Globals.curCheckpoint);
        }
    }
}
