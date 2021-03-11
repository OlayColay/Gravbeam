using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonListeners : MonoBehaviour {
    [SerializeField] int n;
    public void OnClickResume() {
        n++;
        transform.parent.gameObject.SetActive(false);
        Debug.Log(n);
    }

    public void OnClickRestart() {
        // Restart level
    }

    public void OnClickOptions() {
        // Bring up options menu
    }

    public void OnClickQuit() {
        // Quit to main menu
    }
}
