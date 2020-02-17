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
		
		lifePoints = Random.Range(5, 20);
		
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
			GM.UpdateScore(-1);
			
			if (lifePoints <= 0)
			{
				Destroy(gameObject);
				
				GameObject newAsteroid = Instantiate(asteroid);
				Vector3 v = new Vector3(5.0f, 0, 0);
				newAsteroid.transform.position += v;
			}
		}
	}
}
