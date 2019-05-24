using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlusBola : MonoBehaviour
{
	private PlayerController PlayerInstance;
	
    // Start is called before the first frame update
    void Start()
    {
        PlayerInstance = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
      
    }
	
	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.tag == "BallPrefab"){
			this.GetComponent<CircleCollider2D>().enabled = false;
			PlayerInstance.ballCountNextSpawn +=1;
			Destroy(this.gameObject);
		}
	}
	
	void OnTriggerExit2D(Collider2D col){
		if(col.gameObject.tag == "akhir"){
			Destroy(this.gameObject);
		}
	}
}
