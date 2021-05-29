using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(BoxCollider2D))]
public class DoorTrigger : MonoBehaviour
{
    [SerializeField] private float animationTime = 1f;
    [SerializeField] private float doorLength = 1f;

    void OnDrawGizmos()
    {
        GetComponent<BoxCollider2D>().offset = Vector2.zero;

        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(transform.position, GetComponent<BoxCollider2D>().size);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player" || other.tag == "Beamable")
        {
            this.GetComponent<SpriteRenderer>().enabled = false;
            Transform door = transform.GetChild(0);
            door.DOLocalMove(new Vector2(door.localPosition.x, door.localPosition.y + doorLength), animationTime);
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}