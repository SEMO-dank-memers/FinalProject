using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class RollingBall : MonoBehaviour
{
	//public vars
	[Header("Static/Starting Traits")]
	[Tooltip("Canvas that contains the Upgrade GUI in order to display when the game ends")]
	public Canvas endGameCanvas; //allows the editor to hand the script the upgrade GUI so we can activate it only when the game has ended [the ball starts rolling backwards with no way to recover]
	[Tooltip("Canvas that contains UI elements visable during the game")]
	public Canvas inGameCanvas; //allows the editor to hand the script the canvas that contains all the inGame GUI elements for update purposes
	[Tooltip("Sound played when hitting an enemy")]
	public AudioClip Explosion; //sound to play when hitting an enemy
	[Tooltip("Sound played when hitting a coin")]
	public AudioClip Ping; // sound to play when hitting a coin
	[Tooltip("Sound effects played randomly when hitting a enemy")]
	public AudioClip[] hits = new AudioClip[5]; //randomly selects an audio to play on hit
	[Tooltip("Sound effect played when using a force push")]
	public AudioClip pushWind;
	//

	//private vars
	private Rigidbody2D cacheRB; //the rigidbody of the rock for physics calculations
	bool gameOver = false; //has the ball started rolling backwards with no way to recover?
	bool triggerUpwardPush = false; //has the player triggered an upward push in the current frame?
	bool triggerForwardPush = false; //has the player triggered a forward push in the current frame?
	private float initialForce; // the initial force applied to the rock when the game starts
	private int lives = playerStats.lives; //how many "lives" does the player have left, using a life will throw the rock forward when otherwise the game would have ended
	//

    void Start ()
	{
		initialForce = playerStats.initialForce; //how much force do we use depending on the players upgrade level
		cacheRB = GetComponent<Rigidbody2D>(); //assignment to rock's rigidbody
		cacheRB.AddForce(new Vector2(initialForce, 0.0f), ForceMode2D.Impulse);//initial push on the rock
		this.transform.localScale = new Vector3 (playerStats.playerSize.x, playerStats.playerSize.y, playerStats.playerSize.z); //change the rock's size depending on the players upgrade level
	}

    void OnTriggerEnter2D(Collider2D coll)
	{
		AudioSource source = GetComponent<AudioSource> ();
		if (coll.gameObject.tag == "Coin") { // when the rock hits a coin
			coll.gameObject.SetActive (false);
			source.PlayOneShot (Ping);
			playerStats.playerMoney = playerStats.playerMoney + (2 * playerStats.moneyMultiplier); //increase the players money in playerStats so that it can be accessed throughout the game
		} else if (coll.transform.gameObject.tag == "Enemy") { //when the rock hits an enemy
			source.PlayOneShot (hits [Random.Range(0,4)]);
		}
}

	IEnumerator CountDown ()
	{
		//called to start the end of the game, when the rock is rolling backwards without any way of saving itself
		yield return new WaitForSecondsRealtime(3);
		gameOver = true;
		endGameCanvas.gameObject.SetActive(true); // turn on the upgrade ui
		inGameCanvas.gameObject.SetActive(false); //turn off in game elements
	}

	void Update()
	{
		if(Input.GetKeyDown("d")) {
			triggerForwardPush = true; //Input.GetKeyDown relies on Update() so we pool the result for use when physics calcs are done in FixedUpdate, this prevents input loss
        }

		if(Input.GetKeyDown("w")) {
			triggerUpwardPush = true;
        }
	}

	void FixedUpdate()
	{
		if (triggerForwardPush) { //if we triggered a forward push in this frame go ahead and apply the force and remove one forward push from our currentForwardPushes
			if (playerStats.currentForwardPushes != 0) {
				cacheRB.AddForce (new Vector2 (playerStats.currentForwardPushForce, 0.0f), ForceMode2D.Impulse);
				playerStats.currentForwardPushes--;
				triggerForwardPush = false;
				GetComponent<AudioSource>().PlayOneShot(pushWind);
			}
		}

		if (triggerUpwardPush) {
			if (playerStats.currentUpwardPushes != 0) {
				cacheRB.AddForce (new Vector2 (0.0f, playerStats.currentUpwardPushForce), ForceMode2D.Impulse);
				playerStats.currentUpwardPushes--;
				triggerUpwardPush = false;
				GetComponent<AudioSource>().PlayOneShot(pushWind);
			}
		}

		if ((playerStats.currentUpwardPushes == 0) && (playerStats.currentForwardPushes == 0) && (!gameOver)) { //if we are out of ways to speed up the rock and its going backwards then the game is over
			AudioSource source = GetComponent<AudioSource> ();
			if (((cacheRB.velocity.x == 0) || (cacheRB.velocity.x < Vector2.zero.x)) && lives == 1) {
				StartCoroutine ("CountDown");
			} else if ((cacheRB.velocity.x == 0) || (cacheRB.velocity.x < Vector2.zero.x)) {//if the ball is rolling backwards with no way to save itself but we have a life then use up one live and throw the rock forward
				lives--;
				playerStats.currentPlayerLives--;
				cacheRB.AddForce (new Vector2 (30.0f, 0.0f), ForceMode2D.Impulse);
			}
		}
	}
}
