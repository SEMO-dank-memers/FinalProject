using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdBehaviour : MonoBehaviour {
	
	GameObject rock;
	StateMachine.Enemy.Role role = StateMachine.Enemy.Role.BIRD;
	StateMachine.Enemy.State state = StateMachine.Enemy.State.FLY;
	
	// Use this for initialization
	void Start(){
		rock = GameObject.FindGameObjectWithTag("Rock");
		//this.GetComponent<SpriteRenderer>().sprite = this.GetComponent<StateMachine.Enemy>().GenerateSprite(role); //sets the sprite according to the role
	}

	// Update is called once per frame, LateUpdate performs calculations before running the commands
	void LateUpdate(){
		//run change state logic
		//set behaviour according to the state
		if(state == StateMachine.Enemy.State.FLY)
		{
			
		}
		else if(state == StateMachine.Enemy.State.CHARGE)
		{
			
		}
	}
	void Fly(){
		if (rock.transform.position.x > (this.transform.position.x + 200.0f)) //if rock is 200 units to the right of this gameobject
			Destroy(this); //commit harakiri
		//just moves to the left in a straight line
		Vector2 goal = new Vector2(this.transform.position.x - 1.0f, this.transform.position.y);
		float speed = 0.5f;
		this.transform.Translate(goal.normalized * speed * Time.deltaTime);
	}
	void Charge(){
		//bird charges towards the rock
		Vector2 goal = new Vector2(rock.transform.position.x, rock.transform.position.y);
		float speed = 1.5f;
		this.transform.Translate(goal.normalized * speed * Time.deltaTime);
	}
}

