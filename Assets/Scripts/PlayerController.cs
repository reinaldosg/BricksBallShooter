using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
	[SerializeField]
	private Transform wrapper;
	private const float maximumPull = 200f; //160
	[SerializeField]
	private InputManagerScript InputInstance;
	
	[SerializeField]
	private Vector3 BallDirection;
	public Vector3 BallLandingPosition;
	private bool Ballrelease;
	public bool BallMoving;
	
	[SerializeField]
	public int BallsAmount = 1;
	
	[SerializeField]
	private int speed = 9;
	
	[SerializeField]
	private ground groundInstance;
	
	[SerializeField]
	private Rigidbody2D BallPrefab;
	
	//tampung jumlah bola saat next spawn
	public int ballCountNextSpawn =1;
	
	public Text JumlahBola;
	
	private int sisaBola;
	private int counterSpawn;
	
    // Start is called before the first frame update
    void Start()
    {
        wrapper.parent.gameObject.SetActive(false); 
		//sisaBola = BallsAmount;
    }
	
	    // Update is called once per frame
    void FixedUpdate()
    {
		if(GameObject.Find("BallPrefab(Clone)")){
			BallMoving = true;
		}else{
			BallMoving = false;
			JumlahBola.text = BallsAmount.ToString("0x");
			sisaBola =0;
			counterSpawn =0;
		}
		
		if(BallMoving){
			GetComponent<SpriteRenderer>().enabled = false;
		}
		
		if(!BallMoving){
			GetComponent<SpriteRenderer>().enabled = true;
			transform.position = new Vector3(BallLandingPosition.x, transform.position.y, transform.position.z);
			ControlPlayer();
		}
		
		if(Ballrelease){
			InputInstance.swipeDelta = Vector2.zero;
			StartCoroutine(waitToReleaseBall());
			Ballrelease  = false;
		}
    }
	
	IEnumerator waitToReleaseBall(){
		for(int i = 1; i <= BallsAmount; i++){
			Rigidbody2D BallInstance = Instantiate(BallPrefab, transform.position, Quaternion.identity);
			BallInstance.velocity = BallDirection * speed;
			counterSpawn = counterSpawn + 1;
			sisaBola = BallsAmount - counterSpawn;
			JumlahBola.text = sisaBola.ToString("0x");
			yield return new WaitForSeconds(0.1f);
		}
	}
	
	void ControlPlayer(){
		Vector3 sd = InputInstance.swipeDelta;
		sd.Set(sd.x, sd.y, sd.z);
		
		if(sd != Vector3.zero){
			if(sd.y < 0){
				wrapper.parent.gameObject.SetActive(false);
			}
			else{
				wrapper.parent.up = sd.normalized;
				wrapper.parent.gameObject.SetActive(true);
				wrapper.localScale = Vector3.Lerp(new Vector3(1f,1f,1f),new Vector3(1.8f,1.8f,1f),sd.magnitude/maximumPull);
				
				if(InputInstance.release == true){
					wrapper.parent.gameObject.SetActive(false);
					BallDirection = sd.normalized;
					BallPrefab.simulated = true;
					Ballrelease = true;
				}
			}
		}
	}
}
