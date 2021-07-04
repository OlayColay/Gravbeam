using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// This class handles UI button behavior
/// </summary>
public class ButtonListeners : MonoBehaviour {
    private PlatformerCharacter2D player;
    private BeamScript ZeroGPlayer;
    private PlayerControls controls;

    public void Awake() {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlatformerCharacter2D>();

        if (player != null) {
            controls = player.controls;
        }
        else {
            BeamScript ZeroGPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<BeamScript>();
            controls = ZeroGPlayer.controls;
        }


        if (gameObject.name == "VolumeSlider") {
            gameObject.GetComponent<Slider>().value = AudioListener.volume * 100;
        }
        else if (gameObject.name == "QualitySlider") {
            gameObject.GetComponent<Slider>().value = QualitySettings.GetQualityLevel();
        }
    }

    public void OnClickNewGame() {
        PlayerPrefs.DeleteAll();

        OnClickLoadGame();
    }

    public void OnClickLoadGame() {
        SceneManager.LoadScene("LevelSelect", LoadSceneMode.Single);
    }

    public void LoadLevel(int level) {
        // switch (level) {
        //     case 0:
        //         SceneManager.LoadScene(2, LoadSceneMode.Single);
        //         break;

        //     default:
        //         Debug.Log("Level " + level + " not yet added!");
        //         break;
        // }
        SceneManager.LoadScene(level + 3, LoadSceneMode.Single);
    }

    /// <summary>
    /// Resume gameplay
    /// </summary>
    public void OnClickResume() {
        controls.Enable();
        transform.parent.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    public void OnClickRestart() {
        controls.Disable();
        Globals.Reset();
        Time.timeScale = 1f;
        GameObject.FindObjectOfType<CanvasGroup>().transform.GetChild(0).gameObject.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
        Globals.Reset();
        Time.timeScale = 1f;

        controls.Disable();

        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    public void OnClickQuitGame() {
        Application.Quit();   // Or a "Do you really wanna quit?" dialog maybe
    }

    /// <summary>
    /// Go back to pause menu from options menu
    /// </summary>
    public void OnClickBack() {
        transform.parent.parent.Find("PauseMenu").gameObject.SetActive(true);
        transform.parent.gameObject.SetActive(false);
    }

    public void OnVolumeChange(Slider volume) {
        AudioListener.volume = (volume.value / 100.0f);
    }

    public void OnQualityChange(Slider qualityLevel) {
        QualitySettings.SetQualityLevel((int)qualityLevel.value);
    }
}
