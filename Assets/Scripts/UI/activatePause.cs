using UnityEngine;
using System.Collections;

public class activatePause : MonoBehaviour
{
	public GameObject pause;
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (!pause.activeSelf)
				pause.SetActive (true);
			pause.GetComponent<PauseMenu>().showPauseMenu();

		}
	}
}
