﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemScript : MonoBehaviour
{
	void OnCollisionEnter2D (Collision2D col)
	{
		if (col.gameObject.tag == "RisanuChan") {
			Destroy(gameObject);
		}
	}

}
