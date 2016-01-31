using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

[System.Serializable]
public class Game {
	public static Game current;

	//public bool firstGame = true;
	public int level;

	public Game () {

		level = 9;
		
	}

}
