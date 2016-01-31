using UnityEngine;
using System.Collections;

public class SwitchManager : MonoBehaviour {
    CharacterControllerScript characterControllerScript;
    bool isInRange;
    bool isSwitchable;
    public GameObject lightObj;
    GameObject switchSelected;
    GameObject switchNotSelected;
    GameObject switchON;

	// Use this for initialization
    void Start() {
        characterControllerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterControllerScript>();
        isInRange = false;
        isSwitchable = true;
        switchNotSelected = transform.GetChild(0).gameObject;
        switchSelected = transform.GetChild(1).gameObject;
        switchON = transform.GetChild(2).gameObject;
	}

    public void Toggle() {
        if (isSwitchable && isInRange) {
            lightObj.SetActive(true);
            switchSprite(2);
            isSwitchable = false;
        }
    }

    void OnTriggerStay2D(Collider2D other) {
        if (other.CompareTag("Player") && isSwitchable) {
            isInRange = true;
            switchSprite(0);
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player") && isSwitchable) {
            isInRange = false;
            switchSprite(1);
        }
    }

    void switchSprite(int i) {
        if (i == 0) {
            switchSelected.SetActive(true);
            switchNotSelected.SetActive(false);
            switchON.SetActive(false);
        } else if (i == 1) {
            switchSelected.SetActive(false);
            switchNotSelected.SetActive(true);
            switchON.SetActive(false);
        } else if (i == 2) {
            switchSelected.SetActive(false);
            switchNotSelected.SetActive(false);
            switchON.SetActive(true);
        }
    }
}
