using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI機能の利用に必要なusing文
using UnityEngine.SceneManagement;

// ゲーム管理スクリプト
public class HealthScript : MonoBehaviour {

	// メンバ変数宣言
	public GameObject RisanuChan; //ユニティちゃん
	public GameObject explosion; //爆発アニメーション
	public Text gameOverText,titletext; //ゲームオーバーの文字
	private bool gameOver = false;//ゲームオーバー判定
	public GameObject fullObj_Health_1, fullObj_Health_2, fullObj_Health_3;
	public GameObject emptyObj_Health_1, emptyObj_Health_2, emptyObj_Health_3;

	// プレイヤーの残り体力をUIに適用(PlayerControllerから呼び出される)
	// 引数health : 残り体力
	public void SetPlayerHealthUI (int health)
	{
			// 残り体力によって非表示にすべき体力アイコンを消去する
			if (health == 3) fullObj_Health_3.SetActive(true);
			if (health == 2)
			{ // 体力2になった場合
				 fullObj_Health_3.SetActive(false);
				 fullObj_Health_2.SetActive(true);
				 emptyObj_Health_3.SetActive(true);
			}

			else if (health == 1)
			{ // 体力1になった場合
				 fullObj_Health_2.SetActive(false);
				 emptyObj_Health_2.SetActive(true);
			}
			else if (health == 0)
			{ // 体力0になった場合
				 fullObj_Health_1.SetActive(false);
				 emptyObj_Health_1.SetActive(true);

				if (gameOver == false) {
					Instantiate (explosion, RisanuChan.transform.position + new Vector3 (0, 1, 0), RisanuChan.transform.rotation);
				}
				//ゲームオーバー判定をtrueにし、ユニティちゃんを消去
				GameOver ();
			}
	}

	public void SetPlayerTimeUI (bool TimeOver)
	{
		if (TimeOver == true)
		{
			fullObj_Health_1.SetActive(false);
			emptyObj_Health_1.SetActive(true);
			fullObj_Health_2.SetActive(false);
			emptyObj_Health_2.SetActive(true);
			fullObj_Health_3.SetActive(false);
			emptyObj_Health_3.SetActive(true);
			GameOver();
		}
	}

	void Update() {
		//ゲームオーバー判定がtrueの時、
		if (gameOver == true) {
			//ゲームオーバーの文字を表示
			gameOverText.enabled = true;
			titletext.enabled = true;
			//画面をクリックすると
			CallTitle();
		}
	}

	public void GameOver ()
	{
		gameOver = true;
		Destroy(RisanuChan);
	}

	void CallTitle() {
		if (Input.GetKeyDown("space")) {
			SceneManager.LoadScene("Title");
		}
	}
}