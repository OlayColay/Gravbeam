using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour {
    [Tooltip("The level progress of the player. 0 if a new player")]
    [SerializeField] private int latestLevel;

    // Start is called before the first frame update
    private void Start() {
        latestLevel = PlayerPrefs.GetInt("latestLevel", 0);

        Button[] buttons = new Button[latestLevel+1];
        buttons[0] = transform.Find("Tutorial").GetComponent<Button>();
        Button back = transform.Find("Back to Menu").GetComponent<Button>();

        for(int i = 1; i <= latestLevel; i++) {
            buttons[i] = transform.Find("Level " + i).GetComponent<Button>();
            buttons[i].interactable = true;

            Navigation currNavs = buttons[i].navigation;
            currNavs.selectOnUp = buttons[i - 1];
            buttons[i].navigation = currNavs;

            Navigation prevNavs = buttons[i - 1].navigation;
            prevNavs.selectOnDown = buttons[i];
            buttons[i - 1].navigation = prevNavs;
        }
        
        Navigation lastNavs = buttons[latestLevel].navigation;
        lastNavs.selectOnDown = back;
        buttons[latestLevel].navigation = lastNavs;

        Navigation backNavs = back.navigation;
        backNavs.selectOnUp = buttons[latestLevel];
        back.navigation = backNavs;
    }

    // Update is called once per frame
    void Update() {
        
    }
}
