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
    private int score;
    private string difficulty;
    private float spawnRate = 1.0f;

    IEnumerator SpawnTarget()
    {
        while(isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
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

    public void StartGame(float difficultyFactor, string difficultyName)
    {
        isGameActive = true;
        score = 0;
        difficulty = difficultyName;
        spawnRate /= difficultyFactor;
        
        StartCoroutine(SpawnTarget());
        UpdateScore(0);

        titleScreen.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(true);
    }

    public void HighscoresScreen()
    {
        titleScreen.gameObject.SetActive(false);
        highscoresScreen.gameObject.SetActive(true);
    }
}
