using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ground : MonoBehaviour
{
	public int destroy=0;
	
	public GameObject bricks;
	public GameObject AddBall;
	private Renderer render;
	public Text level;
	public Text best;
	
	private PlayerController playerInstance;
	private SpawnBrick spawnBrickInstance;
	private Bricks brickInstance;
	
	const float UKURAN_BALOK = 2.93f*0.32f;
	
	void Start(){
		playerInstance = GameObject.Find("Player").GetComponent<PlayerController>();
		spawnBrickInstance = GameObject.Find("SpawnBrick").GetComponent<SpawnBrick>();
		brickInstance = GameObject.Find("Bricks(Clone)").GetComponent<Bricks>();
		Data.Best = PlayerPrefs.GetInt("HighScore", Data.Best);
		Debug.Log(PlayerPrefs.HasKey("HighScore"));
		best.text = Data.Best.ToString("0");
	}
	
   void OnCollisionEnter2D(Collision2D col){
	   if(col.gameObject.tag == "BallPrefab"){
		   Destroy(col.gameObject);
		   destroy = destroy +1;
		   //Debug.Log(destroy);
			if(playerInstance.BallsAmount == destroy){			
				ReSpawn();
				Data.level += 1;
					if (Data.level >= Data.Best){
						Data.Best = Data.level;
						best.text = Data.Best.ToString("0");
						PlayerPrefs.SetInt("HighScore",Data.Best);
						PlayerPrefs.Save();
					}
				level.text = Data.level.ToString("0");
			}
	   }			
	}
    
    void ReSpawn(){
		playerInstance.BallsAmount = playerInstance.ballCountNextSpawn;
		//nurunin balok sebaris
		foreach(List<GameObject> element in spawnBrickInstance.ObjBalokArray ){
			foreach(GameObject balokSatuan in element){
				if(balokSatuan != null){
					balokSatuan.transform.position = balokSatuan.transform.position - new Vector3(0,UKURAN_BALOK,0);
				}//Debug.Log(balokSatuan);
			}
		}
	
		//random jumlah blok muncul
		int maxBlock= Random.Range(1,6);
		//List Posisi dalam 1 baris 
		List<int> posArr = new List<int>();
		//List objek dalam 1 baris 
		List<GameObject> bricksRow = new List<GameObject>();
		for(int count=0 ; count < maxBlock; count++){
			//random posisi blok muncul
			RandomPosisi(posArr);
			GameObject newBrick =Instantiate(bricks, new Vector3(UKURAN_BALOK*(posArr[count])-2.42f, 3.5f, 0), Quaternion.identity);
			Bricks brickProperties = newBrick.GetComponent<Bricks>();
			brickProperties.counter = Data.level +1 ;
			Debug.Log(brickProperties.counter);
			bricksRow.Add(newBrick);
			}
		int addBallPos = RandomPowerUp(posArr);
		bricksRow.Add(Instantiate(AddBall, new Vector3(UKURAN_BALOK*addBallPos-2.42f, 3.5f, 0), Quaternion.identity));
		spawnBrickInstance.ObjBalokArray.Add(bricksRow);
		destroy=0;
    }
	
	void RandomPosisi(List<int> arr){
		int randPos = Random.Range(0,5);
		if(arr.Contains(randPos)){
			RandomPosisi(arr);
		} else{
			arr.Add(randPos);
		}
	}
	
	int RandomPowerUp(List<int> arr){
		bool[] temp = new bool[6];
		List<int> candidate = new List<int>();
		foreach(int i in arr){
			temp[i] = true;
		}
		for(int i=0; i<6; i++){
			if(!temp[i]){
				candidate.Add(i);
			}
		}
		int random = Random.Range(0,candidate.Count);
		return candidate[random];
		/* int randPos = Random.Range(0,5);
		while(arr.Contains(randPos)){
			randPos = Random.Range(0,5);
		}
		return randPos; */
	}
}