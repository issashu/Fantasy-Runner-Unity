using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManage : MonoBehaviour 
{

	public Text CurrentScore;
	public Text HighScore;

	public float ScoreCounter;
	public float HighScoreCounter;

	public float PointsPerSec;

	public bool ScoreCount;

	public Text Lives;

	// Use this for initialization
	void Start () 
	{
		if (PlayerPrefs.GetFloat ("HighestScore") != null) 
		{
			HighScoreCounter = PlayerPrefs.GetFloat ("HighestScore");
		}

		//if (PlayerPrefs.GetFloat ("HighestScore") == null) 
		//{
		//	HighScoreCounter = 0f;
		//}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (ScoreCount == true) 
		{
			ScoreCounter += PointsPerSec * Time.deltaTime;
			CurrentScore.text = "Score:" + Mathf.Round (ScoreCounter);
			HighScore.text = "Highest Score:" + HighScoreCounter;
		}

		if (ScoreCounter > HighScoreCounter) 
		{
			HighScoreCounter = Mathf.Round (ScoreCounter);
			PlayerPrefs.SetFloat ("HighestScore", HighScoreCounter);
		}

		Lives.text = "Lives:" + GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerHealth> ().Lives;
	}
}
