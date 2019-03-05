using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CallStageScript : MonoBehaviour {
	
	public Text title;
	public Text Key;
	private int i = 1;

	void Update (){
		if (i == 1 && Input.GetKeyDown("space")) {
			title.text = "攻撃:左Ctrlキー\n\n移動:矢印キー\n\nジャンプ:Spaceキー";
			Key.text ="---Press to Left Cotrol Key---";
			i++;
		}
		if(i == 2 && Input.GetKeyDown("left ctrl")) {
			SceneManager.LoadScene("Main");
		}
	}
}