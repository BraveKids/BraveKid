using UnityEngine;
using System.Collections;

public class PulleyActivation : MonoBehaviour {
    private bool isActivated;
    GameObject leverSelected;
    GameObject leverNotSelected;
    GameObject brickAttached;

    public bool IsActivated {
        get { return isActivated; }
        set { isActivated = value; }
    }

    void Start() {
        isActivated = false;
        leverNotSelected = transform.GetChild(1).GetChild(0).gameObject;
        brickAttached = transform.GetChild(1).GetChild(0).GetChild(0).gameObject;
        leverSelected = transform.GetChild(1).GetChild(1).gameObject;
    }
	
	// Update is called once per frame
	void Update () {
        if (isActivated) {
            brickAttached.SetActive(true);

            Vector2 obstaclePosition = transform.GetChild(0).position;
            Vector2 leverPosition = transform.GetChild(1).position;
            Vector2 obstacleUpPosition = transform.GetChild(2).position;
            Vector2 leverDownPosition = transform.GetChild(3).position;

            transform.GetChild(0).position = Vector2.Lerp(obstaclePosition, obstacleUpPosition, 3f * Time.deltaTime);
            transform.GetChild(1).position = Vector2.Lerp(leverPosition, leverDownPosition, 3f * Time.deltaTime);

            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            setOuterglowSelection(false);
        }        
	}

    void OnTriggerStay2D(Collider2D other) {
        if (other.CompareTag("Player") && !isActivated) {
            setOuterglowSelection(true);
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player") && !isActivated) {
            setOuterglowSelection(false);
        }
    }

    void setOuterglowSelection(bool isSelectionActivated) {
        if (isSelectionActivated) {
            leverSelected.SetActive(true);
            leverNotSelected.SetActive(false);
        } else {
            leverSelected.SetActive(false);
            leverNotSelected.SetActive(true);
        }
    }
}
