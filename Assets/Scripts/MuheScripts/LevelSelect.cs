using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour {
    [Tooltip("The level progress of the player. 0 if a new player")]
    [SerializeField] private int latestLevel;


    void Awake() {
        PlayerPrefs.GetInt("latestLevel", 0);
    }

    // Start is called before the first frame update
    private void Start() {
        Button[] buttons = new Button[latestLevel+1];
        buttons[0] = transform.Find("Tutorial").GetComponent<Button>();


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

        Navigation firstNavs = buttons[0].navigation;
        firstNavs.selectOnUp = buttons[latestLevel];
        buttons[0].navigation = firstNavs;
        
        Navigation lastNavs = buttons[latestLevel].navigation;
        lastNavs.selectOnDown = buttons[0];
        buttons[latestLevel].navigation = lastNavs;
    }

    // Update is called once per frame
    void Update() {
        
    }
}
