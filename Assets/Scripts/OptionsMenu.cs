using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] private GameObject firstSelectedButton;

    private GameObject previousSelectedButton;

    private void OnEnable() 
    {
        Time.timeScale = 0f;

        if (EventSystem.current != null && (Gamepad.current != null || Joystick.current != null))
        {
            previousSelectedButton = EventSystem.current.currentSelectedGameObject;
            EventSystem.current.SetSelectedGameObject(null);
            StartCoroutine(SelectFirstButton());
        }

        PlatformerCharacter2D platformerControls = FindObjectOfType<PlatformerCharacter2D>();
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
    
    private void OnDisable() 
    {
        if (EventSystem.current != null && (Gamepad.current != null || Joystick.current != null))
        {
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(previousSelectedButton);
        }
    }

    private void Update()
    {
        if (Gamepad.current != null && Gamepad.current.bButton.wasPressedThisFrame)
        {
            firstSelectedButton.GetComponent<ButtonListeners>().OnClickBack();
        }
    }
}
