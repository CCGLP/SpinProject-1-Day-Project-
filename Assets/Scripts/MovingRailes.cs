using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement; 
using UnityEngine.UI; 
public class MovingRailes : MonoBehaviour {

	private float angle = 0; 
	[SerializeField]
	private float secondsToCircle = 6; 
	private float speed;
	[SerializeField]
	private float radius = 8; 

	[SerializeField]
	private Text scoreText; 
	private int score = 0; 

	[SerializeField]
	private AudioSource coin; 
	private Vector3 center; 

	private int previousTouchCount = 0; 

	// Use this for initialization
	void Start () {
		center = this.transform.position; 
		speed = ((2 * Mathf.PI) / secondsToCircle); 	
		angle = 0;
		this.transform.position = new Vector3 (Mathf.Cos (angle) * radius + center.x, Mathf.Sin (angle) * radius + center.y, this.transform.position.z);
	}

	// Update is called once per frame
	void Update () {
		this.transform.LookAt (center);
		#if UNITY_EDITOR
		if (Input.GetMouseButtonDown(0)) {
			if (Input.mousePosition.x > Screen.width / 2 + Screen.width / 4) {
				angle += speed;
				this.transform.position = new Vector3 (Mathf.Cos (angle) * radius + center.x, Mathf.Sin (angle) * radius + center.y, this.transform.position.z);
			} else if (Input.mousePosition.x < Screen.width / 2 - Screen.width / 4) {
				angle -= speed;
				this.transform.position = new Vector3 (Mathf.Cos (angle) * radius + center.x, Mathf.Sin (angle) * radius + center.y, this.transform.position.z);
			}

		}

		#endif


		#if UNITY_ANDROID
		if ((previousTouchCount - Input.touchCount) < 0) {
			if (Input.GetTouch (Input.touchCount - 1).position.x > Screen.width / 2 + Screen.width / 4) {
				angle += speed;
				this.transform.position = new Vector3 (Mathf.Cos (angle) * radius + center.x, Mathf.Sin (angle) * radius + center.y, this.transform.position.z);
			} else if (Input.GetTouch (Input.touchCount - 1).position.x < Screen.width / 2 - Screen.width / 4) {
				angle -= speed; 
				this.transform.position = new Vector3 (Mathf.Cos (angle) * radius + center.x, Mathf.Sin (angle) * radius + center.y, this.transform.position.z);
			}

		}
		#endif

		previousTouchCount = Input.touchCount;
	}


	void OnCollisionEnter(Collision coll) {
		SceneManager.LoadScene (1); 
	}

	void OnTriggerEnter(Collider coll) {
		if (coll.gameObject.tag == "enemy") {
			PlayerPrefs.SetInt ("score", score); 
			SceneManager.LoadScene (1); 

		} else {
			coin.Play ();
			score += int.Parse (coll.gameObject.tag);
			scoreText.text = "Score: " + score.ToString(); 
		}

	}


}


