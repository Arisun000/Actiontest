using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemBoxScript : MonoBehaviour{

	SpriteRenderer MainSpriteRenderer;
	public GameObject content; //アイテムを入れる
	public bool judge = false;
	private Vector2 movePoint; //アイテムの動き
	private bool IsOpened, IsActive; //アイテム出現のフラグ

	public EmptyBoxScript emptyboxscript;
	private BoxCollider2D[] m_Colliders;

	void Start(){
        MainSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    	m_Colliders = GetComponentsInChildren<BoxCollider2D>();

    	content = Instantiate(content);
    	content.transform.position = transform.position;
    	content.transform.SetParent(gameObject.transform);
    	content.gameObject.SetActive(false);

    	IsOpened = false;
    	IsActive = true;

    	movePoint = (Vector2)transform.position + new Vector2(0.0f, 1.2f);
    }

    private void Update(){
    	if(IsOpened && IsActive) {
    		content.transform.position = Vector2.Lerp(content.transform.position, movePoint, 0.35f);
    	}
    }

    private void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "RisanuChan"){
    		content.gameObject.SetActive(true);
    		IsOpened = true;
    		StartCoroutine(WaitSwitchOff());
    		judge = true;
   	 		emptyboxscript.SetItemBoxUI (judge);
    	}
    }

    private IEnumerator WaitSwitchOff(){
    	yield return new WaitForSeconds(1.0f);
    	IsActive = false;
    	Destroy (this.gameObject, 5.0f);
    }
}
