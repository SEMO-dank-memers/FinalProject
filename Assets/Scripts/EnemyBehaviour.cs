using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {

	//public GameObject enemy;
    public GameObject rock;
	StateMachine.Enemy foolToBeWrecked;
	StateMachine.Enemy.Role role;

	// Use this for initialization
	void Start () {
        foolToBeWrecked = this.GetComponent<StateMachine.Enemy>().GenerateEnemy(); //sets role and bravery
        role = this.GetComponent<StateMachine.Enemy>().role; //grabs the role
        this.GetComponent<SpriteRenderer>().sprite = this.GetComponent<StateMachine.Enemy>().GenerateSprite(role); //sets the sprite according to the role
    }

    // Update is called once per frame, LateUpdate performs calculations before running the commands
    void LateUpdate () {
	//run change state logic
    //set behaviour according to the state
	/*
	this.transform.LookAt(goal.position);
	Vector3 direction = goal.position - this.transform.position;
	if(direction.magnitude > accuracy) this.transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
	*/
    }

    void Idle()
    {
		/* just stands still and detects if a rock is nearby
         * if the rock is very far away, as in this enemy is now far off screen...
         * we should call a destructor to get rid of this ai so we're not taking up excess resources
         */
		if (rock.transform.position.x > (this.transform.position.x + 200.0f)) //if rock is 200 units to the right of this gameobject
			Destroy(this); //commit harakiri
		else if(role == StateMachine.Enemy.Role.NINJA){
			if(rock.transform.position.x < this.transform.position.x){
				if (foolToBeWrecked.isBrave >= foolToBeWrecked.isAfraid){
					if (rock.transform.position.y > (this.transform.position.y + 5.0f)){
						foolToBeWrecked.currentState = StateMachine.Enemy.State.CROUCH;
					}
					else if (rock.transform.position.y <= (this.transform.position.y + 5.0f)){
						foolToBeWrecked.currentState = StateMachine.Enemy.State.JUMP;
					}
				}
				else foolToBeWrecked.currentState = StateMachine.Enemy.State.PANIC;
			}
		}
    }
    void Attack()
    {
		//gets the position of the rock and moves towards it. 
		//when at a close distance, throw a punch.
		Vector2 goal = new Vector2(rock.transform.position.x, this.transform.position.y);
		float speed = 1.0f;
		this.transform.Translate(goal.normalized * speed * Time.deltaTime);
	}
    void Punch()
    {
        //uses a punching animation, and reduces momentum more significantly than a throw if it hits.

    }
    void Run()
    {
		/* gets position of the rock and moves away from it, might need to be careful to not
         * let them move into the air. They need to stay on the ground/
         * maybe have different speeds depending on the role
         */
		Vector2 goal = new Vector2(rock.transform.position.x + 10.0f, this.transform.position.y);
		float speed = 1.0f;
		this.transform.Translate(goal.normalized * speed * Time.deltaTime);
	}
    void Throw()
    {
        //gets current position of the rock and throws a pebble in that direction
        //pebbles reduce momentum by a small amount
    }
    void Jump()
    {
		//needs to move up and fall back down, should have gravity applied
		this.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/GoblinNinja_8");
	}
    void Crouch()
    {
		//changes to a crouching sprite, which gives it a smaller hitbox
		this.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/GoblinNinja_5");
	}
    void Panic()
    {
        //changes sprite to a panicking sprite, and just stands still
    }
    void Fly()
    {
		//just moves to the left in a straight line
		Vector2 goal = new Vector2(this.transform.position.x - 1.0f , this.transform.position.y);
		float speed = 1.0f;
		this.transform.Translate(goal.normalized * speed * Time.deltaTime);
	}
    void Charge()
    {
		//bird charges towards the rock
		Vector2 goal = new Vector2(rock.transform.position.x, rock.transform.position.y);
		float speed = 1.5f;
		this.transform.Translate(goal.normalized * speed * Time.deltaTime);
	}
}
