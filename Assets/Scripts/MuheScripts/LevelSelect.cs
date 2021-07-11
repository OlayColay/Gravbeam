using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LevelSelect : MonoBehaviour {
    [Tooltip("The level progress of the player. 0 if a new player")]
    [SerializeField] private int latestLevel;
    [SerializeField] private Scrollbar scrollbar;
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
        GameObject selected = EventSystem.current.currentSelectedGameObject;
        if (selected == null) return;
        if (selected.transform.parent != levelScrollPane) return;
        RectTransform selectedRectTransform = selected.GetComponent<RectTransform>();
        RectTransform contentRect = levelScrollPane.GetComponent<RectTransform>();

        float scrollViewMinY = -65;
        float scrollViewMaxY = 65;
        // Debug.Log(selectedRectTransform.anchoredPosition.y);
 
        float selectedPositionY = selectedRectTransform.anchoredPosition.y;
        // Debug.Log(selectedPositionY);
 
        // If selection above scroll view
        if (selectedPositionY > scrollViewMaxY)
        {
            scrollbar.value += 0.02f;
        }
        // If selection below scroll view
        else if (selectedPositionY < scrollViewMinY)
        {
            scrollbar.value -= 0.02f;
        }
    }
}
