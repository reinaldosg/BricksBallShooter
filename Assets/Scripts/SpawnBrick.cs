using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBrick : MonoBehaviour
{
	public GameObject bricks;
	public GameObject AddBall;
	private Renderer render;
	public List<List<GameObject>> ObjBalokArray = new List<List<GameObject>>();
	
    // Start is called before the first frame update
    void Start()
    {
        int maxBlock= Random.Range(1,6);	
		float f = 2.93f*0.32f;
		List<int> posArr = new List<int>();
		List<GameObject> bricksRow = new List<GameObject>();
		for(int count=0 ; count < maxBlock; count++){
			//random posisi blok muncul
			RandomPosisi(posArr);
			bricksRow.Add(Instantiate(bricks, new Vector3(f*(posArr[count])-2.42f, 3.5f, 0), Quaternion.identity));
		}
		int addBallPos = RandomPowerUp(posArr);
		bricksRow.Add(Instantiate(AddBall, new Vector3(f*addBallPos-2.42f, 3.5f, 0), Quaternion.identity));
		ObjBalokArray.Add(bricksRow);
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

