using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundChanger : MonoBehaviour {

	public AudioSource pickup;

	void Start()
	{
		pickup = GetComponent<AudioSource>();
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		pickup.Play();
	}
}
