﻿using UnityEngine;
using System.Collections;

public enum DIRECTION { UP,RIGHT,DOWN, LEFT};
enum TURN { RIGHT, LEFT, UP, DOWN, NONE };
public class PlayerController : MonoBehaviour 
{
	private Vector3[] directions = new Vector3[4] { Vector3.up,Vector3.right,Vector3.down, Vector3.left};
	private int currentDirection = 3;
	private int nextDirection = -1;
	private Animator anim;
	public int objetiveIndex;
	public GameManager gameManager;
	public ScoreManager score;

	private bool onDecisionTile;
	private GameObject decisionTile;
	private bool onContinuosTile;
	private GameObject continuosTile;


	void Start()
	{
		this.anim = this.GetComponent<Animator> ();
	}

	void FixedUpdate()
	{
		this.ChangeDirection ();
		this.ContinueDirection ();
		this.ChangeSide ();

		this.transform.Translate (this.GetObjetive() * Time.deltaTime);

		if(Input.GetKeyDown(KeyCode.RightArrow) )
		{
			if( this.currentDirection == (int)DIRECTION.LEFT)
			{
				this.currentDirection = (int)DIRECTION.RIGHT;
			}
			if(this.onDecisionTile)
			{
				this.nextDirection = (int)DIRECTION.RIGHT;
			}
		}
		if(Input.GetKeyDown(KeyCode.LeftArrow))
		{
			if( this.currentDirection == (int)DIRECTION.RIGHT)
			{
				this.currentDirection = (int)DIRECTION.LEFT;
			}
			if(this.onDecisionTile)
			{
				this.nextDirection = (int)DIRECTION.LEFT;
			}
		}
		if(Input.GetKeyDown(KeyCode.UpArrow)  )
		{
			if( this.currentDirection == (int)DIRECTION.DOWN)
			{
				this.currentDirection = (int)DIRECTION.UP;
			}
			if(this.onDecisionTile)
			{
				this.nextDirection = (int)DIRECTION.UP;
			}
		}
		if(Input.GetKeyDown(KeyCode.DownArrow))
		{
			if( this.currentDirection == (int)DIRECTION.UP)
			{
				this.currentDirection = (int)DIRECTION.DOWN;
			}
			if(this.onDecisionTile)
			{
				this.nextDirection = (int)DIRECTION.DOWN;
			}
		}

		this.anim.SetInteger ("currentAnim", this.currentDirection);

	}

	private void ContinueDirection()
	{
		if(onContinuosTile)
		{
			if(Vector3.Distance(this.transform.position,this.continuosTile.transform.position) < 0.01f)
			{
				this.transform.position = this.continuosTile.transform.position;
				DIRECTION direction1 = continuosTile.GetComponent<ContinuosTile>().goDirection1;
				DIRECTION direction2 = continuosTile.GetComponent<ContinuosTile>().goDirection2;
				if(this.currentDirection % 2 == 0)//se a direçao for par temos que ir pra uma direçao impar!
				{
					if((int)direction1 % 2 != 0)
					{
						this.currentDirection = (int)direction1;
						return;
					}
					else if((int)direction2 % 2 != 0)
					{
						this.currentDirection = (int)direction2;
						return;
					}
				}
				else if((int)this.currentDirection % 2 != 0)//se a direçao for IMPAR temos que ir pra uma direçao PAR!
				{
					if((int)direction1 % 2 == 0)
					{
						this.currentDirection = (int)direction1;
						return;
					}
					else if((int)direction2 % 2 == 0)
					{
						this.currentDirection = (int)direction2;
						return;
					}
				}
			}
		}
	}

	private void ChangeDirection()
	{
		if(this.onDecisionTile)
		{
			if(nextDirection <= -1)
				return;

			if(this.decisionTile.GetComponent<DecisionTile>().canTurn[(int)this.nextDirection] == false)
				return;

			float centerPlayerX = this.transform.position.x + this.GetComponent<Renderer>().bounds.size.x/2;
			float centerTileX = this.decisionTile.transform.position.x + this.decisionTile.GetComponent<Renderer>().bounds.size.x/2;
			if(Vector3.Distance(this.transform.position,this.decisionTile.transform.position) < 0.035f)
			{
				this.transform.position = this.decisionTile.transform.position;
				this.currentDirection = this.nextDirection;
				onDecisionTile = false;
				this.decisionTile = null;
				this.nextDirection = -1;
			}
		}
	}

	private void ChangeSide()
	{
		if(this.transform.position.x < -4.7f)
		{
			this.transform.position = new Vector3(3.3f,transform.position.y,0);
		}
		if(this.transform.position.x > 3.3f)
		{
			this.transform.position = new Vector3(-4.7f,transform.position.y,0);
		}
	}

	Vector3 GetObjetive()
	{
			switch(this.currentDirection)
			{
				case 0:
					return Vector3.up;
				case 1:
					return Vector3.right;
				case 2:
					return Vector3.down;
				case 3:
					return Vector3.left;
			}

			return Vector3.zero;
	}

	private void SaveHighScore()
	{
		int currentHighScore = PlayerPrefs.GetInt ("HighScore");
		if(this.score.score > currentHighScore)
		{
			PlayerPrefs.SetInt("HighScore",this.score.score);
		}
	}


	void OnCollisionEnter2D(Collision2D c)
	{
		if(c.gameObject.tag.Equals(Tags.enemy))
		{
			this.SaveHighScore();
			Application.LoadLevel(Application.loadedLevel);
		}
	}

	void OnTriggerEnter2D(Collider2D c)
	{
		if (c.gameObject.tag == Tags.normalFood) 
		{
			Destroy (c.gameObject);
			this.score.AddScore();
		}

		if(c.gameObject.tag.Equals(Tags.decisionPoint))
		{
			onDecisionTile = true;
			this.decisionTile = c.gameObject;
		}
		if(c.gameObject.tag.Equals(Tags.continuosPoint))
		{
			onContinuosTile = true;
			this.continuosTile = c.gameObject;
		}
	}

	void OnTriggerExit2D(Collider2D c)
	{
		if(c.gameObject.tag.Equals(Tags.decisionPoint) && this.onDecisionTile)
		{
			onDecisionTile = false;
			this.decisionTile = null;
			this.nextDirection = -1;
		}
		if(c.gameObject.tag.Equals(Tags.continuosPoint))
		{
			onContinuosTile = false;
			this.continuosTile = null;
		}
	}

}