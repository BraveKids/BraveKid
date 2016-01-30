using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class PauseMenu : MonoBehaviour
{

	GameObject mainMenu;
	GameObject continueButton;
	public GameObject player;
	string selectedName;
	float t;
	float scaleX;
	float scaleY;
	float scaleZ;
	float transitionDuration = 1f;
	List<GameObject> buttons;
	int selected;
	// Use this for initialization
	public void Start ()
	{
		t = 0f;
		GameObject newGame = transform.FindChild ("mainMenu").gameObject;
		GameObject continueButton = transform.FindChild ("continue").gameObject;

		buttons = new List<GameObject>(){continueButton,newGame};

		scaleX = buttons [0].transform.localScale.x;
		scaleY = buttons [0].transform.localScale.y;
		scaleZ = buttons [0].transform.localScale.z;
		selected = 0;

		showPauseMenu();

		//player = GameObject.FindGameObjectWithTag("Player");
	}
	
	void Update ()
	{

		selectedName = buttons [selected].transform.name;
		Debug.Log (selected);
		if (Input.GetKeyDown (KeyCode.Return)) {
			if (selectedName == "continue") {
				hidePauseMenu ();
			}
			
			if (selectedName == "mainMenu") {
				toMainMenu ();
			}
		}
		if (Input.GetKeyDown (KeyCode.Escape) || Input.GetKeyDown (KeyCode.Joystick1Button7)) {
			hidePauseMenu ();
		}
		if (Input.GetKey ("right")) {
			changeButton (1);	//new game
		}
		
		if (Input.GetKey ("left")) {
			changeButton (0);	//continue
			
		}

		if (t < 1f) {
			
			t += Time.deltaTime / transitionDuration;
			
			float delta = nextGaussian (t) * 0.5f;
			
			buttons [selected].transform.localScale = new Vector3 (scaleX + delta, (scaleY + delta), scaleZ);
			if (t >= 1f) {
				t = 0f;
			}
		}
	}
	
	public void showPauseMenu ()
	{
		Time.timeScale = 0;
		gameObject.SetActive (true);
		player.GetComponent<CharacterControllerScript>().canMove(false);
		//SoundManager.instance.SetMusic(false);
	}
	
	public void hidePauseMenu ()
	{
		gameObject.SetActive (false);
		Time.timeScale = 1;	
		player.GetComponent<CharacterControllerScript>().canMove(true);
		
		//SoundManager.instance.SetMusic(true);
	}
	
	public void continueGame ()
	{
		hidePauseMenu ();
	}
	
	public void toMainMenu ()
	{
		Time.timeScale = 1;
		hidePauseMenu ();
		Application.LoadLevel ("Menu");
	}

	void changeButton (int selected)
	{
		buttons [this.selected].transform.localScale = new Vector3 (scaleX, scaleY, scaleZ);
		this.selected = selected;
	}

	float nextGaussian (float x)
	{
		double sigma = 0.4;
		double mu = 0.5;
		double n1 = 1 / Math.Sqrt (2 * Math.PI * Math.Pow (sigma, 2));
		
		double n2_1 = (x - mu) / sigma;
		double n2_2 = Math.Exp (-0.5 * Math.Pow (n2_1, 2));
		
		return (float)(n1 * n2_2);
	}


}
