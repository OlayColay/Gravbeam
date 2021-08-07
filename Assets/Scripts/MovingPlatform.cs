using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    // [SerializeField] private Vector3[] positions;
    // [SerializeField] private float timeBetweenEachPosition = 1f;
    // private int curPosIndex = 1;
    // private float distance = 0f;
    // private float timeSinceLastMove = 0f;
    private Transform savedParent;

    // Update is called once per frame
    // void FixedUpdate()
    // {
    //     transform.position = Vector3.MoveTowards(transform.position, positions[curPosIndex], distance * Time.fixedDeltaTime / timeBetweenEachPosition);
    //     timeSinceLastMove += Time.fixedDeltaTime;

    //     // Debug.Log(transform.position);

    //     if (timeBetweenEachPosition <= timeSinceLastMove)
    //     {
    //         Debug.Log(curPosIndex);
    //         curPosIndex = (curPosIndex + 1 < positions.Length) ? curPosIndex + 1 : 0;
    //         distance = Vector3.Distance(transform.position, positions[curPosIndex]);
    //         timeSinceLastMove = 0f;
    //     }
    // }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision detected with " + collision.gameObject.name);
        if (collision.gameObject.tag == "Player")
        {
            savedParent = collision.transform.parent;
            collision.transform.SetParent(transform);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.transform.SetParent(savedParent);
        }
    }
}
