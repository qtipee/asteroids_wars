using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public const float ASTEROID_MAX_SCALE = 5;
	
	public const int MAX_RANDOM_ASTEROID_ITERATIONS = 10;

	public const int MAX_TIME = 10;

	public GameObject asteroid1;
	public GameObject asteroid2;
	public GameObject asteroid3;

	//UI
	public TextMeshProUGUI GameTime;

	public TextMeshProUGUI ActualScore;
	private int actualScore = 0;

	public TextMeshProUGUI BaseScore;
	private int baseScore = 0;

	private DateTime oldTime;
	public DateTime OldTime { set => oldTime = value; }

	public GameObject buttonResume;
	public GameObject buttonRestart;

	private bool isPlaying;

	// Start is called before the first frame update
	void Start()
    {
		buttonResume.SetActive(false);
		buttonRestart.SetActive(false);

		oldTime = DateTime.Now;

		int nbAsteroids = CrossSceneInformation.nbAsteroids;
		float sceneSize = CrossSceneInformation.sceneSize;

		// Generates a random game scene
		CreateRandomAsteroids(nbAsteroids, sceneSize, -sceneSize);

		CrossSceneInformation.isPlaying = true;

		Cursor.lockState = CursorLockMode.Locked;
	}

    // Update is called once per frame
    void Update()
    {
		if (CrossSceneInformation.isPlaying)
		{
			int difference = (int)(DateTime.Now - oldTime).TotalSeconds;

			if (difference > MAX_TIME)
			{
				actualScore = 0;
				oldTime = DateTime.Now;
				UpdateTMP();
			}
			else
			{
				GameTime.text = "Temps restant : " + (MAX_TIME - difference).ToString();
			}
		}

        // Pause/Resume key pressed
        if (Input.GetKeyDown("p"))
		{
			if (CrossSceneInformation.isPlaying)
			{
				PauseGame();
			}
            else
			{
				ResumeGame();
			}
		}
	}

	public void IncrementActualScore()
	{
		actualScore++;
		UpdateTMP();
	}

	public void IncrementBaseScore()
	{
		baseScore += actualScore;
		actualScore = 0;
		UpdateTMP();
	}

    // Pauses the game
    public void PauseGame()
	{
		//Time.timeScale = 0.1f;
		CrossSceneInformation.isPlaying = false;

		buttonResume.SetActive(true);
		buttonRestart.SetActive(true);

		Cursor.lockState = CursorLockMode.Confined;
	}

    // Resumes the game
    public void ResumeGame()
	{
		//Time.timeScale = 1;
		CrossSceneInformation.isPlaying = true;

		buttonResume.SetActive(false);
		buttonRestart.SetActive(false);

		Cursor.lockState = CursorLockMode.Locked;
	}

    // Restarts the game -> show game menu
    public void RestartGame()
	{
		SceneManager.LoadScene("MenuScene");
	}

	// Generates asteroids, whose positions are randomly generated in a given area
	private void CreateRandomAsteroids(int nbAsteroids, float minPos, float maxPos)
	{
		// List of occupied positions in the scene
		List<Vector3> usedSpots = new List<Vector3>();
		
		for (int i = 0; i < nbAsteroids; i++)
		{	
			int maxIterations = MAX_RANDOM_ASTEROID_ITERATIONS;
			
			// While the randomly generated position is too closed to an existing asteroid
			while (true)
			{
				// Generates random coordinates
				float x = UnityEngine.Random.Range(minPos, maxPos);
				float y = UnityEngine.Random.Range(minPos, maxPos);
				float z = UnityEngine.Random.Range(minPos, maxPos);
				
				bool isSpotFree = true;
			
				// Iterates over each existing asteroids
				foreach (Vector3 spot in usedSpots)
				{
					// Position already occupied
					if (x >= spot.x - ASTEROID_MAX_SCALE && x <= spot.x + ASTEROID_MAX_SCALE &&
						y >= spot.y - ASTEROID_MAX_SCALE && y <= spot.y + ASTEROID_MAX_SCALE &&
						z >= spot.z - ASTEROID_MAX_SCALE && z <= spot.z + ASTEROID_MAX_SCALE)
					{
						isSpotFree = false;
						break;
					}
				}
			
				// Unused position ; creates a new asteroid and add it to the scene
				if (isSpotFree)
				{
					Vector3 pos = new Vector3(x, y, z);
					usedSpots.Add(pos);
					
					GameObject asteroid;
					int asteroidType = UnityEngine.Random.Range(0, 3);
					
					// Asteroid Prefab #1
					if (asteroidType == 0)
					{
						asteroid = Instantiate(asteroid1);
					}
					// Asteroid prefab 2
					else if (asteroidType == 1)
					{
						asteroid = Instantiate(asteroid2);
					}
					// Asteroid prefab 3
					else
					{
						asteroid = Instantiate(asteroid3);
					}
					
					asteroid.transform.position = new Vector3(x, y, z);
					
					// Random scale
					float randomScale = UnityEngine.Random.Range(1f, ASTEROID_MAX_SCALE + 1);
					asteroid.transform.localScale = new Vector3(randomScale, randomScale, randomScale);
					
					break;
				}
				
				--maxIterations;
				
				// Limits the number of tries to avoid infinite loop
				if (maxIterations == 0)
				{
					break;
				}
			}
		}
	}

	private void UpdateTMP()
	{
		ActualScore.text = "Score actuel : " + actualScore.ToString();
		BaseScore.text = "Score à la base : " + baseScore.ToString();
	}
}
