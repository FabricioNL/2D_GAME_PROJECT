using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

	public int maxHealth = 100;
	public int currentHealth;

	public float KnockbackForce = 40f;

	private bool isDead = false;

	public HealthBar healthBar;

	private bool isKnockedBack = false;

	public Animator animator;

	public GameObject inventarioBox;
	public GameObject menuBox;
	public GameObject deathBox;

	public  GameObject flautaItem;
    public  GameObject bomboItem;
    public  GameObject pianoItem;
    public  GameObject violonceloItem;
	public  AudioClip finalSong; // o áudio a ser tocado 
	public AudioSource audioSource;

	public GameObject WinBox;

    // Start is called before the first frame update
    void Start()
    {
		if (PlayerPrefs.HasKey("currentHealth")){
            currentHealth = PlayerPrefs.GetInt("currentHealth");
        }
        else {
            currentHealth = maxHealth;
        }
		healthBar.SetMaxHealth(maxHealth);
		healthBar.SetHealth(currentHealth);


		if (PlayerPrefs.HasKey("flautaItem")){
            flautaItem.SetActive(true);
        }

		if (PlayerPrefs.HasKey("pianoItem")){
            pianoItem.SetActive(true);
        }

		if (PlayerPrefs.HasKey("bomboItem")){
            bomboItem.SetActive(true);
        }

		if (PlayerPrefs.HasKey("violonceloItem")){
            violonceloItem.SetActive(true);
        }
		audioSource = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
		if (isKnockedBack) {
			animator.SetBool("IsKnockedBack", true);
		} else {
			animator.SetBool("IsKnockedBack", false);
		}
		

		if (Input.GetKeyDown(KeyCode.Q))
        {
            if (inventarioBox.activeInHierarchy)
            {
                inventarioBox.SetActive(false);
            }
            else
            {
                inventarioBox.SetActive(true);
            }
        }


		//se apertar ESC abre o menu
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (menuBox.activeInHierarchy)
			{
				menuBox.SetActive(false);
			}
			else
			{
				menuBox.SetActive(true);
			}
		}

		if (currentHealth <= 0) {
			if (!deathBox.activeInHierarchy){
				deathBox.SetActive(true);
				if (!isDead){
					isDead = true;
					//animator.SetBool("IsDead", true);
					animator.enabled = false;
					gameObject.SetActive(false);
				}
			}
		}

		if (PlayerNotes.bomboState && PlayerNotes.flautaState && PlayerNotes.pianoState && PlayerNotes.violonceloState) {

			WinBox.SetActive(true);
			animator.enabled = false;
			GetComponent<Collider2D>().enabled = false;
			audioSource.PlayOneShot(finalSong);
			Invoke("LoadSceneAfterMusic", finalSong.length);
		}
    }

	public void TakeDamage(int damage, Vector2 knockbackDirection) {
		currentHealth -= damage;
		healthBar.SetHealth(currentHealth);

		GetComponent<Rigidbody2D>().AddForce(knockbackDirection * KnockbackForce, ForceMode2D.Impulse);

		isKnockedBack = true;
		Invoke("EndKnockback", 0.5f);
	}
	

	void EndKnockback() {
    	isKnockedBack = false;
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag("Enemy")) {
			
			Vector2 knockbackDirection = (transform.position - other.transform.position).normalized;
        	TakeDamage(20, knockbackDirection);
		}

		if (other.CompareTag("bombo")) {
			
			other.gameObject.SetActive(false);
			bomboItem.SetActive(true);
			PlayerPrefs.SetInt("bomboItem",1);
			PlayerNotes.allowBombo();
		}

		if (other.CompareTag("piano")) {
			
			other.gameObject.SetActive(false);
		    pianoItem.SetActive(true);
			PlayerPrefs.SetInt("pianoItem",1);
			PlayerNotes.allowPiano();
		}

		if (other.CompareTag("flauta")) {
			
			other.gameObject.SetActive(false);
			flautaItem.SetActive(true);
			PlayerPrefs.SetInt("flautaItem",1);
			PlayerNotes.allowFlauta();
		}

		if (other.CompareTag("violoncelo")) {
			
			other.gameObject.SetActive(false);
			PlayerNotes.allowVioloncelo();
			PlayerPrefs.SetInt("violonceloItem",1);
			violonceloItem.SetActive(true);
		}
	}

	private void OnDestroy() {
		SavingStates.SaveHealthBarPercentage(currentHealth);
	}

	public void LoadSceneAfterMusic()
{
    SceneManager.LoadScene("Main Menu");
} 
	
}