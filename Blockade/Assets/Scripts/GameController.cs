using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.Networking.NetworkSystem;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	
	// This holds the tile objects that comprise the board. This baseline is preserved as the entire board resets when Someone takes damage.
	public GameObject[,] board_base = new GameObject[20,16];
	
	// This multidimensional stores the updated board that is reset with each round. 
	public GameObject[,] board = new GameObject[20,16];
	
	// This is where we will store the player objects
	public PlayerControl player_one;
	public PlayerControl player_two;

	// This code is to reference the player art assets
	public Sprite player1; 
	public Sprite player2;
	public Sprite empty;
	
	// This code is to manage the Score Text
	public Text player1score;
	public Text player2score;
	
	// Use this for initialization of the game. It sets the players scores and sets up the basic board that will be used
	void Start ()
	{
		player_one.setScore(5);  
		player_two.setScore(5);
		BuildBaseBoard();
		BuildBoard();
	}
	
	// This timer will be to fade the text out
	public float targetTime = 1.3f;
	
	// Update is called once per frame
	void Update () {
		targetTime -= Time.deltaTime;
		if (targetTime <= 0.0f)
		{
			player1score.enabled = false;
			player2score.enabled = false;
		}
	}

	// This code will populate the 20 x 16 array with the contents of the board_base array, forming the game grid
	// This code will be called at the start of the game and whenever they need to reset the game

	public void BuildBaseBoard()
	{
		int count = 1;
		
		for (int i = 0; i < 16; i++)
		{
			for (int k = 0; k < 20; k++)
			{
				GameObject g = GameObject.Find("Tile (" + count + ")");
				board_base[k, i] = g;
				count++;
			}
		}
	}
	
	public void BuildBoard()
	{
		for (int i = 0; i < 16; i++)
		{
			for (int k = 0; k < 20; k++)
			{
				board[k, i] = board_base[k, i];
	
			}
		}
		
		for (int i = 1; i < 15; i++)
		{
			for (int k = 1; k < 19; k++)
			{
				board[k, i].GetComponent<Image>().sprite = empty;
			}
		}
		
		// We then set the positions of the players
		board[5, 11].GetComponent<Image>().sprite = player1;
		board[14, 5].GetComponent<Image>().sprite = player2;
		player_one.setPosition(5, 11);
		player_two.setPosition(14, 5);
		player_one.setInput(player_one.downInput);
		player_two.setInput(player_two.upInput);
		
		// And pass them the board to do movement
		player_one.grid = this;
		player_two.grid = this;
		
		player1score.enabled = true;
		player2score.enabled = true;
		targetTime = 1.3f;
	}
	
	
	
}
