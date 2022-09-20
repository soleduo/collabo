using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeLoadingBar : MonoBehaviour
{
    public Canvas titleScreen;

    public RectTransform rectBar;
    public RectTransform rectFill;

    public int progress = 1;

    IEnumerator Start()
    {
        while (rectFill.rect.size.x < rectBar.rect.size.x)
        {
            rectFill.sizeDelta += Vector2.right * (510 * progress * 0.01f);
            progress += 1;
            yield return new WaitForEndOfFrame();
        }

        rectFill.sizeDelta = new Vector2(505, 0);

        yield return new WaitForSeconds(3f);

        titleScreen.enabled = false;
        this.enabled = false;

        yield break;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
