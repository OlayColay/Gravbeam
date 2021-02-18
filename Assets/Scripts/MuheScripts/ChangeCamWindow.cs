using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script is used to change the camera's "window." Probably doesn't work yet
/// </summary>
public class ChangeCamWindow : MonoBehaviour {

    public float transitionTime = 1f;
    public AnimationCurve speedVariation = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);

    [SerializeField]
    bool followAlongX = true;
    [SerializeField]
    bool followAlongY = true;
    
    Vector2 windowCenterPos;
    float windowInitialSizeY;
    float windowFinalSizeY;

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
        currentCoroutine = followPlayer();
        StartCoroutine(currentCoroutine);
    }

    // Update is called once per frame
    void Update() {
        // TODO Work in progress
        //if (moveDone) {
        //    StopCoroutine(currentCoroutine);
        //    currentCoroutine = followPlayer();
        //    StartCoroutine(currentCoroutine);
       // }
    }

    /// <summary>
    /// Call this function to change the camera window
    /// </summary>
    /// <param name="followAlongX">Whether the camera follows the player's x position</param>
    /// <param name="followAlongY">Whether the camera follows the player's y position</param>
    /// <param name="windowCenterPos">The position (Vector2) of the center of the window</param>
    /// <param name="windowSizeY">The height of the window (aspect ratio 16:9)</param>
    public void changeWindow(bool followAlongX, bool followAlongY, Vector2 windowCenterPos, float windowSizeY, Vector2 camBoundsMin, Vector2 cameraBoundsMax) {
        // TODO Work in progress
        moveDone = false;
        this.followAlongX = followAlongX;
        this.followAlongY = followAlongY;
        this.windowCenterPos = windowCenterPos;

        windowInitialSizeY = cam.orthographicSize;
        windowFinalSizeY = windowSizeY;

        currentCoroutine = moveToNewWindow();

        StartCoroutine(currentCoroutine);
    }

    IEnumerator moveToNewWindow() {
        Vector2 camPos = cameraTransform.position;

        float timer = 0f;

        while (timer < transitionTime) {
            Vector2 tempCamPos = Vector2.Lerp(camPos, windowCenterPos, speedVariation.Evaluate(timer / transitionTime));
            cameraTransform.position = new Vector3(tempCamPos.x, tempCamPos.y, cameraTransform.position.z);
            cam.orthographicSize = Mathf.Lerp(windowInitialSizeY, windowFinalSizeY, speedVariation.Evaluate(timer / transitionTime));
            
            timer += Time.deltaTime;
            yield return null;
        }

        moveDone = true;
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
