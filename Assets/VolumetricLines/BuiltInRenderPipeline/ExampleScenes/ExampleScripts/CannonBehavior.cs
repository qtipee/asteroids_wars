using UnityEngine;
using System.Collections;

public class CannonBehavior : MonoBehaviour {

	public Transform m_cannonRot;
	public Transform m_muzzle;
	public GameObject m_shotPrefab;

	public float IntervalTime;
	private float targetTime;

	private AudioSource audioSourceShoot;
	public AudioClip shootSound;

	// Use this for initialization
	void Start()
	{
		targetTime = IntervalTime;
		audioSourceShoot = gameObject.AddComponent<AudioSource>();
		audioSourceShoot.clip = shootSound;
		audioSourceShoot.playOnAwake = false;
		audioSourceShoot.loop = false;
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
				audioSourceShoot.Play();
				GameObject go = GameObject.Instantiate(m_shotPrefab, m_muzzle.position, m_muzzle.rotation) as GameObject;
				GameObject.Destroy(go, 3f);
				targetTime = IntervalTime;
			}
		}
	}
}
