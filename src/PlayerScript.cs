using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour {

	public float speed = 4f;
	public float jumpPower = 250.0f;
	public LayerMask groundLayer;
	public GameObject mainCamera;
	public GameObject bullet;
	private bool Jumpjudge = false;
	private int jumpcount = 0;
	private const int MAX_JUMP = 2;
	
	public HealthScript healthscript;
	private new Rigidbody2D rigidbody2D;
	private Animator anim;
	private bool isGrounded, lifejudge = true;
	private int health;
	private new Renderer renderer;

	private bool gameClear = false; //ゲームクリアーしたら操作を無効にする
	public Text clearText, titletext; //ゲームクリア時に表示するテキスト
	
	void Start () {
		anim = GetComponent<Animator>();
		rigidbody2D = GetComponent<Rigidbody2D>();
		health = 3; // 初期体力をセット
		// 初期体力をUIに表示
		healthscript.SetPlayerHealthUI (health);

		renderer = GetComponent<Renderer>();
	}

	void Update ()
	{
		if(health > 3) health = 3;
		isGrounded = Physics2D.Linecast (
		transform.position + transform.up * 1,
		transform.position - transform.up * 0.05f,
		groundLayer);

		if (jumpcount < MAX_JUMP && Input.GetKeyDown ("space"))
		{
			isGrounded = false;
			Jumpjudge = true;
		}

		float velY = rigidbody2D.velocity.y;
		bool isJumping = velY > 0.1f ? true:false;
		bool isFalling = velY < -0.1f ? true:false;
		anim.SetBool("isJumping",isJumping);
		anim.SetBool("isFalling",isFalling);
		if (isJumping == false && isFalling == false) anim.ResetTrigger("Jump");

	if (!gameClear) {
		if (Input.GetKeyDown ("left ctrl")){
			anim.SetTrigger("Shot");
			Instantiate(bullet, transform.position + new Vector3(0f,1.2f,0f), transform.rotation);
		}
	}
	}
	
	void FixedUpdate ()
	{
	if (!gameClear) {	

		if(Jumpjudge) {
				anim.SetTrigger("Jump");
				if(jumpcount == 1) {
					anim.SetTrigger("DoubleJump");
				}
			rigidbody2D.velocity = Vector2.zero;
			rigidbody2D.AddForce( Vector2.up * jumpPower);
			jumpcount++;
			Jumpjudge = false;
		}
		float x = Input.GetAxisRaw ("Horizontal");
		if (x != 0) {
			rigidbody2D.velocity = new Vector2 (x * speed, rigidbody2D.velocity.y);
			Vector2 temp = transform.localScale;
			temp.x = x;
			transform.localScale = temp;
			anim.SetBool ("Dash", true);
				Vector3 cameraPos = mainCamera.transform.position;
				cameraPos.x = transform.position.x + 4;
				mainCamera.transform.position = cameraPos;

			Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
			Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
			Vector2 pos = transform.position;
			pos.x = Mathf.Clamp(pos.x, min.x + 0.5f, max.x);
			transform.position = pos;
		} else {
			rigidbody2D.velocity = new Vector2 (0, rigidbody2D.velocity.y);
			anim.SetBool ("Dash", false);
		}
	} else {
		clearText.enabled = true;
		titletext.enabled = true;
		CallTitle();
	}
	}


	void OnCollisionEnter2D (Collision2D col)
	{
		if (col.gameObject.tag == "Field") {
			jumpcount = 0;
			anim.ResetTrigger("DoubleJump");
		}
		//Enemyとぶつかった時にコルーチンを実行
		if (col.gameObject.tag == "Enemy") {
			StartCoroutine ("Damage");
		}		
		if (col.gameObject.tag == "Item") {
			health++;
			healthscript.SetPlayerHealthUI (health);
		}
	}

		void OnTriggerEnter2D (Collider2D col)
	{
		if (col.gameObject.tag == "Block") {
			jumpcount = 0;
			anim.ResetTrigger("DoubleJump");
		}

		if (col.tag == "ClearZone") {
			gameClear =true;
		}
	}

	IEnumerator Damage ()
	{
		//レイヤーをPlayerDamageに変更
		gameObject.layer = LayerMask.NameToLayer("PlayerDamage");
		if (lifejudge == true){
			health--;
			healthscript.SetPlayerHealthUI (health);
			lifejudge = false;
		}

		//while文を10回ループ
		int count = 10;
		while (count > 0){
			//透明にする
			renderer.material.color = new Color (1,1,1,0);
			//0.05秒待つ
			yield return new WaitForSeconds(0.05f);
			//元に戻す
			renderer.material.color = new Color (1,1,1,1);
			//0.05秒待つ
			yield return new WaitForSeconds(0.05f);
			count--;
		}
		//レイヤーをPlayerに戻す
		gameObject.layer = LayerMask.NameToLayer("Player");
		lifejudge = true;
	}

	void CallTitle() {
		if (Input.GetKeyDown("space")) {
			SceneManager.LoadScene("Title");
		}
	}
}