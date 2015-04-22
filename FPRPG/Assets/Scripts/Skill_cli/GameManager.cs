using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameManager : MonoBehaviour 
{
	public delegate void EnemyEventHandler();
	public static event EnemyEventHandler onEnemyAttacked;

	// Use this for initialization
	void Start () 
	{
		Debug.Log ("GameManager Start");
	}
	
	// Update is called once per frame
	void Update () 
	{
		#region SFX text with key input.
		/*bool bJump = Input.GetButtonDown("Jump");

		if (bJump == true)
		{
			Debug.Log ("Jump Clicked");
			if (onEnemyAttacked != null)
			{
				Debug.Log ("onEnemyAttacked call");
				onEnemyAttacked();
			}
		}*/
		#endregion
	}		

	void OnGUI()
	{
		#region SFX test with button input.
		if (ShowButton (new Rect(0, 0, 100, 100), "SFX"))
		{
			//infoText.text = "Button Clicked";

			if (onEnemyAttacked != null)
			{
				Debug.Log ("onEnemyAttacked call");
				onEnemyAttacked();
			}
		}
		#endregion
	}

	public bool ShowButton(Rect rect, string text)
	{
		GUI.SetNextControlName(text);
		return GUI.Button (rect, text);
	}
}