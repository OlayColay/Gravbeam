using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script is used to change the camera's "window"
/// </summary>
public class ChangeCamWindow : MonoBehaviour {

    bool followAlongX;
    bool followAlongY;
    Vector2 windowCenterPos;
    float windowSizeX;
    float windowSizeY;

    Transform cameraPos;

    // Start is called before the first frame update
    void Start() {
            
    }

    // Update is called once per frame
    void Update() {
        
    }

    /// <summary>
    /// Call this function to change the camera window
    /// </summary>
    /// <param name="followAlongX">Whether the camera follows the player's x position</param>
    /// <param name="followAlongY">Whether the camera follows the player's y position</param>
    /// <param name="windowCenterPos">the position (Vector2) of the center of the window</param>
    /// <param name="windowSizeY">The height of the window (aspect ratio 16:9)</param>
    public void changeWindow(bool followAlongX, bool followAlongY, Vector2 windowCenterPos, float windowSizeY) {
        this.followAlongX = followAlongX;
    }

}
