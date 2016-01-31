using UnityEngine;
using System.Collections;

public class GrabBrick : MonoBehaviour {
    CharacterControllerScript characterControllerScript;
    bool isInRange;
    GameObject brickSelected;
    GameObject brickNotSelected;

	// Use this for initialization
	void Start () {
        characterControllerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterControllerScript>();
        isInRange = false;
        brickNotSelected = transform.GetChild(0).gameObject;
        brickSelected = transform.GetChild(1).gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        if (characterControllerScript.checkInteract() && isInRange && characterControllerScript.checkItemGrabbed()) {
            characterControllerScript.setInteract(false);
            characterControllerScript.setBrickGrabbed(true);
            setOuterglowSelection(false);
            gameObject.SetActive(false);

        }
	}

    void OnTriggerStay2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            isInRange = true;
            setOuterglowSelection(true);
            characterControllerScript.canInteract(true);
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            isInRange = false;
            setOuterglowSelection(false);
            characterControllerScript.canInteract(false);
        }
    }

    void setOuterglowSelection(bool isSelectionActivated) {
        if (isSelectionActivated) {
            brickSelected.SetActive(true);
            brickNotSelected.SetActive(false);
        } else {
            brickSelected.SetActive(false);
            brickNotSelected.SetActive(true);
        }
    }
}
