using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCamWindowMovement : MonoBehaviour {


    // Start is called before the first frame update
    void Start() {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ChangeCamWindow>().changeWindow(/*false, false, new Vector2(4, 4), */5/*, Vector2.zero, Vector2.zero*/);
    }

    // Update is called once per frame
    void Update() {
        
    }


}
