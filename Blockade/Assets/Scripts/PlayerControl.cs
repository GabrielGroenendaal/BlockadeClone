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
	
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame, and is used to keep track of shifting player inputs 
	// This code manages the storing of input values and calls upon the arrow() method to place the arrow down
	void Update () {
		
		if (Input.GetKeyDown(downInput) && previousInput!=downInput)
		{
			input = downInput;
			arrow(down,Xpos,Ypos-1);
		}
		else if (Input.GetKeyDown(upInput) && previousInput!=upInput)
		{
			input = upInput;
			arrow(up,Xpos,Ypos+1);
		}
		else if (Input.GetKeyDown(rightInput) && previousInput!=rightInput)
		{
			input = rightInput;
			arrow(right,Xpos+1,Ypos);
		}
		else if (Input.GetKeyDown(leftInput) && previousInput!=leftInput)
		{
			input = leftInput;
			arrow(left,Xpos-1,Ypos);
		}
	}
	
	
	// FixedUpdate will manage the 1 second changes in position.
	void FixedUpdate()
	{
		if (input == downInput)
		{
			if (grid.board[Xpos, Ypos - 1].GetComponent<Image>().sprite != empty && grid.board[Xpos, Ypos - 1].GetComponent<Image>().sprite != down)
			{
				score--;
				// Reset the arrowXpos arrowXpos = null;
				// Reset the arrowYpos arrowYpos = null;
				previousInput = input;
				grid.BuildBasicBoard();
			}
			else
			{
				grid.board[Xpos, Ypos - 1].GetComponent<Image>().sprite = happy;
				grid.board[Xpos, Ypos].GetComponent<Image>().sprite = body;
				Ypos--;
			}
		}
		
		else if (input == upInput)
		{
			if (grid.board[Xpos, Ypos + 1].GetComponent<Image>().sprite != empty && grid.board[Xpos, Ypos + 1].GetComponent<Image>().sprite != up)
			{
				score--;
				// Reset the arrowXpos arrowXpos = null;
				// Reset the arrowYpos arrowYpos = null;
				previousInput = input;
				grid.BuildBasicBoard();
			}
			else
			{
				grid.board[Xpos, Ypos + 1].GetComponent<Image>().sprite = happy;
				grid.board[Xpos, Ypos].GetComponent<Image>().sprite = body;
				Ypos++;
			}
		}
		
		else if (input == leftInput)
		{
			if (grid.board[Xpos - 1, Ypos].GetComponent<Image>().sprite != empty && grid.board[Xpos - 1, Ypos].GetComponent<Image>().sprite != left)
			{
				score--;
				// Reset the arrowXpos arrowXpos = null;
				// Reset the arrowYpos arrowYpos = null;
				previousInput = input;
				grid.BuildBasicBoard();
			}
			else
			{
				grid.board[Xpos - 1, Ypos].GetComponent<Image>().sprite = happy;
				grid.board[Xpos - 1, Ypos].GetComponent<Image>().sprite = body;
				Xpos--;
			}
		}
		
		else if (input == rightInput)
		{
			if (grid.board[Xpos + 1, Ypos].GetComponent<Image>().sprite != empty && grid.board[Xpos + 1, Ypos].GetComponent<Image>().sprite != right)
			{
				score--;
				// Reset the arrowXpos arrowXpos = null;
				// Reset the arrowYpos arrowYpos = null;
				previousInput = input;
				grid.BuildBasicBoard();
			}
			else
			{
				grid.board[Xpos + 1, Ypos].GetComponent<Image>().sprite = happy;
				grid.board[Xpos, Ypos].GetComponent<Image>().sprite = body;
				Xpos++;
			}
		}
		setCountText(); // updates the count text.
	}
	
	// This code determines where the arrow tokens are placed, only on empty tiles, while storing the position the previous arrow location to clear it
	void arrow(Sprite d, int x, int y)
	{
		if (arrowXpos != null)
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

	public int getScore()
	{
		return score;
	}
}
