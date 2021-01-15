using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighscoresTable : MonoBehaviour
{
    private Transform highscoresContainer;
    private Transform highscoresTemplate;

    void Awake()
    {
        highscoresContainer = transform.Find("Highscores Container");
        highscoresTemplate = highscoresContainer.Find("Highscores Template");

        float templateHeight = 40.0f;

        for(int i = 0; i < 5; i++)
        {
            Transform highscoresTransform = Instantiate(highscoresTemplate, highscoresContainer);
            RectTransform highscoresRectTransform = highscoresTransform.GetComponent<RectTransform>();
            highscoresRectTransform.anchoredPosition = new Vector2(0, -templateHeight *  i);
        }
    }
}
