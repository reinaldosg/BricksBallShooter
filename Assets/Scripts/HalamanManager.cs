using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HalamanManager : MonoBehaviour
{
	public bool isEscapeToExit;
  private Bricks brickInstance;
	
    // Start is called before the first frame update
    void Start()
    {
        brickInstance = GameObject.Find("Bricks(Clone)").GetComponent<Bricks>();
    }

    // Update is called once per frame
    void Update()
    {
   	  if (Input.GetKeyUp(KeyCode.Escape)){
		  	SceneManager.LoadScene("Quit");
		  }  
    }
	
	public void MulaiPermainan(){
		SceneManager.LoadScene("GamePlay");
	}
	
	public void KembaliKeMenu(){
		SceneManager.LoadScene("Home");
    	Data.level = 1;
			brickInstance.counter =1;
	}
	
	public void KeluarScene() {
      PlayerPrefs.SetInt("HighScore",Data.Best);
      Application.Quit();
   }
   
}
