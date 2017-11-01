using UnityEngine;

public class ZippyTerrain2DRollingBall : MonoBehaviour {
	Rigidbody2D cacheRB;
	float input;
	void Start () {
		cacheRB = GetComponent<Rigidbody2D>();
	}
	
	void Update () {
        input = Input.GetAxis("Horizontal");
        cacheRB.AddTorque(-10); //Constantly add force, need to make it where player initially launches boulder
	}

	void FixedUpdate() {
		cacheRB.AddTorque(-input*10);
	}
}
