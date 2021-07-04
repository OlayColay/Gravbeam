using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject firstSelectedButton;

    PlatformerCharacter2D platformerControls;

    private void OnEnable() 
    {
        // Debug.Log("Enable Pause Menu!");

        Time.timeScale = 0f;

        if (EventSystem.current != null && (Gamepad.current != null || Joystick.current != null))
        {
            EventSystem.current.SetSelectedGameObject(null);
            StartCoroutine(SelectFirstButton());
        }
        else
        {
            EventSystem.current.SetSelectedGameObject(null);
        }

        platformerControls = FindObjectOfType<PlatformerCharacter2D>();
        if (platformerControls != null)
        {
            platformerControls.controls.Gravity.Disable();
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
