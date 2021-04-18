using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private Vector3[] positions;
    [SerializeField] private float timeBetweenEachPosition = 1f;
    private int curPosIndex = 1;
    private float distance = 0f;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, positions[curPosIndex], distance / Time.fixedDeltaTime / timeBetweenEachPosition);

        if (transform.position == positions[curPosIndex])
        {
            curPosIndex = (curPosIndex + 1 < positions.Length) ? curPosIndex + 1 : 0;
            distance = Vector3.Distance(transform.position, positions[curPosIndex]);
        }
    }
}
