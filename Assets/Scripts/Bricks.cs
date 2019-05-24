using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Bricks : MonoBehaviour
{
	public int counter = 1;
	private Text brickHealthText;
	public Gradient gradient;
	private SpriteRenderer renderer;

	private PlayerController PlayerInstance;
	
	void Start(){
		PlayerInstance = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
		brickHealthText = GetComponentInChildren<Text>();
		brickHealthText.text = counter.ToString("0");
		renderer = GetComponent<SpriteRenderer>();
		renderer.color = gradient.Evaluate(Random.Range(0f,1f));
	}
	
	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag == "BallPrefab"){
			counter--;
			brickHealthText.text = counter.ToString("0");
		}
		if(counter <= 0){
		   Destroy(this.gameObject);
		}
	}
}
