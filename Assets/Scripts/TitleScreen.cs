using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using DG.Tweening;

public class TitleScreen : MonoBehaviour
{
    [SerializeField] Transform skreech;
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
        yield return new WaitForSecondsRealtime(1f);
        EventSystem.current.SetSelectedGameObject(firstSelectedButton);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
