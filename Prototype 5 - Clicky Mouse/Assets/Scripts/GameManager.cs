using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public GameObject titleScreen;
    public GameObject highscoresScreen;
    public bool isGameActive;
    private int targetsListSize;
    private int score;
    private float spawnRate = 1.0f;

    IEnumerator SpawnTarget()
    {
        while(isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targetsListSize);
            Instantiate(targets[index]);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(float difficulty, string difficultyName)
    {
        isGameActive = true;
        targetsListSize = targets.Count;
        score = 0;
        spawnRate /= difficulty;

        if(difficultyName == "Easy")
        {
            targets.RemoveAt(targetsListSize - 1);
        }
        else if(difficultyName == "Impossible")
        {
            GameObject lastTarget = targets[targetsListSize - 1];
            targets.Add(lastTarget);
        }
        
        StartCoroutine(SpawnTarget());
        UpdateScore(0);
        

        titleScreen.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(true);
    }
}
