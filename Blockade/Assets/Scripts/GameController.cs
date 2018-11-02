using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	
	// This holds the tile objects that comprise the board. This baseline is preserved as the entire board resets when Someone takes damage.
	public GameObject[] board_base = new GameObject[320];
	
	// This multidimensional stores the updated board that is reset with each round. 
	public GameObject[,] board = new GameObject[20,16];
	
	// This is where we will store the player objects
	public PlayerControl player_one;
	public PlayerControl player_two;

	// This code is to reference the player art assets
	public Sprite player1; 
	public Sprite player2;
	
	
	// Use this for initialization of the game. It sets the players scores and sets up the basic board that will be used
	void Start ()
	{
		player_one.setScore(5);  
		player_two.setScore(5);  
		BuildBasicBoard();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// This code will populate the 20 x 16 array with the contents of the board_base array, forming the game grid
	// This code will be called at the start of the game and whenever they need to reset the game
	
	public void BuildBasicBoard()
	{
		// This code will store a counter for iterating through the array board_base
		int count = 0;
		
		for (int i = 0; i < 16; i++)
		{
			for (int k = 0; k < 20; k++)
			{
				board[k, i] = board_base[count];
			}
		}
		
		// We then set the positions of the players
		board[5, 11].GetComponent<Image>().sprite = player1;
		board[16, 5].GetComponent<Image>().sprite = player2;
		player_one.setPosition(5, 11);
		player_two.setPosition(16, 5);
		
		// And pass them the board to do movement
		player_one.grid = this;
		player_two.grid = this;
	}
	
	
	
}
