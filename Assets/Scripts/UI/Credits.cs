using UnityEngine;
using System.Collections;

public class Credits : MonoBehaviour
{
	public bool end;
	float posX;
	float posY;
	GameObject text;
	float t = 0;
	float transitionDuration = 20f;
	float moveSpeed = 50f;

	public GameObject mainMenu;
	// Use this for initialization
	void Start ()
	{
		text = transform.GetChild (0).gameObject;
		posX = text.transform.position.x;
		posY = text.transform.position.y;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if ((Input.GetKeyDown (KeyCode.Escape) || Input.GetKeyDown (KeyCode.Joystick1Button7))) {
			if(end){
				Application.LoadLevel("Menu");
			}
			toMainMenu();
		}
		if (t < 1f) {
			
			t += Time.deltaTime / transitionDuration;

			text.transform.position=new Vector3(text.transform.position.x, text.transform.position.y+Time.deltaTime*Time.timeScale*moveSpeed,0f);

			
			if (t >= 1f) {
				t = 0f;
				Application.LoadLevel("Menu");
				resetCredits();
			}
		}
	}

	void resetCredits ()
	{
		text.transform.position = new Vector3 (posX, posY, 0f);
	}

	void toMainMenu(){
		resetCredits();
		mainMenu.SetActive(true);
		gameObject.SetActive(false);
	}
	
}
