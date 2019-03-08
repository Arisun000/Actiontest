using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy1Script : MonoBehaviour {
	
	private new Rigidbody2D rigidbody2D;
	public float speed = -3f;
	public GameObject explosion;
	public bool Bombs = false;
	public GameObject BombObject;
	public GameObject bomb;

	private const string MAIN_CAMERA_TAG_NAME = "MainCamera";
	public bool _isRendered = false;

	void Start () {
		rigidbody2D = GetComponent<Rigidbody2D>();
	}
	
	void Update () {
	if (BombObject != null) Bombs = BombObject.GetComponent<BombScript> ().Bombjudge; 

		if(_isRendered) {
			rigidbody2D.velocity = new Vector2 (transform.localScale.x * speed, rigidbody2D.velocity.y);
		} else {
			rigidbody2D.velocity = new Vector2 (0,0);
		}
		if(Bombs == true && _isRendered == true && Input.GetKeyDown("left shift")) {
			bomb.gameObject.SetActive(false);
			Damage();
			Destroy(BombObject);
		}	
}

	void Damage ()
	{
		FindObjectOfType<ScoreScript>().Addpoint(10);
		Destroy (gameObject);
		Instantiate (explosion, transform.position, transform.rotation);
	}
	
	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.tag == "Bullet") Damage();
	}

	void OnCollisionEnter2D (Collision2D col)
	{	
		if (col.gameObject.tag == "Block" || col.gameObject.tag == "Enemy") {
			Vector2 temp = gameObject.transform.localScale;
			temp.x *= -1;
			gameObject.transform.localScale = temp;
		}
	}

		//Rendererがカメラに映ってる間に呼ばれ続ける
	void OnWillRenderObject() {
    //メインカメラに映った時だけ_isRenderedをtrue
		if(Camera.current.tag == MAIN_CAMERA_TAG_NAME) _isRendered = true;
		else _isRendered = false;
	}
}