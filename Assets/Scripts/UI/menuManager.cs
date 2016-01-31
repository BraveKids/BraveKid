using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;

public class menuManager : MonoBehaviour
{

	//public List<Button> buttons;
	public List<List<GameObject>> buttons;
	public List<List<Sprite>> coloredSprites;
	public List<List<Sprite>> graySprites;
	
	// Use this for initialization
	int row;
	int column;
	//GameObject selected;
	string selected;
	float transitionDuration;
	float t;
	float scaleX;
	float scaleY;
	float scaleZ;
	bool canContinue = false;
	GameObject newGame;
	GameObject continueGame;
	GameObject credits;
	GameObject exitGame;
	Color notSelectedColor = new Color (200f, 200f, 200f);
	public Sprite coloredNewGame;
	public Sprite coloredContinue;
	public Sprite coloredCredits;
	public Sprite coloredExit;
	public Sprite grayNewGame;
	public Sprite grayContinue;
	public Sprite grayCredits;
	public Sprite grayExit;
	public AudioClip button;

	void Start ()
	{
		
		GameObject newGame = transform.FindChild ("newGame").gameObject;
		GameObject continueGame = transform.FindChild ("continue").gameObject;
		GameObject credits = transform.FindChild ("credits").gameObject;
		GameObject exitGame = transform.FindChild ("exitGame").gameObject;

		List<GameObject> colonna1 = new List<GameObject> (){newGame, credits};
		List<GameObject> colonna2 = new List<GameObject> (){continueGame,exitGame};
		buttons = new List<List<GameObject>> (){colonna1,colonna2};
		
		List<Sprite> colored1 = new List<Sprite> (){coloredNewGame, coloredContinue};
		List<Sprite> colored2 = new List<Sprite> (){coloredCredits, coloredExit};
		coloredSprites = new List<List<Sprite>> (){colored1,colored2};

		List<Sprite> gray1 = new List<Sprite> (){grayNewGame, grayContinue};
		List<Sprite> gray2 = new List<Sprite> (){grayCredits, grayExit};
		graySprites = new List<List<Sprite>> (){gray1,gray2};
		


		row = 0;
		column = 0;
		t = 0;
		transitionDuration = 1f;

		scaleX = buttons [0] [0].transform.localScale.x;
		scaleY = buttons [0] [0].transform.localScale.y;
		scaleZ = buttons [0] [0].transform.localScale.z;

		buttonState (0, 0, true);
		
		buttonState (0, 1, false);
		
		buttonState (1, 1, false);

		if (File.Exists (SaveLoad.SAVING_PATH)) {
			canContinue = true;
		}
		if (!canContinue) {
			disableContinue ();
		} else {
			buttonState (1, 0, false);			
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		selected = buttons [column] [row].transform.name;
		if (Input.GetKeyDown (KeyCode.Return)) {
			if (selected == "continue") {
				SaveLoad.Load ();
				Application.LoadLevel ("Gameplay");
			}

			if (selected == "newGame") {
				Application.LoadLevel ("Gameplay");
			}

			if (selected == "exitGame") {
				Application.Quit ();
			}
		}
		if (Input.GetKey ("right")) {
			changeButton (1, row);
		}
		
		if (Input.GetKey ("left")) {
			changeButton (0, row);
			
		}

		if (Input.GetKey ("down")) {
			changeButton (column, 1);
			

		}

		if (Input.GetKey ("up")) {
			changeButton (column, 0);			
		}

		if (t < 1f) {

			t += Time.deltaTime / transitionDuration;

			float delta = nextGaussian (t) * 0.5f;
			
			buttons [column] [row].transform.GetChild (0).transform.localScale = new Vector3 (scaleX + delta, (scaleY + delta), scaleZ);
			if (t >= 1f) {
				t = 0f;
			}
		}

		

		
	}

	void changeButton (int column, int row)
	{
		if (this.column == column && this.row == row) {
			return;
		}
		if (buttons [column] [row].transform.name == "continue" && !canContinue) {
			return;
		} 

		buttonState (this.column, this.row, false);
		this.column = column;
		this.row = row;
		buttonState (this.column, this.row, true);

		AudioSource audio = gameObject.AddComponent<AudioSource>();
		audio.clip = button;
		audio.Play ();

			
		
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

	void disableContinue ()
	{
		buttons [1] [0].GetComponentInChildren<Text> ().color = Color.gray;
		buttons [1] [0].GetComponent<Image> ().color = Color.black;
		

	}

	void buttonState (int column, int row, bool isSelected)
	{
		if (!isSelected) {
			buttons [column] [row].GetComponent<Image> ().sprite = graySprites [column] [row];
			buttons [column] [row].transform.GetChild (0).transform.localScale = new Vector3 (scaleX, scaleY, scaleZ);
			
		}

		if (isSelected) {
			buttons [column] [row].GetComponent<Image> ().sprite = coloredSprites [column] [row];
			
		}
	}


}
