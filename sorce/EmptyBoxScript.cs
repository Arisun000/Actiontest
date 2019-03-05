using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyBoxScript : MonoBehaviour
{
	public GameObject emptybox;

    public void SetItemBoxUI (bool judge)
    {
    	if(judge == true)
    	{
		emptybox.SetActive(true);
    	gameObject.SetActive(false);
		}
    }
}
