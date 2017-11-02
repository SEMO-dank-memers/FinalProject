using UnityEngine;
using System.Collections;
public class ZippyTerrain2DRollingBall : MonoBehaviour {
	[Range(2.0f, 10.0f)] // bounds the inital force for testing and tweaking between these values
	[Tooltip("Initial force applied to the rock when the game starts")]
	public float initialForce=5.0f; // the initial force applied to the rock when the game starts
	[Tooltip("Force applied by the player's pushes")]
	public float fowardForce=5.0f; // the force applied when the player uses a wind push, can be increased with the upgrades
	[Tooltip("The number of forward pushes the player can use")]
	public int numberOfForwardPushes = 3; //number of times the player can push the rock forward
	[Tooltip("The current money of the player")]
	public int playerMoney; //game money, making public so that other events can increase it
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
			if (numberOfForwardPushes != 0) {
				cacheRB.AddForce (new Vector2 (fowardForce, 0.0f), ForceMode2D.Impulse);
				numberOfForwardPushes--;
			}
		}
	}
}
