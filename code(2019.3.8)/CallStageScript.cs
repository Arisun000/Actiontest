using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CallStageScript : MonoBehaviour {
	public GameObject title, exp1, exp2;
	public GameObject Key, key2, key3;
	private int i = 1;
	void Update ()
	{
		if (i == 1 && Input.GetKeyDown("space")) {
			i++;
			title.gameObject.SetActive(false);
			exp1.gameObject.SetActive(true);
			Key.gameObject.SetActive(false);
			key2.gameObject.SetActive(true);

		}
		if(i == 2 && Input.GetKeyDown("left ctrl")) {
			i++;
			exp1.gameObject.SetActive(false);
			exp2.gameObject.SetActive(true);
			key2.gameObject.SetActive(false);
			key3.gameObject.SetActive(true);
		}
		if(i == 3 && Input.GetKeyDown("left shift")) {
			SceneManager.LoadScene("Main");
		}
	}
}