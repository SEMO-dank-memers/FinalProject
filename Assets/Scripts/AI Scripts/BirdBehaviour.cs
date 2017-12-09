using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdBehaviour : MonoBehaviour {
	
	GameObject rock;
	StateMachine.Enemy.Role role = StateMachine.Enemy.Role.BIRD;
	StateMachine.Enemy.State state = StateMachine.Enemy.State.FLY;
	private float speed = 1.5f;
	Rigidbody2D rb;
	// Use this for initialization
	void Start(){
		rb = GetComponent<Rigidbody2D>();
		rock = GameObject.FindGameObjectWithTag("Rock");
		//this.GetComponent<SpriteRenderer>().sprite = this.GetComponent<StateMachine.Enemy>().GenerateSprite(role); //sets the sprite according to the role
	}

	// Update is called once per frame, LateUpdate performs calculations before running the commands
	void LateUpdate(){
		//run change state logic
		//set behaviour according to the state
		if(state == StateMachine.Enemy.State.FLY) Fly();
		else if(state == StateMachine.Enemy.State.CHARGE) Charge();
	}
	void Fly(){
		//if (rock.transform.position.x > (this.transform.position.x + 200.0f)) //if rock is 200 units to the right of this gameobject
			//Destroy(this); //commit harakiri
		//just moves to the left in a straight line
		speed = 1.5f;
		rb.velocity = new Vector2 (-speed, rb.velocity.y);
	}
	void Charge(){
		//bird charges towards the rock
		speed = 3.5f;
		transform.position = Vector2.MoveTowards(transform.position, rock.transform.position, speed*Time.deltaTime);
	}
}

