﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Asteroid behaviour
public class Asteroid : MonoBehaviour
{
	public static float MINIMUM_SCALE_FRAGMENTS = 2f;
	
	public static float FRAGMENTS_SCALE_DIVISION = 2f;
	
	public static float EXPULSION_FORCE_INTENSITY = 3f;
	
	public GameObject asteroid;
	
	public GameObject explosion;

	public GameManager GM;

    // Start is called before the first frame update
    void Start()
    {
		GM = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
	}
	// Destroys this asteroid and may create some fragments (based on this asteroid scale)
	void Destroy()
	{
		// Fragments limitation based on this asteroid scale
		if (gameObject.transform.localScale.x >= MINIMUM_SCALE_FRAGMENTS)
		{
			CreateFragments();
		}
		
		// Creates an explosion at this asteroid position
		GameObject newExplosion = Instantiate(explosion);
		newExplosion.transform.position = gameObject.transform.position;
			
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
		
		// Randomly opposed force vectors for the two asteroid fragments
		float forceX = Random.Range(0, 2) == 0 ? -EXPULSION_FORCE_INTENSITY : EXPULSION_FORCE_INTENSITY;
		float forceY = Random.Range(0, 2) == 0 ? -EXPULSION_FORCE_INTENSITY : EXPULSION_FORCE_INTENSITY;
		float forceZ = Random.Range(0, 2) == 0 ? -EXPULSION_FORCE_INTENSITY : EXPULSION_FORCE_INTENSITY;
		
		// First fragment
		Vector3 newPos1 = new Vector3(xPos, yPos, zPos);
		GameObject newAsteroid1 = Instantiate(asteroid);
		newAsteroid1.transform.localScale = newScale;
		newAsteroid1.transform.position = newPos1;
		newAsteroid1.GetComponent<Rigidbody>().AddForce(new Vector3(forceX, forceY, forceZ), ForceMode.VelocityChange);
		
		// Second fragment
		Vector3 newPos2 = new Vector3(xPos, yPos, zPos);
		GameObject newAsteroid2 = Instantiate(asteroid);
		newAsteroid2.transform.localScale = newScale;
		newAsteroid2.transform.position = newPos2;
		newAsteroid2.GetComponent<Rigidbody>().AddForce(new Vector3(-forceX, -forceY, -forceZ), ForceMode.VelocityChange);
	}

	// Click on an asteroid
	private void OnMouseOver()
	{
		if (Input.GetMouseButton(0))
		{
			StartCoroutine(DestroyCouroutine());
		}
	}

	private IEnumerator DestroyCouroutine()
	{
		yield return new WaitForSeconds(0.2f); // for a better rendering
		GM.IncrementActualScore();
		Destroy();
	}
}
