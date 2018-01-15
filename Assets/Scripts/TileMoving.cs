using UnityEngine;
using System.Collections;

public class TileMoving : MonoBehaviour {
	Renderer rend; 

	float offsetY = 0; 

	private float speedOffset = 2; 

	[SerializeField]
	private AnimationCurve speedByTime; 

	private float timer= 0; 
	// Use this for initialization
	void Start () {
		rend = this.GetComponent<Renderer> (); 

	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime; 
		speedOffset = speedByTime.Evaluate (timer); 
		offsetY-= 2 * Time.deltaTime;

		rend.material.SetTextureOffset ("_MainTex", new Vector2(0, offsetY));


	}
}
