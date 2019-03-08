using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultScript : MonoBehaviour
{
	public static int score;
    public Text Scoretext;

	void Start() {
		score = ScoreScript.getA();
		Scoretext.text = "SCORE: " + score;
	}
	
	void Update() {
		if(Input.GetKeyDown("space")) SceneManager.LoadScene ("Title");
	}
}