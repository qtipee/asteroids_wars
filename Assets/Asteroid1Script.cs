using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid1Script : MonoBehaviour
{
	public GameManager GM;
	
	public int lifePoints = 5;
	
    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	private void OnMouseDown()
	{

		if (GM.gameIsPlaying)
		{
			GM.UpdateScore(1);
		}
	}
}
