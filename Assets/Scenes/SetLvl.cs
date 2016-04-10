using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SetLvl : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void ResetLvl()
    {
        SceneManager.LoadScene("Endless_1");
    }
    public void ExitLvl()
    {
        Debug.Log("close");
        Application.Quit();
    }
}
