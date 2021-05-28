using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(BoxCollider2D))]
public class LevelGoal : MonoBehaviour
{
    [Tooltip("The build index of the next level's scene. These can be found/edited in Build Settings")]
    [SerializeField] private int nextLevelNumber;

    void OnDrawGizmos()
    {
        GetComponent<BoxCollider2D>().offset = Vector2.zero;

        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, GetComponent<BoxCollider2D>().size);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            StartCoroutine(NextLevel());
            FindObjectOfType<Camera>().transform.GetChild(0).GetComponent<LoadingScreen>().FadeIn();
        }
    }

    private IEnumerator NextLevel()
    {
        yield return new WaitForSeconds(1f);

        PlayerPrefs.SetInt("currentLevel", nextLevelNumber);
        
        // If the next level hasn't been reached before, update the latestLevel int
        if (nextLevelNumber > PlayerPrefs.GetInt("latestLevel", 0))
        {
            PlayerPrefs.SetInt("latestLevel", nextLevelNumber);
        }
        
        Globals.curCheckpoint = 0; // Reset checkpoint int so that you spawn at start of next level

        SceneManager.LoadScene(nextLevelNumber, LoadSceneMode.Single);
    }
}
