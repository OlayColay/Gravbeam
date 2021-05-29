﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject firstSelectedButton;

    private void OnEnable() 
    {
        if (EventSystem.current != null && (Gamepad.current != null || Joystick.current != null))
        {
            EventSystem.current.SetSelectedGameObject(null);
            StartCoroutine(SelectFirstButton());
        }
    }

    private IEnumerator SelectFirstButton()
    {
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(firstSelectedButton);
    }

    private void Update()
    {
        if (Gamepad.current != null && Gamepad.current.bButton.wasPressedThisFrame)
        {
            firstSelectedButton.GetComponent<ButtonListeners>().OnClickResume();
        }
    }
}
