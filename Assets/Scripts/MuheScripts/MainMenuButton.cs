using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// This class handles UI button behavior
/// </summary>
public class MainMenuButton : MonoBehaviour {
    public void Awake() {
        if(gameObject.name == "VolumeSlider") {
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
    /// Go to options menu
    /// </summary>
    public void OnClickOptions() {
        transform.parent.parent.Find("OptionsMenu").gameObject.SetActive(true);
        transform.parent.gameObject.SetActive(false);
    }

    public void QuitToMain() {
        Globals.Reset();
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    public void OnClickQuitToTitle() {
        Globals.Reset();
        Time.timeScale = 1f;
        SceneManager.LoadScene("TitleScreen", LoadSceneMode.Single);
    }

    public void OnClickQuitGame() {
        Application.Quit();   // Or a "Do you really wanna quit?" dialog maybe
    }

    /// <summary>
    /// Go back to main menu from options menu
    /// </summary>
    public void OnClickBackToMain() {
        transform.parent.parent.Find("Menu").gameObject.SetActive(true);
        transform.parent.gameObject.SetActive(false);
    }

    public void OnVolumeChange(Slider volume) {
        AudioListener.volume = (volume.value / 100.0f);
    }

    public void OnQualityChange(Slider qualityLevel) {
        QualitySettings.SetQualityLevel((int)qualityLevel.value);
    }
}
