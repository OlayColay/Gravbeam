using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollowX : MonoBehaviour
{
    private Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 temp = new Vector3(0,0,-1);
        temp = playerTransform.position;
        temp.x = playerTransform.position.x;
        temp.y = 0;
        temp.z = -1; // to show the scene


        transform.position = temp;
        
    }
}
