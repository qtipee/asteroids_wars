using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
	public bool gameIsPlaying = true;
	
	public int score;
	public TextMeshProUGUI scoreText;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score;
    }
	
	public void UpdateScore(int deltaScore)
	{
		score += deltaScore;
	}
	
	public void RestartGame()
	{
		// Just reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
	
	public void StopGame()
	{
		// Pauses the simulation
		Time.timeScale = 0;
		// Flag to be used by all GO to check wether to update or not
		gameIsPlaying = false;
	}
}
