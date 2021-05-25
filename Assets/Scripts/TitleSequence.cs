using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using DG.Tweening;

[RequireComponent(typeof(BoxCollider2D))]
public class TitleSequence : MonoBehaviour
{
    [SerializeField] private Transform oldTerrain;
    [SerializeField] private Transform newTerrain;
    [SerializeField] private Transform oldBackground;
    [SerializeField] private Transform newBackground;
    [SerializeField] private SpriteRenderer titleSprite;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        GetComponent<BoxCollider2D>().enabled = false;
        newTerrain.gameObject.SetActive(true);
        newBackground.gameObject.SetActive(true);

        for(int i = 0; i < oldTerrain.childCount; i++)
        {
            SpriteShapeRenderer oldColor = oldTerrain.GetChild(i).GetComponent<SpriteShapeRenderer>();
            // SpriteShapeRenderer newColor = newTerrain.GetChild(i).GetComponent<SpriteShapeRenderer>();
            StartCoroutine(FadeColors(oldColor/*, newColor*/));
        }
        
        for(int i = 0; i < oldBackground.childCount; i++)
        {
            Transform bgLayerOld = oldBackground.GetChild(i);
            Transform bgLayerNew = newBackground.GetChild(i);
            
            bgLayerOld.GetComponent<SpriteRenderer>().DOFade(0f, 10f);
            if (i == 0)
            {
                bgLayerNew.GetComponent<SpriteRenderer>().DOFade(1f, 3f);
            }
            else
            {
                bgLayerNew.GetComponent<SpriteRenderer>().DOFade(1f, 10f);
            }

            for(int j = 0; j < bgLayerOld.childCount; j++)
            {
                SpriteRenderer oldColor = bgLayerOld.GetChild(j).GetComponent<SpriteRenderer>();
                SpriteRenderer newColor = bgLayerNew.GetChild(j).GetComponent<SpriteRenderer>();

                oldColor.DOFade(0f, 10f);
                if (i == 0)
                {
                    newColor.DOFade(1f, 3f);
                }
                else
                {
                    newColor.DOFade(1f, 10f);
                }
            }
        }

        StartCoroutine(TitleFade());
    }

    private IEnumerator FadeColors(SpriteShapeRenderer oldColor/*, SpriteShapeRenderer newColor*/)
    {
        for (float i = 0f; i <= 10f; i += Time.deltaTime)
        {
            // set color with i as alpha
            oldColor.color = new Color(1, 1, 1, 1 - i/10);
            // newColor.color = new Color(1, 1, 1, i/10);
            yield return null;
        }

        oldTerrain.gameObject.SetActive(false);
        oldBackground.gameObject.SetActive(false);
    }

    private IEnumerator TitleFade()
    {
        titleSprite.DOFade(1f, 3f);
        yield return new WaitForSeconds(7f);
        titleSprite.DOFade(0f, 3f);
    }
}
