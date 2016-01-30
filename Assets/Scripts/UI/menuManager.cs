using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;

public class menuManager : MonoBehaviour
{

	//public List<Button> buttons;
	public List<List<GameObject>> buttons;
	// Use this for initialization
	int row;
	int column;
	GameObject selected;
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

	void Start ()
	{
		GameObject newGame = transform.FindChild ("newGame").gameObject;
		GameObject continueGame = transform.FindChild ("continue").gameObject;
		GameObject credits = transform.FindChild ("credits").gameObject;
		GameObject exitGame = transform.FindChild ("exitGame").gameObject;

		List<GameObject> colonna1 = new List<GameObject> (){newGame, credits};
		List<GameObject> colonna2 = new List<GameObject> (){continueGame,exitGame};

		buttons = new List<List<GameObject>> (){colonna1,colonna2};
		row = 0;
		column = 0;
		t = 0;
		transitionDuration = 1f;

		scaleX = buttons [0] [0].transform.localScale.x;
		scaleY = buttons [0] [0].transform.localScale.y;
		scaleZ = buttons [0] [0].transform.localScale.z;

		if(!canContinue){
			disableContinue();

		}
	}
	
	// Update is called once per frame
	void Update ()
	{
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

		Debug.Log ("selected: " + buttons [column] [row].ToString ());
		

		
	}

	void changeButton (int column, int row)
	{
		if (buttons [column] [row].transform.name == "continue" && !canContinue){return;} 
			buttons [this.column] [this.row].transform.GetChild (0).transform.localScale = new Vector3 (scaleX, scaleY, scaleZ);

			this.column = column;
			this.row = row;
		
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

	void disableContinue(){
		continueGame.transform.GetComponentInChildren<Text>().color=Color.gray;
	
	}
}
