﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script is used to change the camera's "window." Probably doesn't work yet
/// </summary>
public class ChangeCamWindow : MonoBehaviour {

    // Transition parameters
    public float transitionTime = 1f;
    public AnimationCurve transitionSpeedVariation = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);

    bool followAlongX = true;
    bool followAlongY = true;

    // Camera player tracking stuff
    public float damping = 1;
    public float lookAheadFactor = 3;
    public float lookAheadReturnSpeed = 0.5f;
    public float lookAheadMoveThreshold = 0.1f;

    private float m_OffsetZ;
    private Vector3 m_LastTargetPosition;
    private Vector3 m_CurrentVelocity;
    private Vector3 m_LookAheadPos;

    // Window details
    Vector2 windowCenterPos;
    float windowInitialSizeY;
    float windowFinalSizeY;

    // transforms
    Transform cameraTransform;
    Transform playerTransform;

    Camera cam;

    bool moveDone = true;
    //UnityStandardAssets._2D.Camera2DFollow playerFollow;

    IEnumerator currentCoroutine;

    // Start is called before the first frame update
    void Start() {
        cameraTransform = transform;
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        cam = GetComponent<Camera>();
        
        // Standard assets camera tracking code
        m_LastTargetPosition = playerTransform.position;
        m_OffsetZ = (transform.position - playerTransform.position).z;
        transform.parent = null;
    }

    // Update is called once per frame
    void Update() {
        // TODO Work in progress
        if (moveDone) {
            // StandardAssets camera tracking code

            // only update lookahead pos if accelerating or changed direction
            float xMoveDelta = (playerTransform.position - m_LastTargetPosition).x;

            bool updateLookAheadTarget = Mathf.Abs(xMoveDelta) > lookAheadMoveThreshold;

            if (updateLookAheadTarget) {
                m_LookAheadPos = lookAheadFactor * Vector3.right * Mathf.Sign(xMoveDelta);
            }
            else {
                m_LookAheadPos = Vector3.MoveTowards(m_LookAheadPos, Vector3.zero, Time.deltaTime * lookAheadReturnSpeed);
            }

            Vector3 aheadTargetPos = playerTransform.position + m_LookAheadPos + Vector3.forward * m_OffsetZ;
            Vector3 newPos = Vector3.SmoothDamp(transform.position, aheadTargetPos, ref m_CurrentVelocity, damping);

            transform.position = newPos;

            m_LastTargetPosition = playerTransform.position;
        }
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
        windowFinalSizeY = windowSizeY / 2;

        StartCoroutine(moveToNewWindow());
    }

    IEnumerator moveToNewWindow() {
        Vector2 camPos = cameraTransform.position;

        float timer = 0f;

        while (timer < transitionTime) {
            Vector2 tempCamPos = Vector2.Lerp(camPos, windowCenterPos, transitionSpeedVariation.Evaluate(timer / transitionTime));
            cameraTransform.position = new Vector3(tempCamPos.x, tempCamPos.y, cameraTransform.position.z);
            cam.orthographicSize = Mathf.Lerp(windowInitialSizeY, windowFinalSizeY, transitionSpeedVariation.Evaluate(timer / transitionTime));
            
            timer += Time.deltaTime;
            yield return null;
        }

        moveDone = true;
        yield return null;
    }
}
