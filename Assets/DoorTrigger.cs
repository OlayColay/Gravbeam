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

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, GetComponent<BoxCollider2D>().size);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player" || other.tag == "Rock")
        {
            Transform door = transform.GetChild(0);
            door.DOLocalMoveY(doorLength, animationTime);
        }
    }
}