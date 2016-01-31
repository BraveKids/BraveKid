using UnityEngine;
using UnityEngine.UI;

using System.Collections;

public class dialogManager : MonoBehaviour {
	public GameObject textBox;
	public Text theText;
	public TextAsset textFile;
	public string[] textLines;
	private int currentLine = 0;
	private int endAtLine;
	private bool active = false;
	GameObject Yume;



	// Use this for initialization
	void Start () {
		textBox = GameObject.Find ("dialogPanel");
		theText = textBox.transform.GetComponentInChildren<Text> ();


		showDialog (false);	//hide the dialog box

		if (textFile != null) {
			textLines = textFile.text.Split ('\n');
		}


		endAtLine = textLines.Length - 1;
	
		gameObject.SetActive (false);	//stop the script
	}

	public void Activate () {

		active = true;
		gameObject.SetActive (true);	//riattivo lo script e il conseguente metodo update

		showDialog (true);	//show dialog box		
	}

	public void Deactivate () {
		active = false;


		showDialog (false);

		gameObject.SetActive (false);

		
	}

	void Update () {
		if (active) {
			theText.text = textLines [currentLine];

			if (Input.GetKeyDown (KeyCode.Return) || Input.GetKeyDown(KeyCode.Joystick1Button0)) {
				currentLine++;
			}

			if (currentLine > endAtLine) {
				Deactivate ();
			
			}
		}
	}

	void showDialog (bool show) {
		textBox.GetComponentInChildren<Image> ().enabled = show;	//enabled/disabled the dialogBox
		theText.text = "";	//clean the text
		
	}
}

