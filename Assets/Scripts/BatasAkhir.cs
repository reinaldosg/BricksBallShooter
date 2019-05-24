using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BatasAkhir : MonoBehaviour
{
	private Bricks brickInstance;

    // Start is called before the first frame update
    void Start()
    {
		brickInstance = GameObject.Find("Bricks(Clone)").GetComponent<Bricks>();
    }
	
	void OnTriggerStay2D(Collider2D col){
		if(col.gameObject.tag == "brick"){
			SceneManager.LoadScene("GameOver");
			Data.level = 1;
			brickInstance.counter =1;
		}
	}
}
