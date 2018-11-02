using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour {
	
	// This code is to reference the player art assets
	public Sprite happy; public Sprite body; public Sprite angry;  
	public Sprite up; public Sprite down; public Sprite left; public Sprite right;
	
	// This code is for other important values, such as the player's current score and the inputs
	public int score;
	public int Xpos;
	public int Ypos;
	private String input;
	private String previousInput;
	public Text countText;

	public GameController grid;
	
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void move()
	{
		
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
	
	
}
