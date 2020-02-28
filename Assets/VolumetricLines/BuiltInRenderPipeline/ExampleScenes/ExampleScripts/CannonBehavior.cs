using UnityEngine;
using System.Collections;

public class CannonBehavior : MonoBehaviour {

	public Transform m_cannonRot;
	public Transform m_muzzle;
	public GameObject m_shotPrefab;

	public float IntervalTime;
	private float targetTime;

	// Use this for initialization
	void Start()
	{
		targetTime = IntervalTime;
	}

	private void FixedUpdate()
	{
        if (CrossSceneInformation.isPlaying)
		{
			targetTime -= Time.deltaTime;

			if (Input.GetKey(KeyCode.LeftArrow))
			{
				m_cannonRot.transform.Rotate(Vector3.up, -Time.deltaTime * 100f);
			}
			if (Input.GetKey(KeyCode.RightArrow))
			{
				m_cannonRot.transform.Rotate(Vector3.up, Time.deltaTime * 100f);
			}
			if (Input.GetMouseButton(0) && targetTime <= 0.0f)
			{
				GameObject go = GameObject.Instantiate(m_shotPrefab, m_muzzle.position, m_muzzle.rotation) as GameObject;
				GameObject.Destroy(go, 3f);
				targetTime = IntervalTime;
			}
		}
	}
}
