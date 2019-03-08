using UnityEngine;
using UnityEngine.UI;

public class FlashScript : MonoBehaviour 
{

	private Image img;
	public GameObject damageObject;
	public bool Damage = false;

	void Start () {
		img = GetComponent<Image> ();
		img.color = Color.clear;
	}

	void Update () 
	{
		if (Damage == true)
		{
			this.img.color = new Color (0.5f, 0f, 0f, 0.5f);
		}
		else
		{
			this.img.color = Color.Lerp (this.img.color, Color.clear, Time.deltaTime);
		}
	}
}