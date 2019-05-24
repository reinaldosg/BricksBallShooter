using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPrefab : MonoBehaviour
{	
	private PlayerController PlayerInstance;
	AudioSource audio;
    public AudioClip hitSound;
	
	void Start(){
		PlayerInstance = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
		Physics2D.IgnoreLayerCollision(8,8);
		//Physics2D.IgnoreLayerCollision(8,10);
		audio = GetComponent<AudioSource>();
	}
	void OnDestroy(){
		PlayerInstance.BallLandingPosition = transform.position;
	}
	
	private void OnCollisionEnter2D(Collision2D col)
    {
		if(col.gameObject.tag == "brick"){
        audio.PlayOneShot(hitSound);
		}
	}
}
