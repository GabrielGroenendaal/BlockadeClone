using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour {
	
	// This code is to reference the player art assets
	public Sprite happy; public Sprite body; 
	public Sprite up; public Sprite down; public Sprite left; public Sprite right;
	public KeyCode upInput; public KeyCode downInput; public KeyCode rightInput; public KeyCode leftInput;
	public Sprite empty;
	
	// This code is for other important values, such as the player's current score and the inputs
	private int score;
	private int Xpos;
	private int Ypos;
	private KeyCode input;
	private KeyCode previousInput;
	
	// Figure out a value to give the arrowX 
	private int arrowXpos;
	private int arrowYpos;
	public Text countText;
	
	public GameController grid;
	
	public float targetTime = .5f;
 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame, and is used to keep track of shifting player inputs 
	// This code manages the storing of input values and calls upon the arrow() method to place the arrow down
	void Update () {
		
		targetTime -= Time.deltaTime;
		
		if (Input.GetKeyDown(downInput) && previousInput!=upInput)
		{
			input = downInput;
			arrow(down,Xpos,Ypos-1);
		}
		else if (Input.GetKeyDown(upInput) && previousInput!=downInput)
		{
			input = upInput;
			arrow(up,Xpos,Ypos+1);
		}
		else if (Input.GetKeyDown(rightInput) && previousInput!=leftInput)
		{
			input = rightInput;
			arrow(right,Xpos+1,Ypos);
		}
		else if (Input.GetKeyDown(leftInput) && previousInput!=rightInput)
		{
			input = leftInput;
			arrow(left,Xpos-1,Ypos);
		}
		
		// Now this code will check the inputs every second and move the pieces accordingly
		if (targetTime <= 0.0f)
		{
			targetTime = .5f;
			if (input == downInput)
			{
				if (grid.board[Xpos, Ypos - 1].GetComponent<Image>().sprite != empty && grid.board[Xpos, Ypos - 1].GetComponent<Image>().sprite != down)
				{
					score = score - 1;
					grid.BuildBoard();
				}
				else
				{
					grid.board[Xpos, Ypos - 1].GetComponent<Image>().sprite = happy;
					grid.board[Xpos, Ypos].GetComponent<Image>().sprite = body;
					arrowXpos = 0; arrowYpos = 0;
					arrow(down,Xpos,Ypos-2);
					previousInput = input;
					Ypos = Ypos - 1;
				}
			}
		
			else if (input == upInput)
			{
				if (grid.board[Xpos, Ypos + 1].GetComponent<Image>().sprite != empty && grid.board[Xpos, Ypos + 1].GetComponent<Image>().sprite != up)
				{
					score = score - 1;
					grid.BuildBoard();
				}
				else
				{
					grid.board[Xpos, Ypos + 1].GetComponent<Image>().sprite = happy;
					grid.board[Xpos, Ypos].GetComponent<Image>().sprite = body;
					arrowXpos = 0; arrowYpos = 0;
					arrow(up,Xpos,Ypos+2);
					previousInput = input;
					Ypos = Ypos + 1;
				}
			}
			
			else if (input == leftInput)
			{
				if (grid.board[Xpos - 1, Ypos].GetComponent<Image>().sprite != empty && grid.board[Xpos - 1, Ypos].GetComponent<Image>().sprite != left)
				{
					score = score - 1;
					grid.BuildBoard();
				}
				else
				{
					grid.board[Xpos - 1, Ypos].GetComponent<Image>().sprite = happy;
					grid.board[Xpos - 1, Ypos].GetComponent<Image>().sprite = body;
					arrowXpos = 0; arrowYpos = 0;
					arrow(left,Xpos-2,Ypos);
					previousInput = input;
					Xpos = Xpos - 1;
				}
			}
			
			else if (input == rightInput)
			{
				if (grid.board[Xpos + 1, Ypos].GetComponent<Image>().sprite != empty && grid.board[Xpos + 1, Ypos].GetComponent<Image>().sprite != right)
				{
					score = score - 1;
					grid.BuildBoard();
				}
				else
				{
					grid.board[Xpos + 1, Ypos].GetComponent<Image>().sprite = happy;
					grid.board[Xpos, Ypos].GetComponent<Image>().sprite = body;
					arrowXpos = 0; arrowYpos = 0;
					arrow(right,Xpos+2,Ypos);
					previousInput = input;
					Xpos = Xpos + 1;
				}
			}
			setCountText(); // updates the count text.
			}
	}
	
	
	// This code determines where the arrow tokens are placed, only on empty tiles, while storing the position the previous arrow location to clear it
	void arrow(Sprite d, int x, int y)
	{
		if (arrowXpos != 0)
		{
			grid.board[arrowXpos, arrowYpos].GetComponent<Image>().sprite = empty;
		}
		
		if (grid.board[x, y].GetComponent<Image>().sprite == empty || grid.board[x, y].GetComponent<Image>().sprite == d)
		{
			grid.board[x, y].GetComponent<Image>().sprite = d;
			arrowXpos = x;
			arrowYpos = y;
		}
	}
	
	// Simple code to set the position of the Player
	public void setPosition(int x, int y)
	{
		Xpos = x;
		Ypos = y;
	}
	
	void setCountText()
	{
		countText.text = score.ToString();
	}

	public void setScore(int j)
	{
		score = j;
	}

	public void setInput(KeyCode k)
	{
		previousInput = k;
		input = k;

		if (k == upInput)
		{
			arrow(up, Xpos, Ypos + 1);
		}

		if (k == downInput) {
			arrow(down, Xpos, Ypos-1);
		}
}	

	public int getScore()
	{
		return score;
	}
}
