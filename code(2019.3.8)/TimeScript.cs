using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeScript : MonoBehaviour
{
	public Text TimeText;
    public bool gameclear = false;
	private float time = 200;
	public bool TimeOver = false;
	public HealthScript healthscript;
    public GameObject PlayerObject;

    void Start()
    {
    	//初期時間表示、float→int→string型に変換
    	TimeText.text = "Time: " + ((int)time).ToString ();
    }

    void Update()
    {
        gameclear = PlayerObject.GetComponent<PlayerScript> ().gameClear;
        if(!gameclear) {
            time -= Time.deltaTime;
            //マイナスを表示しない
            if (time < 0) time = 0;
            TimeText.text = "Time: " + ((int)time).ToString ();
            if (time == 0) 
            {
    	       TimeOver = true;
    	       healthscript.SetPlayerTimeUI (TimeOver);
	       	}
        }
    }    
}
