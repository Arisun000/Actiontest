using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BombScript : MonoBehaviour
{
	public bool Bombjudge = false;

	void OnCollisionEnter2D (Collision2D col)
	{
		if (col.gameObject.tag == "RisanuChan") {
			Bombjudge = true;
			this.gameObject.SetActive(false);
		}
	}
}