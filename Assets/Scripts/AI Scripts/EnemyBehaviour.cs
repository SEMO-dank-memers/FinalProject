using System.IO;
using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour
{
	//public GameObject enemy;
    public GameObject rock;
	private Rigidbody2D rb;
	public Transform goblin;
	private StateMachine.Enemy logic;
	public Sprite crouch;
	public Sprite panic;
	public Sprite punch;
	public Sprite ninja;
	public Sprite jump;
	public Sprite run;
	public string role;
	private float speed = 5.0f;
	private float jumpHeight = 2.0f;

	//initializer
	void Start()
	{
		logic = new StateMachine.Enemy();
		rb = GetComponent<Rigidbody2D>();
		logic.normal = this.GetComponent<SpriteRenderer>().sprite;

		if (role == "unassigned")
			logic.role = StateMachine.Enemy.Role.UNASSIGNED;
		else if (role == "thrower")
			logic.role = StateMachine.Enemy.Role.THROWER;
		else if (role == "troll")
			logic.role = StateMachine.Enemy.Role.TROLL;
		else if (role == "ninja")
			logic.role = StateMachine.Enemy.Role.NINJA;
		else if (role == "brawler")
			logic.role = StateMachine.Enemy.Role.BRAWLER;

		logic.GenerateEnemy();
	}

	bool jumpCall = true; //setter to make sure the jump eventually stops

    //Update is called once per frame, LateUpdate performs calculations before running the commands
    void LateUpdate () {
		//run change state logic
    	//set behaviour according to the state
		if (logic.role == StateMachine.Enemy.Role.NINJA) {
			if (this.transform.position.x - rock.transform.position.x < 4 && this.transform.position.x - rock.transform.position.x > -10) {
				if (logic.isBrave >= logic.isAfraid) {
					if (((rock.transform.position.y) > (this.transform.position.y + 1)) && ((rock.transform.position.x) <= (this.transform.position.x))) {
						logic.currentState = StateMachine.Enemy.State.CROUCH;
						jumpCall = true; //prepare to jump again
					} else {
						logic.currentState = StateMachine.Enemy.State.JUMP;
					}
				} else {
					logic.currentState = StateMachine.Enemy.State.PANIC;
				}
			} else {
				jumpCall = true; //out of range, reset jump
			}
		} else if(logic.role == StateMachine.Enemy.Role.TROLL) {
			
		} else if(logic.role == StateMachine.Enemy.Role.BRAWLER) {
			
		} else if(logic.role == StateMachine.Enemy.Role.THROWER) {
			
		}

		if (this.transform.position.x - rock.transform.position.x < 4 && this.transform.position.x - rock.transform.position.x > -10) {
			DoAction();
		}
    }

	void DoAction()
	{
		setSprite();
		if (logic.currentState == StateMachine.Enemy.State.PANIC) {
			Panic();
		} else if (logic.currentState == StateMachine.Enemy.State.IDLE) {
			Idle();
		} else if (logic.currentState == StateMachine.Enemy.State.CROUCH) {
			Crouch();
		} else if (logic.currentState == StateMachine.Enemy.State.JUMP) {
			Jump();
		} else if (logic.currentState == StateMachine.Enemy.State.ATTACK) {
			
		} else if (logic.currentState == StateMachine.Enemy.State.PUNCH) {
			
		} else if (logic.currentState == StateMachine.Enemy.State.RUN) {
			
		} else if (logic.currentState == StateMachine.Enemy.State.THROW) {
			
		}
	}

	void setSprite()
	{
		if (logic.currentState == StateMachine.Enemy.State.PANIC) {
			this.GetComponent<SpriteRenderer>().sprite = panic;
		} else if (logic.currentState == StateMachine.Enemy.State.IDLE) {
			this.GetComponent<SpriteRenderer>().sprite = logic.normal;
		} else if (logic.currentState == StateMachine.Enemy.State.CROUCH) {
			this.GetComponent<SpriteRenderer>().sprite = crouch;
		} else if (logic.currentState == StateMachine.Enemy.State.JUMP) {
			//set this in the fucntion itself
		} else if (logic.currentState == StateMachine.Enemy.State.ATTACK) {

		} else if (logic.currentState == StateMachine.Enemy.State.PUNCH) {
			this.GetComponent<SpriteRenderer>().sprite = punch;
		} else if (logic.currentState == StateMachine.Enemy.State.RUN) {
			this.GetComponent<SpriteRenderer>().sprite = panic;
		} else if (logic.currentState == StateMachine.Enemy.State.THROW) {
			this.GetComponent<SpriteRenderer>().sprite = panic;
		}
	}

	public float GetDistance(object sender, GameObject Rock)
	{
		float x1 = ((GameObject)sender).transform.position.x;
		float y1 = ((GameObject)sender).transform.position.y;
		float x2 = Rock.transform.position.x;
		float y2 = Rock.transform.position.y;
		return Mathf.Sqrt(((x1 - x2) * (x1 - x2)) + ((y1 - y2) * (y1 - y2)));
	}

    void Idle()
    {
		/* just stands still and detects if a rock is nearby
         * if the rock is very far away, as in this enemy is now far off screen...
         * we should call a destructor to get rid of this ai so we're not taking up excess resources
         */
		if (logic.role == StateMachine.Enemy.Role.NINJA) {
			if (rock.transform.position.x < this.transform.position.x) {
				if (logic.isBrave >= logic.isAfraid) {
					if (rock.transform.position.y > (this.transform.position.y + 5.0f)) {
						logic.currentState = StateMachine.Enemy.State.CROUCH;
					} else if (rock.transform.position.y <= (this.transform.position.y + 5.0f)) {
						logic.currentState = StateMachine.Enemy.State.JUMP;
					}
				}else
					logic.currentState = StateMachine.Enemy.State.PANIC;
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
		//Vector2 goal = new Vector2(rock.transform.position.x + 10.0f, this.transform.position.y);
		//this.transform.Translate(goal.normalized * speed * Time.deltaTime);
	}
    
	void Throw()
    {
		//gets current position of the rock and throws a pebble in that direction
		//pebbles reduce momentum by a small amount
		print ("Pretend I threw something");
		print ("It was fucking majestic");
    }
    
	public uint counter = 0;
	bool wasCalled = false;
	Vector2 first, goal;
	private float t = 0; //time

	void Jump()
    {
		//needs to move up and fall back down, should have gravity applied
		if (jumpCall) {
			counter = 0;
			jumpCall = false;
		}

		if (counter < 15) {
			this.transform.Translate(new Vector3(0, 0.30f, 0));
			counter++;
			this.GetComponent<SpriteRenderer>().sprite = jump;
		} else if (counter < 20) {
			this.transform.Translate(new Vector3(0, 0.10f, 0));
			counter++;
		} else {
			this.GetComponent<SpriteRenderer>().sprite = logic.normal;
		}
	}
    
	void Crouch() //changes to a crouching sprite, which gives it a smaller hitbox (AND prevents the jump)
	{
		this.GetComponent<SpriteRenderer>().sprite = crouch;
	}
    
	void Panic()
	{
		this.GetComponent<SpriteRenderer>().sprite = panic;
	}
}
