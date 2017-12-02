using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ZippyTerrain2DRollingBall : MonoBehaviour {

	//public vars

	[Header("Static/Starting Traits")]
	[Tooltip("Canvas that contains the Upgrade GUI in order to display when the game ends")]
	public Canvas endGameCanvas;
	[Tooltip("Canvas that contains UI elements visable during the game")]
	public Canvas inGameCanvas;
	[Range(2.0f, 10.0f)] // bounds the inital force for testing and tweaking between these values
	[Tooltip("Initial force applied to the rock when the game starts")]
	public float initialForce; // the initial force applied to the rock when the game starts
	//

	Rigidbody2D cacheRB;
	float input;
	bool gameOver = false;
	bool triggerUpwardPush = false;
	bool triggerForwardPush = false;
    public float timeBetweenShots = 0.01f;  // Allow 1 push/jump per second
	private int lives = playerStats.lives;
    //private float timestamp;

    void Start () {
		cacheRB = GetComponent<Rigidbody2D>();
		//initial push on the rock
		cacheRB.AddForce(new Vector2(initialForce, 0.0f), ForceMode2D.Impulse);
		this.transform.localScale = new Vector3 (playerStats.playerSize.x, playerStats.playerSize.y, playerStats.playerSize.z);
	}

	void OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.tag == "Coin") {
			coll.gameObject.SetActive (false);
		}
		playerStats.playerMoney = playerStats.playerMoney + (2 * playerStats.moneyMultiplier);
	}

	IEnumerator CountDown (){ //this triggers the end of the game
		yield return new WaitForSecondsRealtime (5);
		gameOver = true;
		endGameCanvas.gameObject.SetActive (true);
		inGameCanvas.gameObject.SetActive (false);
	}

	void Update(){
		//if(Time.time >= timestamp && (Input.GetKeyDown("d"))){
		if(Input.GetKeyDown("d")){
			triggerForwardPush = true; //Input.GetKeyDown relies on Update() so we pool the result for use when physics calcs are done in FixedUpdate, this prevents input loss
            //timestamp = Time.time + timeBetweenShots;
        }
		//if(Time.time >= timestamp && (Input.GetKeyDown("w"))){
		if(Input.GetKeyDown("w")){
			triggerUpwardPush = true;
            //timestamp = Time.time + timeBetweenShots;
        }
	}

	void FixedUpdate() {
		if (triggerForwardPush) {
			if (playerStats.currentForwardPushes != 0) {
				cacheRB.AddForce (new Vector2 (playerStats.currentForwardPushForce, 0.0f), ForceMode2D.Impulse);
				playerStats.currentForwardPushes--;
				triggerForwardPush = false;
			}
		}
		if (triggerUpwardPush) {
			if (playerStats.currentUpwardPushes != 0) {
				cacheRB.AddForce (new Vector2 (0.0f, playerStats.currentUpwardPushForce), ForceMode2D.Impulse);
				playerStats.currentUpwardPushes--;
				triggerUpwardPush = false;
			}
		}
		if ((playerStats.currentUpwardPushes == 0) && (playerStats.currentForwardPushes == 0) && (!gameOver)) { //if we are out of ways to speed up the rock and its going backwards then the game is over
			if (((cacheRB.velocity.x == 0) || (cacheRB.velocity.x < Vector2.zero.x)) && lives == 1) {
				StartCoroutine ("CountDown");
			} else if ((cacheRB.velocity.x == 0) || (cacheRB.velocity.x < Vector2.zero.x)) {
				lives--;
				playerStats.currentPlayerLives--;
				cacheRB.AddForce (new Vector2 (30.0f, 0.0f), ForceMode2D.Impulse);
			}
		}
	}
}
