using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script is used to change the camera's "window"
/// </summary>
public class ChangeCamWindow : MonoBehaviour {

    public float speedOfChange = 5f;
    public AnimationCurve speedVariation;

    bool followAlongX;
    bool followAlongY;
    
    Vector2 windowCenterPos;

    Transform cameraTransform;
    Transform playerTransform;

    Camera cam;

    bool moveDone = true;

    IEnumerator currentCoroutine;

    // Start is called before the first frame update
    void Start() {
        cameraTransform = transform;
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update() {
        if (moveDone) {

        }
    }

    /// <summary>
    /// Call this function to change the camera window
    /// </summary>
    /// <param name="followAlongX">Whether the camera follows the player's x position</param>
    /// <param name="followAlongY">Whether the camera follows the player's y position</param>
    /// <param name="windowCenterPos">The position (Vector2) of the center of the window</param>
    /// <param name="windowSizeY">The height of the window (aspect ratio 16:9)</param>
    public void changeWindow(bool followAlongX, bool followAlongY, Vector2 windowCenterPos, float windowSizeY, Vector2 camBounds) {
        this.followAlongX = followAlongX;
        this.followAlongY = followAlongY;
        this.windowCenterPos = windowCenterPos;

        cam.orthographicSize = windowSizeY / 2;

        StartCoroutine(moveToNewWindow());
    }

    IEnumerator moveToNewWindow() {
        Vector2 camPos = cameraTransform.position;
        while ((camPos - windowCenterPos).magnitude > 0.01) {
            cameraTransform.position = Vector2.MoveTowards(cameraTransform.position, windowCenterPos, speedVariation.Evaluate(speedOfChange * Time.deltaTime));
            yield return null;
        }
    }

    IEnumerator followPlayer() {
        while (true) {
            // TODO implement camera bounds
            if (followAlongX) {
                cameraTransform.position.Set(playerTransform.position.x, cameraTransform.position.y, cameraTransform.position.z);
            }

            if (followAlongY) {
                cameraTransform.position.Set(cameraTransform.position.x, playerTransform.position.y, cameraTransform.position.z);
            }
            yield return null;
        }
    }
}
