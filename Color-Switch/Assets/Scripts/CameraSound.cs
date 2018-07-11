using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSound : MonoBehaviour {
public AudioSource bg;

	void Start()
	{
		bg = GetComponent<AudioSource>();
		bg.Play();
	}
}
