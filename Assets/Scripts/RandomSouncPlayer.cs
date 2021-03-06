﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RandomSouncPlayer : MonoBehaviour {

	private AudioSource audioSource;

	[SerializeField]
	private List<AudioClip> soundClips = new List<AudioClip> ();

	[SerializeField]
	private float soundTimeDelay = 3f;
	private float soundTimer;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource> ();

	}
	
	// Update is called once per frame
	void Update () {
		// increment a timer to count up to restarting.
		soundTimer = soundTimer + Time.deltaTime;

		// if the timer reaches the delay...
		if (soundTimer >= soundTimeDelay) {
			
			// resets the timer...
			soundTimer = 0f;

			// ... choose a random sound
			AudioClip randomSound = soundClips[Random.Range(0, soundClips.Count)];

			//... play the sound
			audioSource.PlayOneShot(randomSound);
		}
	}
}
