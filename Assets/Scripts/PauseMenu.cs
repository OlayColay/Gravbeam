using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject firstSelectedButton;

    private void OnEnable() 
    {
        if (EventSystem.current != null && Gamepad.current != null)
        {
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(firstSelectedButton);
        }
    }
}
