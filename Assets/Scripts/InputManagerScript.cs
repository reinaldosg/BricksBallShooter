using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManagerScript : MonoBehaviour
{
	public bool release;
	public bool hold;
	private Vector2 initialPosition;
	public Vector2 swipeDelta;
	
	private PlayerController playerInstance;
	
	void Start(){
		playerInstance = GameObject.Find("Player").GetComponent<PlayerController>();
	}
	
    // Update is called once per frame
    void Update()
    {
		if(playerInstance.BallMoving == false){
			release = false;
		
			if(Input.GetMouseButtonDown(0)){
				initialPosition = Input.mousePosition;
				hold = true;
			} 
			else if(Input.GetMouseButtonUp(0)){
				release = true;
				hold= false;
				swipeDelta = (Vector2)Input.mousePosition - initialPosition;
			}
		
			if(hold){
				swipeDelta = (Vector2)Input.mousePosition - initialPosition;
			}
			if(!hold){
				if(swipeDelta.x < 0 || swipeDelta.y < 0){
					release = true;
				}
			}
		}
	}
}
