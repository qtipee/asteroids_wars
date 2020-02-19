﻿using UnityEngine;
using System.Collections;

public class CannonBehavior : MonoBehaviour {

	public Transform m_cannonRot;
	public Transform m_muzzle;
	public GameObject m_shotPrefab;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			m_cannonRot.transform.Rotate(Vector3.up, -Time.deltaTime * 100f);
		}
		if (Input.GetKey(KeyCode.RightArrow))
		{
			m_cannonRot.transform.Rotate(Vector3.up, Time.deltaTime * 100f);
		}
		if (Input.GetKeyDown(KeyCode.Space))
		{
			GameObject go = GameObject.Instantiate(m_shotPrefab, m_muzzle.position, m_muzzle.rotation) as GameObject;
			GameObject.Destroy(go, 3f);
		}
	}
}
