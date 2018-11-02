using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	
	// This code holds the board. The board is first
	public GameObject[] board_base = new GameObject[320];
	public GameObject[,] board = new GameObject[20,16];
	
	
	// This code keeps track of each players "score" or health. When they reach 0 health, they die
	private int Player1Score;
	private int Player2Score;
	
	
	// This is where we will store the player objects
	public PlayerControl player_one;
	public PlayerControl player_two;

	// This code is to reference the player art assets
	public Sprite player1; public Sprite player1Body; public Sprite player1Angry; public 
	Sprite player2; public Sprite player2Body; public Sprite player2Angry;
	public Sprite p1Up; public Sprite p1Down; public Sprite p1Left; public Sprite p1Right;
	public Sprite p2Up; public Sprite p2Down; public Sprite p2Left; public Sprite p2Right;
	
	
	// Use this for initialization of the game. It sets the players scores and sets up the basic board that will be used
	void Start ()
	{
		player_one.score  = 5;
		player_two.score  = 5;
		BuildBasicBoard();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// This code will populate the 20 x 16 array with the contents of the board_base array, forming the game grid
	// This code will be called at the start of the game and whenever they need to reset the game
	
	void BuildBasicBoard()
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
		board[11, 5].GetComponent<Image>().sprite = player2;
		player_one.setPosition(5, 11);
		player_two.setPosition(11, 5);
		
		// And pass them the board to do movement
		player_one.grid = this;
		player_two.grid = this;
	}
	
	
	
}
