using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.WSA;
using Application = UnityEngine.Application;

public class SceneManagement : MonoBehaviour
{
    
    // This code is what we will change when something triggers a lose state
    public Boolean loseState = true;
    
	// Use this for initialization
	void Start () {
		
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
                
                else if (m_scene.name == "Game" && !loseState)
                {
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        SceneManager.LoadScene(0);
                    }
                }
                
                // Restarts the Game to the main menu
                else if (m_scene.name == "GameOver")
                {
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        SceneManager.LoadScene(0);
                    }
                }
        
                // This gives the game a "quit" button by pressing Escape
                if (Input.GetKey("escape"))
                {
                    Application.Quit();
                }
	}
}
