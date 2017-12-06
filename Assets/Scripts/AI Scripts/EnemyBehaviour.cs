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
	public Sprite ninjaPanic;
	public Sprite punch;
	public Sprite trollPanic;
	public Sprite ninja;
	public string role;
	private float speed = 5.0f;
	private float jumpHeight = 2.0f;
	//StateMachine.Enemy foolToBeWrecked = new StateMachine.Enemy();
	//StateMachine.Enemy.Role role;

	//initializer
	void Start()
	{
		logic = new StateMachine.Enemy();
		logic.GenerateEnemy();
		rb = GetComponent<Rigidbody2D>();

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
	}

    // Update is called once per frame, LateUpdate performs calculations before running the commands
    void LateUpdate () {
		//run change state logic
    	//set behaviour according to the state
		if (logic.role == StateMachine.Enemy.Role.NINJA) {
			//if (rock.transform.position.x < this.transform.position.x && this.transform.position.x - rock.transform.position.x < 4) {
			if (this.transform.position.x - rock.transform.position.x < 4 && this.transform.position.x - rock.transform.position.x > -10) {
				//print(this.transform.position.x - rock.transform.position.x + " triggering.");
				if (logic.isBrave >= logic.isAfraid) {
					//print(logic.isBrave);
					if (((rock.transform.position.y) > (this.transform.position.y + 1)) && ((rock.transform.position.x) <= (this.transform.position.x))) {
						//print("CROUCHING!!!");
						logic.currentState = StateMachine.Enemy.State.CROUCH;
					//} else if (rock.transform.position.y <= (this.transform.position.y)) {
					} else {
						//print("JUMPING!!!");
						logic.currentState = StateMachine.Enemy.State.JUMP;
					}
				} else {
					//print("PANICKING!!!");
					logic.currentState = StateMachine.Enemy.State.PANIC;
				}
			}
		}
		else if(logic.role == StateMachine.Enemy.Role.TROLL){
			
		}
		else if(logic.role == StateMachine.Enemy.Role.BRAWLER){
			
		}
		else if(logic.role == StateMachine.Enemy.Role.THROWER){
			
		}
		if (this.transform.position.x - rock.transform.position.x < 4 && this.transform.position.x - rock.transform.position.x > -10) {
			DoAction();
		}
    }

	void DoAction()
	{
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
	/*
	public Sprite GenerateSprite(StateMachine.Enemy.Role role)
	{
		Sprite sprite = new Sprite();
		if (role == StateMachine.Enemy.Role.UNASSIGNED)
			sprite = Resources.Load<Sprite>("../Sprites/Goblins_0");
		else if (role == StateMachine.Enemy.Role.THROWER)
			sprite = Resources.Load<Sprite>("../Sprites/GoblinChucker_0");
		else if (role == StateMachine.Enemy.Role.TROLL)
			sprite = Resources.Load<Sprite>("../Sprites/GoblinTroll_0");
		else if (role == StateMachine.Enemy.Role.NINJA)
			sprite = Resources.Load<Sprite>("Sprites/WizardHut.png");
			//sprite = mySprite;
		else if (role == StateMachine.Enemy.Role.BRAWLER)
			sprite = Resources.Load<Sprite>("../Sprites/GoblinBruiser_0");
		else if (role == StateMachine.Enemy.Role.BIRD)
			sprite = Resources.Load<Sprite>("../Sprites/Bird_0");
		else
			sprite = Resources.Load<Sprite>("../Sprites/GoblinNinja_0");
		return sprite;
	}
*/
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

		/* if (rock.transform.position.x > (this.transform.position.x + 200.0f)) //if rock is 200 units to the right of this gameobject
			print("I would have destroyed myself"); 
			//Destroy(this); //commit harakiri
		else */

		if (logic.role == StateMachine.Enemy.Role.NINJA) {
			if (rock.transform.position.x < this.transform.position.x) {
				if (logic.isBrave >= logic.isAfraid) {
					if (rock.transform.position.y > (this.transform.position.y + 5.0f)) {
						logic.currentState = StateMachine.Enemy.State.CROUCH;
					}
					else if (rock.transform.position.y <= (this.transform.position.y + 5.0f)) {
						logic.currentState = StateMachine.Enemy.State.JUMP;
					}
				}
				else
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
		print ("Pretend I threw something");
		print ("It was fucking majestic");
        //gets current position of the rock and throws a pebble in that direction
        //pebbles reduce momentum by a small amount
    }
    
	public uint counter = 0;
	bool wasCalled = false;
	Vector2 first, goal;
	private float t = 0; //time

	void Jump()
    {
		this.GetComponent<SpriteRenderer>().sprite = ninja;

		/*
		if (!wasCalled) {
			first = new Vector3(this.transform.position.x, this.transform.position.y, 0.0f);
			goal = new Vector3(this.transform.position.x, this.transform.position.y + jumpHeight, 0.0f);
			wasCalled = true;
			print("Was Called");
		} else {
			//print("Was already called!");
		}

		if (counter < 200) {
			t += Time.deltaTime / 0.5f;

			if (counter < 50) {
				goblin.position = Vector3.Lerp(first, goal, t);
				counter++;
			} else if (counter == 50) {
				t = 0;
				counter++;
			} else {
				goblin.position = Vector3.Lerp(goal, first, t);
				counter++;
			}
		}
		*/

		//rb.AddForce(new Vector3(0.0f, 2.0f, 0.0f), ForceMode2D.Impulse);
		this.transform.Translate(new Vector3 (0, 0.15f, 0));

		//needs to move up and fall back down, should have gravity applied
		//this.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/GoblinNinja_8");
	}
    
	void Crouch()
	{
		this.GetComponent<SpriteRenderer>().sprite = crouch;
		//changes to a crouching sprite, which gives it a smaller hitbox
		//this.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/GoblinNinja_5");
	}
    
	void Panic()
	{
		if (logic.role == StateMachine.Enemy.Role.NINJA) {
			this.GetComponent<SpriteRenderer>().sprite = ninjaPanic;
		} else if (logic.role == StateMachine.Enemy.Role.TROLL) {
			this.GetComponent<SpriteRenderer>().sprite = ninjaPanic; //change to troll panic
			Run();
		} else if (logic.role == StateMachine.Enemy.Role.BRAWLER) {
			this.GetComponent<SpriteRenderer>().sprite = ninjaPanic; //change to brawler panic
			Run();
		} else if (logic.role == StateMachine.Enemy.Role.THROWER) {
			this.GetComponent<SpriteRenderer>().sprite = ninjaPanic; //change to thrower panic
			Run();
		}
	}
/*
	void NinjaPanic()
    {
        //changes sprite to a panicking sprite, and just stands still
		this.GetComponent<SpriteRenderer>().sprite = ninjaPanic;
		Run ();
    }
*/

}
