using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {

    public GameObject enemy;

	// Use this for initialization
	void Start () {
        // m_someOtherScriptOnAnotherGameObject = GameObject.FindObjectOfType(typeof(ScriptA)) as ScriptA;
        // m_someOtherScriptOnAnotherGameObject.Test();
        // or  myObject.GetComponent<MyScript>().MyFunction();
        StateMachine.Enemy foolToBeCrushed = enemy.GetComponent<StateMachine.Enemy>().GenerateEnemy();
        StateMachine.Enemy.Role role = enemy.GetComponent<StateMachine.Enemy>().role;
        enemy.GetComponent<StateMachine.Enemy>().GenerateSprite(role);
        foolToBeCrushed.SetBravery(role);
    }

    // Update is called once per frame, LateUpdate performs calculations before running the commands
    void LateUpdate () {
	//run change state logic
        //set behaviour according to the set state
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
         * Destroy(this);
         */
    }
    void Attack()
    {
        //gets the position of the rock and moves towards it. 
        //when at a close distance, throw a punch.
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
    }
    void Throw()
    {
        //gets current position of the rock and throws a pebble in that direction
        //pebbles reduce momentum by a small amount
    }
    void Jump()
    {
        //needs to move up and fall back down, should have gravity applied
    }
    void Crouch()
    {
        //changes to a crouching sprite, which gives it a smaller hitbox
    }
    void Panic()
    {
        //changes sprite to a panicking sprite, and just stands still
    }
    void Fly()
    {
        //just moves to the left in a straight line
    }
    void Charge()
    {
        //bird charges towards the rock
    }
}
