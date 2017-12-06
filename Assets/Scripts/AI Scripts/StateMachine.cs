using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StateMachine {
    /* States:
	 * Idle is just standing and doing nothing; used for initializing
	 * Throw takes place when a Thrower is brave; a rock is thrown
	 * Attack is used when brawler is brave, or when a troll has max brave value
	 * Punch is used after attack, when goblin is near the boulder
	 * Run is used whenever any goblin is not brave; runs away from boulder
	 * Crouch is used by ninja when ninja is brave and boulder is up high; crouches to avoid boulder
	 * Jump is also used by ninja when ninja is brave and boulder is down low; attempts to jump over the boulder
	 * Panic is used when any goblin has 0 bravery; Just stands still and screams
	 * Fly is the initial state of the bird; Flies forward at a steady rate
	 * Charge is used by a flock of aggroed birds; Charges toward the boulder in a kamikazi attack
	 */
    /* Roles:
	 * Unassigned is a null initializer
	 * Brawler is the bald goblin that is more likely to attack
	 * Thrower is the samurai looking goblin that is more likely to throw or run
	 * Troll is the cavegoblin that is most likely to run
	 * Ninja is the goblin in black that will run, jump, or crouch
	 * Bird is bird, it flies and a whole flock gets mad if you hit their friend
	 */
	public class Enemy
    {
        public enum State { IDLE, THROW, ATTACK, PUNCH, RUN, CROUCH, JUMP, PANIC, FLY, CHARGE };
        public enum Role { UNASSIGNED, BRAWLER, THROWER, TROLL, NINJA, BIRD };
        public State currentState { get; set; }
        public Role role { get; set; }
        public float isBrave, isAfraid; //used with fuzzy logic to help determine the State, for variation purposes
        
		public Enemy()
        {
            currentState = State.IDLE;
            role = Role.UNASSIGNED;
            isBrave = 0.5f;
            isAfraid = Fuzzy.NOT(isBrave);
        }
        
		//pass by value constructor
        public Enemy(State state, Role role, float b)
        {
            currentState = state;
            this.role = role;
            isBrave = b;
            isAfraid = Fuzzy.NOT(isBrave);
        }
        
		public void SetBravery(Role role)
        {
            //threshold values are set according the Role
            float randomNum = Random.Range(0.0f, 10.0f); //using values of 0 - 9.999999 to keep simple-ish
            float lowerThreshold = 4.0f, upperThreshold = 7.0f;
            switch (role)
            {
                case Role.BRAWLER:
                    lowerThreshold = 2.0f;
                    upperThreshold = 5.0f;
                    break;
                case Role.THROWER:
                    lowerThreshold = 3.5f;
                    upperThreshold = 7.0f;
                    break;
                case Role.TROLL:
                    lowerThreshold = 7.0f;
                    upperThreshold = 9.5f;
                    break;
                case Role.NINJA:
                    lowerThreshold = 2.0f;
                    upperThreshold = 7.0f;
                    break;
                default:
                    break; //can just break since we have initialized values
            }
            //call upon chosen fuzzy function using the above floats
            this.isBrave = Fuzzy.Linear(randomNum, lowerThreshold, upperThreshold);
            this.isAfraid = Fuzzy.NOT(isBrave);
        }
        
		public void GenerateEnemy() //also Sets Role
        {
            //float rand = Random.Range(0.0f, 10.0f);
			/*
            if (rand < 5.0f && rand >= 2.5f) enemy.role = Enemy.Role.THROWER;
            else if (rand < 7.5f && rand >= 5.0f) enemy.role = Enemy.Role.BRAWLER;
            else if (rand < 10.0f && rand >= 7.5f) enemy.role = Enemy.Role.NINJA;
            else enemy.role = Enemy.Role.TROLL;
            */
			this.role = Enemy.Role.NINJA;
            this.SetBravery(this.role);
        }
    }
}
