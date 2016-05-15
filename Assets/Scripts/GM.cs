//Maze game made for http://catlikecoding.com/unity/tutorials/maze/

using UnityEngine;
using System.Collections;

public class GM : MonoBehaviour {

	public Maze mazePrefab;

	private Maze mazeInstance;

	// Use this for initialization
	void Start () 
	{
		BeginGame ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.Space)) 
		{
			RestartGame ();
		}
	}

	void BeginGame()
	{
		mazeInstance = Instantiate (mazePrefab) as Maze;
		StartCoroutine(mazeInstance.Generate ());
	}

	void RestartGame()
	{
		StopAllCoroutines ();
		Destroy (mazeInstance.gameObject);
		BeginGame ();
	}
}
