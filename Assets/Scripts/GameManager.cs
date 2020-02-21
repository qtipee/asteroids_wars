using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public const float ASTEROID_MAX_SCALE = 5;
	
	public const int MAX_RANDOM_ASTEROID_ITERATIONS = 10;
	
	public GameObject asteroid1;
	public GameObject asteroid2;
	public GameObject asteroid3;

	public TextMeshProUGUI Time;

	public TextMeshProUGUI ActualScore;
	private int actualScore = 0;



	public TextMeshProUGUI BaseScore;
	private int baseScore = 0;


	// Start is called before the first frame update
	void Start()
    {
		int nbAsteroids = 50;
		float minPos = -100;
		float maxPos = 100;
		
		CreateRandomAsteroids(nbAsteroids, minPos, maxPos);
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

	private void UpdateTMP()
	{
		ActualScore.text = actualScore.ToString();
		BaseScore.text = baseScore.ToString();
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
				float x = Random.Range(minPos, maxPos);
				float y = Random.Range(minPos, maxPos);
				float z = Random.Range(minPos, maxPos);
				
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
					int asteroidType = Random.Range(0, 3);
					
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
					float randomScale = Random.Range(1f, ASTEROID_MAX_SCALE + 1);
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
}
