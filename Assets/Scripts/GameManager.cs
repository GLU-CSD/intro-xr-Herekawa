using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    private bool gameActive = true;
    private int score = 0;
    private float scoreTimer = 0f; // Timer om score te verhogen

    public static readonly HashSet<GameObject> TargetNodes = new HashSet<GameObject>();
    public static readonly HashSet<GameObject> RangerNodes = new HashSet<GameObject>();

    // UI om de score te laten zien
    [SerializeField] private TextMeshProUGUI scoreText;

    // UI die getoond wordt bij game over
    [SerializeField] private GameObject gameOverUI;

    void Start()
    {
        scoreText.text = "Score: " + score;

        TargetNodes.Clear();
        RangerNodes.Clear();

        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("AttackNodeClose"))
        {
            TargetNodes.Add(obj);
        }
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("AttackNodeFar"))
        {
            RangerNodes.Add(obj);
        }
    }

    void Update()
    {
        if (gameActive)
        {
            //Time.deltaTime geeft aantal seconden sinds laatste Update
            scoreTimer += Time.deltaTime;

            if (scoreTimer >= 1f) // Verhoog de score elke seconde
            {
                score++;
                scoreTimer = 0f; // Reset de timer
            }
            scoreText.text = "Score: " + score;
        }
    }

    public void GameOver()
    {
        gameActive = false;

        // Vind alle vijanden in de scene
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        //Loop door alle gevonden vijanden en vernietig ze
        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }

        // Doe hetzelfde met de spawners
        GameObject[] spawners = GameObject.FindGameObjectsWithTag("Spawner");
        foreach (GameObject spawner in spawners)
        {
            Destroy(spawner);
        }

        // Toon de Game Over UI
        gameOverUI.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}