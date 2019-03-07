using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
	public Text scoreText; //スコアテキストのアタッチ用
	private int score; //スコア

	void Start()
	{
		Reset();
	}

    void Update()
    {
        scoreText.text = "Score: " + score.ToString ();
    }

    public void Addpoint (int point)
    {
    	score = score + point;
    }

    void Reset()
    {
    	score = 0;	 //ゲーム開始時スコア初期化
    }
}
