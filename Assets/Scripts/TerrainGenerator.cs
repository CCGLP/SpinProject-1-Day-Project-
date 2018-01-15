using UnityEngine;
using System.Collections;
using System.Collections.Generic; 
public class TerrainGenerator : MonoBehaviour {
	[SerializeField]
	private float positionZ; 
	private float positionY = 17.5f; 

	[SerializeField]
	private AnimationCurve velocityByTime; 

	[SerializeField]
	private AnimationCurve spawnByTime; 


	private float speed; 
	[SerializeField]
	private float timeToSpawn = 10f; 

	[SerializeField]
	private float timeToSpawnObstacles = 4f; 
	private float timerObs = 2000; 
	private float timer = 0; 

	[SerializeField]
	private List<GameObject> obstacles; 
		

	// Use this for initialization
	void Start () {
		//Instantiate (cilinder, new Vector3 (0, positionY, 0), cilinder.transform.rotation); 
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime; 
		timerObs += Time.deltaTime; 
		timeToSpawnObstacles = spawnByTime.Evaluate (timer);
		speed = velocityByTime.Evaluate (timer); 
		if (timerObs > timeToSpawnObstacles) {
			timerObs = 0; 
			int aux = Random.Range (0, obstacles.Count);
			GameObject auxG; 
			auxG = ((GameObject) Instantiate (obstacles [aux], new Vector3 (0, positionY, 400), obstacles [aux].transform.rotation));  
			auxG.transform.rotation = Quaternion.Euler(new Vector3(0, 0,Random.Range(0,360))); 
			auxG.GetComponentInChildren<MoveForward> ().SetSpeed (speed); 
		}
	}
}
