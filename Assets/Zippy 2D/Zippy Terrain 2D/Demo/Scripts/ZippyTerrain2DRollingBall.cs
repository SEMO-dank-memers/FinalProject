using UnityEngine;
using System.Collections;
public class ZippyTerrain2DRollingBall : MonoBehaviour {

	//public vars
	[Header("Static/Starting Traits")]
	[Range(2.0f, 10.0f)] // bounds the inital force for testing and tweaking between these values
	[Tooltip("Initial force applied to the rock when the game starts")]
	public float initialForce=5.0f; // the initial force applied to the rock when the game starts
	[Tooltip("Initial force applied by all of the player's pushes, the upgrade level multiples this value")]
	[Range(5.0f, 30.0f)]
	public float initialPushForce=5.0f; // the force applied when the player uses a wind push, can be increased with the upgrades
	[Tooltip("The current money of the player")]
	public int playerMoney; //game money, making public so that other events can increase it
	[Header("Upgradeable Traits")]
	[Tooltip("The number of forward pushes the player can use")]
	public int forwardPushes = 3; //number of times the player can push the rock forward
	[Tooltip("The current upgrade level of the player's forward pushs. This is the amount the initialForwardForce is multiplied by.")]
	public int forwardPushLevel = 1; //current upgrade level of the player's forward Pushes;
	[Tooltip("The number of upward pushes the player can use")]
	public int upwardPushes = 3; //number of times the player can push the rock upward
	[Tooltip("The current upgrade level of the player's upward pushs. This is the amount the initialForwardForce is multiplied by.")]
	public int upwardPushLevel = 1; //current upgrade level of the player's upward pushes;
	//

	Rigidbody2D cacheRB;
	float input;
	void Start () {
		cacheRB = GetComponent<Rigidbody2D>();
		cacheRB.AddForce(new Vector2(initialForce, 0.0f), ForceMode2D.Impulse);
	}

	void OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.tag == "Coin") {
			coll.gameObject.SetActive (false);
		}
		playerMoney = playerMoney + 5;
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
	}
}
