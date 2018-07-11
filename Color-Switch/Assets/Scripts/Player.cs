using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	public float jumpForce = 10f;
	public Rigidbody2D rb;
	public string currentColor;

	int randomInt;
	int score = 0;

	public SpriteRenderer sr;

	public Color colorCyan;
	public Color colorYellow;
	public Color colorPink;
	public Color colorMagenta;
	public Text scoreText;
	public AudioSource jump;

	public GameObject[] spawnees;
	public GameObject cam;
	public Transform player;
	public GameObject colorchanger;

	void Start()
	{
		SetRandomColor();
		player = GameObject.Find("Player").transform;
		jump = GetComponent<AudioSource>();
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0) || Input.GetButtonDown("Jump"))
		{
			rb.velocity = Vector2.up * jumpForce;
			jump.Play();
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == "ColorChanger")
		{
			scoreText.text = "Score: " + score.ToString();
			score++;
			SetRandomColor();
			Generate(col);
			return;
		}

		if (col.tag != currentColor)
		{
			Debug.Log("GAME OVER!");
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
	}

	void SetRandomColor()
	{
		int index = Random.Range(0, 4); // As Array starts from 0 and used () interval...

		switch (index)
		{
			case 0: 
				currentColor = "Cyan";
				sr.color = colorCyan;
				break;

			case 1:
				currentColor = "Yellow";
				sr.color = colorYellow;
				break;

			case 2:
				currentColor = "Magenta";
				sr.color = colorMagenta;
				break;

			case 3:
				currentColor = "Pink";
				sr.color = colorPink;
				break;
		}
	}


	public void Generate(Collider2D col)
	{
		randomInt = Random.Range(0, spawnees.Length-1);
		Vector3 position = new Vector3(0, 0, 0);
		if (randomInt == 7)
		{
			 position = new Vector3(player.position.x - 1f, player.position.y + 8f, 0);
		}
		else 
		{
			 position = new Vector3(0f, player.position.y + 8f, 0);
		}
		Instantiate(spawnees[randomInt], position, Quaternion.identity);
	    col.transform.position = new Vector3(0f, position.y + 5f, 0);
	}
}
