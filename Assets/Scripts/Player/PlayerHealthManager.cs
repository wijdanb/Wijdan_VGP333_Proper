using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerHealthManager : MonoBehaviour {


	public int startingHealth;
	public int currentHealth;

	public Slider healthSlider;
	public Image damageImage;
	//public AudioClip deathClip;

	public float flashSpeed = 5f;
	public Color flashColour = new Color(1f,0f,0f,0.1f);
	public float flashLength;
	private float flashCounter;

	private bool damaged;
	private bool isDead = false;

	private Renderer rend;
	private Color storedColor;

	// Use this for initialization
	void Start () {
		damaged = false;
		currentHealth = startingHealth;
		rend = GetComponent<Renderer> ();
		storedColor = rend.material.GetColor ("_Color");//this will get the color variable on the material->in inspector its the color next to the albedo

	}
	
	// Update is called once per frame
	void Update () {
		if (currentHealth <= 0) {
			gameObject.SetActive (false);
			Death ();
		}

		if (flashCounter > 0) 
		{
			flashCounter -= Time.deltaTime;
			if (flashCounter <= 0) 
			{
				rend.material.SetColor ("_Color", storedColor);
				damaged = false;

			}
		}

		damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
	}

	public void HurtPlayer(int damageAmount)
	{
		damaged = true;
		currentHealth -= damageAmount;
		healthSlider.value = currentHealth;
		flashCounter = flashLength;
		rend.material.SetColor ("_Color", Color.white);
		damageImage.color = flashColour;

	}

	public void Death()
	{
		isDead = true;
		SceneManager.LoadScene (1);
		

	}
}
