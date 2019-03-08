using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
	public Text scoreText; //スコアテキストのアタッチ用
	public static int score = 0; //スコア

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
        getA();
    }

    void Reset()
    {
    	score = 0;	 //ゲーム開始時スコア初期化
    }

    public static int getA(){
        return score;
    }
}
