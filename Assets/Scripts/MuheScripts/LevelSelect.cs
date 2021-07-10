using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour {
    [Tooltip("The level progress of the player. 0 if a new player")]
    [SerializeField] private int latestLevel;
    private Transform levelScrollPane;

    // Start is called before the first frame update
    private void Start() {
        latestLevel = PlayerPrefs.GetInt("latestLevel", 3) - 2;
        // Debug.Log(latestLevel);

        levelScrollPane = transform.Find("Scroll View").Find("Viewport").Find("Content");

        Button[] buttons = new Button[latestLevel];
        buttons[0] = levelScrollPane.Find("Tutorial").GetComponent<Button>();
        Button back = transform.Find("Back to Menu").GetComponent<Button>();

        for(int i = 1; i < latestLevel; i++) {
            buttons[i] = levelScrollPane.Find("Level " + i).GetComponent<Button>();
            buttons[i].interactable = true;

            Navigation currNavs = buttons[i].navigation;
            currNavs.selectOnUp = buttons[i - 1];
            buttons[i].navigation = currNavs;

            Navigation prevNavs = buttons[i - 1].navigation;
            prevNavs.selectOnDown = buttons[i];
            buttons[i - 1].navigation = prevNavs;
        }
        
        Navigation lastNavs = buttons[latestLevel - 1].navigation;
        lastNavs.selectOnDown = back;
        buttons[latestLevel - 1].navigation = lastNavs;

        Navigation backNavs = back.navigation;
        backNavs.selectOnUp = buttons[latestLevel - 1];
        back.navigation = backNavs;
    }

    // Update is called once per frame
    void Update() {
        
    }
}
