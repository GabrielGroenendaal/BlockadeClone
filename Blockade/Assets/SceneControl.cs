using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Application = UnityEngine.Application;

public class SceneControl : MonoBehaviour {
	
	// This code keeps track of the players as a hard lose state. If either go down to 5 health, they're out. 
	public PlayerControl player1;
	public PlayerControl player2;
	
	// Stores a string to be used in the gave over screen
	public Text winner;
	public string gameover;

	// Use this for initialization
	void Start ()
	{
		
	}
    

	// Update is called once per frame
	void Update () {
		// Determines what scene it is, and if the appropiate input is made, moves to the next Scene
        
		Scene m_scene = SceneManager.GetActiveScene();
        
		// Checks for the WinCondition to be fufilled in the PlayerController Script
		if (m_scene.name == "MainMenu")
		{
			//GameObject player = GameObject.Find("player");
			//PlayerController p = player.GetComponent<PlayerController>();
        
        
			//if (Input.GetKeyDown(KeyCode.Space) && p.WinState)
			if (Input.GetKeyDown(KeyCode.Space))
			{
				SceneManager.LoadScene(1);
			}
		}
                
		// This code checks the game every frame to during the Game scene to see if the lose condition has been activated.
		// If it has, it will change to the game over screeen
		else if (m_scene.name == "Game" && player1.getScore()==0)
		{
			gameover = "Player 2";
			SceneManager.LoadScene(2);
        
		}
        
		else if (m_scene.name == "Game" && player2.getScore()==0)
		{
			gameover = "Player 1";
			SceneManager.LoadScene(2);      
		}
                
		// Restarts the Game to the main menu
		else if (m_scene.name == "GameOver")
		{
			if (Input.GetKeyDown(KeyCode.Space))
			{
				SceneManager.LoadScene(0);
				gameover = "";
			}
		}
        
		// This gives the game a "quit" button by pressing Escape
		if (Input.GetKey("escape"))
		{
			Application.Quit();
		}
	}
}
