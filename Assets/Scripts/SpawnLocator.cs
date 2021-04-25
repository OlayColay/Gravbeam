using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLocator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Debug.Log("Sending player to checkpoint #" + Globals.curCheckpoint);
        transform.position = GameObject.FindGameObjectWithTag("CheckpointController")
                                        .transform.GetChild(Globals.curCheckpoint).position;
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        // Start camera at player's position so starting isn't so jerky
        // TODO: Fix/hide this issue entirely (hiding could be done with a loading screen)
        GameObject.FindGameObjectWithTag("MainCamera").transform.position = 
            new Vector3(transform.position.x, transform.position.y, -10);
    }
}
