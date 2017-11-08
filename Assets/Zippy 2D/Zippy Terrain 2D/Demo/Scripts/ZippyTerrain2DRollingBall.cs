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
	[Tooltip("Initial force applied by all of the player's pushes, the upgrade level multiples this value")]
	[Range(5.0f, 30.0f)]
	public float initialPushForce; // the force applied when the player uses a wind push, can be increased with the upgrades
	[Tooltip("Initial amount of forward pushes, this is multiplied by upwardPushLevel in order to determine the number of pushes at the current level")]
	public int initialForwardPushes;
	[Tooltip("Initial amount of upward pushes, this is multiplied by forwardPushLevel in order to determine the number of pushes at the current level")]
	public int initialUpwardPushes;

	[Header("Upgradeable Traits")]
	[Tooltip("The number of forward pushes the player can use")]
	public int forwardPushes; //number of times the player can push the rock forward
	[Tooltip("The current upgrade level of the player's forward pushs. This is the amount the initialPushForce and initialForwardPushes is multiplied by.")]
	public int forwardPushLevel; //current upgrade level of the player's forward Pushes;
	[Tooltip("The number of upward pushes the player can use")]
	public int upwardPushes; //number of times the player can push the rock upward
	[Tooltip("The current upgrade level of the player's upward pushs. This is the amount the initialPushForce and initialUpwardPushes is multiplied by.")]
	public int upwardPushLevel; //current upgrade level of the player's upward pushes;
	//

	Rigidbody2D cacheRB;
	float input;
	bool gameOver = false;
	void Start () {
		cacheRB = GetComponent<Rigidbody2D>();
		cacheRB.AddForce(new Vector2(initialForce, 0.0f), ForceMode2D.Impulse);
		forwardPushLevel = playerStats.currentForwardPushLevel;
		upwardPushLevel = playerStats.currentUpwardPushLevel;
		forwardPushes = initialForwardPushes * forwardPushLevel;
		upwardPushes = initialUpwardPushes * upwardPushLevel;
	}

	void OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.tag == "Coin") {
			coll.gameObject.SetActive (false);
		}
		playerStats.playerMoney = playerStats.playerMoney + 5;
	}

	IEnumerator CountDown (){ //this triggers the end of the game
		yield return new WaitForSecondsRealtime (5);
		gameOver = true;
		endGameCanvas.gameObject.SetActive (true);
		inGameCanvas.gameObject.SetActive (false);
	}

	void FixedUpdate() {
		if (Input.GetKeyDown("d")) {
			if (forwardPushes != 0) {
				cacheRB.AddForce (new Vector2 (initialPushForce*forwardPushLevel, 0.0f), ForceMode2D.Impulse);
				forwardPushes--;
			}
		}
		if (Input.GetKeyDown("w")) {
			if (upwardPushes != 0) {
				cacheRB.AddForce (new Vector2 (0.0f, initialPushForce*upwardPushLevel), ForceMode2D.Impulse);
				upwardPushes--;
			}
		}
		if ((upwardPushes == 0) && (forwardPushes == 0) && (!gameOver)) { //if we are out of ways to speed up the rock and its going backwards then the game is over
			if((cacheRB.velocity.x == 0) || (cacheRB.velocity.x < Vector2.zero.x)){
				StartCoroutine ("CountDown");
			}
		}
	}
}
