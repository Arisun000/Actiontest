using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy1Script : MonoBehaviour {
	
	private new Rigidbody2D rigidbody2D;
	public float speed = -3f;
	public GameObject explosion;

	private const string MAIN_CAMERA_TAG_NAME = "MainCamera";
	private bool _isRendered = false;

	void Start () {
		rigidbody2D = GetComponent<Rigidbody2D>();
	}
	
	void Update () {
		if(_isRendered) {
		 rigidbody2D.velocity = new Vector2 (transform.localScale.x * speed, rigidbody2D.velocity.y);
		}
	}
	
	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.tag == "Bullet") {
			FindObjectOfType<ScoreScript>().Addpoint(10);
			Destroy (gameObject);
			Instantiate (explosion, transform.position, transform.rotation);
		}
	}

	void OnCollisionEnter2D (Collision2D col)
	{	
		if (col.gameObject.tag == "Block") {
			Vector2 temp = gameObject.transform.localScale;
			temp.x *= -1;
			gameObject.transform.localScale = temp;
		}
	}

		//Rendererがカメラに映ってる間に呼ばれ続ける
	void OnWillRenderObject()
	{
    //メインカメラに映った時だけ_isRenderedをtrue
		if(Camera.current.tag == MAIN_CAMERA_TAG_NAME){
		_isRendered = true;
		}
	}
}