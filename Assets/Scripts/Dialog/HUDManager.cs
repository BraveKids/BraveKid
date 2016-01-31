using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class HUDManager : MonoBehaviour {

	
	// Use this for initialization
	public void Start () {


	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape) || Input.GetKeyDown (KeyCode.Joystick1Button7)) {
			//pauseMenu.SetActive (true);
			//pauseMenu.GetComponent<PauseMenu> ().showPauseMenu();
		}
	}



	//completamente inutili a quanto pare
	void Awake () {
		DontDestroyOnLoad (gameObject);
		DontDestroyOnLoad (gameObject.transform.GetChild (0));
		
	}
}
