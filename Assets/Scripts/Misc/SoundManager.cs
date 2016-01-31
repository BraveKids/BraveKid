using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
	
	public static SoundManager instance = null;
	Dictionary<string,AudioClip> allMusics;
	Dictionary<string, AudioClip> allEffect;
	
	// source
	AudioSource musicSource = null;
	
	// clips 
	public AudioClip track1;
	public AudioClip track2;
	public AudioClip track3_1;
	public AudioClip track3_2;
	public AudioClip track3_3;


	//audio effects

	public AudioClip button;
	public AudioClip laugh;
	public AudioClip swing;
	public AudioClip goodCat;
	public AudioClip badCat;
	public AudioClip goodBird;
	public AudioClip badBird;
	public AudioClip rock;
	public AudioClip lizard;
	public AudioClip mouseTrap;
	public AudioClip goodMouse;
	public AudioClip badMouse;
	public AudioClip light;
	public AudioClip hey;
	public AudioClip wind;
	public AudioClip crows;
	public AudioClip chair;
	public AudioClip sleepyGranny;
	public AudioClip scaryGranny;
	public AudioClip sleepyDog;
	public AudioClip barfDog;


	int level = -1;	//default value
	
	string musicPlayed;
	
	
	
	
	// Use this for initialization
	void Start ()
	{
		// singleton
		if (instance == null) {
			instance = this;
			//DontDestroyOnLoad (gameObject);
		} else {
			Destroy (gameObject);
		}
		
		allMusics = new Dictionary<string, AudioClip> ();


		allEffect = new Dictionary<string, AudioClip > ();
		allEffect.Add ("button", button);
		allEffect.Add ("laugh",laugh);
		allEffect.Add ("swing",swing);
		allEffect.Add ("goodCat", goodCat);
		allEffect.Add ("badCat", badCat);
		allEffect.Add("goodBird", goodBird);
		allEffect.Add("badBird", badBird);
		allEffect.Add("rock", rock);
		allEffect.Add("lizard", lizard);
		allEffect.Add("mouseTrap", mouseTrap);
		allEffect.Add("goodMouse", goodMouse);
		allEffect.Add("badMouse", badMouse);
		allEffect.Add("light", light);
		allEffect.Add("hey", hey);
		allEffect.Add("wind", wind);
		allEffect.Add("crows", crows);
		allEffect.Add("chair", chair);
		allEffect.Add("sleepyGranny", sleepyGranny);
		allEffect.Add("scaryGranny", scaryGranny);
		allEffect.Add("sleepyDog", sleepyDog);
		allEffect.Add("barfDog", barfDog);
		
		musicSource = GetComponent<AudioSource> () as AudioSource;
		musicSource.loop = true;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (level != SaveLoad.savedGame.level) {


			switch (SaveLoad.savedGame.level) {
			case -1:
				SetBackgroundMusic ("lullaby");
				break;
			case 0:
				SetBackgroundMusic ("tutorial");
				break;
			case 1:
				SetBackgroundMusic ("school");
				break;
				
			case 2:
				SetBackgroundMusic ("gorilla");
				break;
				
			case 5:
				SetBackgroundMusic ("knight");
				break;
			default:
				SetBackgroundMusic ("lullaby");
				break;
				
			}
			
			
		}
	}
	
	public void SetVolume (float _volume)
	{
		musicSource.volume = _volume;
	}
	
	public void SetBackgroundMusic (string background)
	{
		if (allMusics.ContainsKey (background)) {
			musicSource.clip = allMusics [background];
			level = SaveLoad.savedGame.level;
			musicSource.Play ();
		}
		
		
		
	}
	
	public void SetMusic (bool _music)
	{
		if (musicSource.isPlaying == true && _music == false) {
			musicSource.Pause ();
		}
		if (musicSource.isPlaying == false && _music == true) {
			musicSource.Play ();
		}
	}

	public void playAudioEffect (string audioEffect)
	{
		Debug.Log(allEffect["button"].ToString());
		AudioSource audio = gameObject.AddComponent<AudioSource>();
		audio.clip = allEffect ["button"];
		audio.Play ();
	}

	public AudioSource playLoopEffect (string audioEffect, bool loop)
	{
		AudioSource audio = new AudioSource ();
		audio.loop = loop;
		audio.clip = allEffect [audioEffect];
		audio.Play ();
		return audio;
	}
	
}