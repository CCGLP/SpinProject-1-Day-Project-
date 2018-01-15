using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 
public class GameOverController : MonoBehaviour {
	[SerializeField]
	private Text scoreText; 

	// Use this for initialization
	void Start () {
		scoreText.text = "Your Score is : " + PlayerPrefs.GetInt ("score").ToString(); 
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnClickRestart(){
		SceneManager.LoadScene (0); 

	}

	public void OnArturoClick(){
		SceneManager.LoadScene (2); 
	}
}
