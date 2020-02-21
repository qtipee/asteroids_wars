using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
	public static float MINIMUM_SCALE_FRAGMENTS = 2f;
	
	public static float FRAGMENTS_SCALE_DIVISION = 2f;
	
	public int lifePoints;
	
	public GameObject asteroid;
	public GameManager GM;
	
    // Start is called before the first frame update
    void Start()
    {
        //GM = GameObject.FindObjectOfType<GameManager>();
		
		// FIXME
		// Maybe associate life points with size
		//lifePoints = (int)gameObject.transform.localScale.x + 5;
		lifePoints = 1;

		GM = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

	private void OnTriggerEnter(Collider other)
	{
		GM.IncrementActualScore();
		Destroy();
	}

	// Destroys this asteroid and may create some fragments (based on this asteroid scale)
	void Destroy()
	{
		// Fragments limitation based on this asteroid scale
		if (gameObject.transform.localScale.x >= MINIMUM_SCALE_FRAGMENTS)
		{
			CreateFragments();
		}
			
		// Destroys this asteroid
		Destroy(gameObject);
	}
	
	// Creates some asteroid fragments (based on this ateroid)
	private void CreateFragments()
	{
		float xPos = gameObject.transform.position.x;
		float yPos = gameObject.transform.position.y;
		float zPos = gameObject.transform.position.z;
		float xScale = gameObject.transform.localScale.x;
		float yScale = gameObject.transform.localScale.y;
		float zScale = gameObject.transform.localScale.z;

		// Fragments are half the size of their parent
		Vector3 newScale = new Vector3(xScale / FRAGMENTS_SCALE_DIVISION,
			yScale / FRAGMENTS_SCALE_DIVISION,
			zScale / FRAGMENTS_SCALE_DIVISION);
		
		// First fragment
		Vector3 newPos1 = new Vector3(xPos - xScale, yPos, zPos);
		GameObject newAsteroid1 = Instantiate(asteroid);
		newAsteroid1.transform.localScale = newScale;
		newAsteroid1.transform.position = newPos1;
		
		// Second fragment
		Vector3 newPos2 = new Vector3(xPos + xScale, yPos, zPos);
		GameObject newAsteroid2 = Instantiate(asteroid);
		newAsteroid2.transform.localScale = newScale;
		newAsteroid2.transform.position = newPos2;
	}
}
