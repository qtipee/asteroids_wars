using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
	public GameManager GM;
	
	public int lifePoints;
	
	public GameObject asteroid;
	
    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.FindObjectOfType<GameManager>();
		
		// Maybe associate life points with size
		lifePoints = (int)gameObject.transform.localScale.x + 5;
		
		
		// FIXME: TMP
		GM.UpdateScore(lifePoints);	
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	private void OnMouseDown()
	{
		if (GM.gameIsPlaying)
		{
			--lifePoints;
			
			// FIXME: TMP
			GM.UpdateScore(-1);
			
			// Asteroid destroyed
			if (lifePoints <= 0)
			{
				float scale = gameObject.transform.localScale.x / 2f;
				Vector3 position = gameObject.transform.position;
				
				// Limit scale with fragments after destruction
				if (scale >= 1)
				{
					Vector3 newScale = new Vector3(scale, scale, scale);
					
					// Number of fragments depends on destroyed asteroid scale
					for (int i = 0; i < (int)scale; i++)
					{
						GameObject newAsteroid = Instantiate(asteroid);
					
						// Scale
						newAsteroid.transform.localScale = newScale;
					
						// Position
						float rndX = Random.Range(-scale, scale);
						float rndY = Random.Range(-scale, scale);
						float rndZ = Random.Range(-scale, scale);
						
						Vector3 newPosition = new Vector3(rndX, rndY, rndZ);
						newAsteroid.transform.position += newPosition;	
					}
				}
				
				Destroy(gameObject);
			}
		}
	}
}
