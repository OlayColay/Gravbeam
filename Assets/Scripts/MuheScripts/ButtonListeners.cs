using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class handles UI button behavior
/// </summary>
public class ButtonListeners : MonoBehaviour {

    /// <summary>
    /// Resume gameplay
    /// </summary>
    public void OnClickResume() {
        transform.parent.gameObject.SetActive(false);
        // TODO: Resume game
    }

    public void OnClickRestart() {
        // TODO: Restart level
    }

    /// <summary>
    /// Go to options menu
    /// <para>Use <see cref="OnClickBack"/> to return to pause menu</para>
    /// </summary>
    public void OnClickOptions() {
        transform.parent.parent.Find("OptionsMenu").gameObject.SetActive(true);
        transform.parent.gameObject.SetActive(false);
    }

    public void OnClickQuit() {
        // TODO: Quit to main menu
        // Use SceneManager
    }

    /// <summary>
    /// Go back to pause menu from options menu
    /// </summary>
    public void OnClickBack() {
        transform.parent.parent.Find("PauseMenu").gameObject.SetActive(true);
        transform.parent.gameObject.SetActive(false);
    }
}
