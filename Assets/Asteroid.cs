using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
	public GameManager GM;
	
	public int lifePoints;
	
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
		}
	}
}
