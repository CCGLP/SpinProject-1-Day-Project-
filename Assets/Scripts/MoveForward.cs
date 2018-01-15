using UnityEngine;
using System.Collections;

public class MoveForward : MonoBehaviour {
	[SerializeField]
	private float speed = 1; 
	[SerializeField]
	private float timeToDestroy = 100; 
	private float timer = 0; 
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime; 

		if (timer > timeToDestroy) {
			Destroy (this.gameObject); 
		}
		this.transform.position -= Vector3.forward * speed * Time.deltaTime;
	}


	public void SetSpeed(float speed){
		this.speed = speed; 
	}
}
