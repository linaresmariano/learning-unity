using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float speed = 200;
	public float maxSpeed = 5;
	int moving = 0;


	// Update is called once per frame
	void Update () {
		if (Input.GetKey("right") || Input.GetKey("d")) {
			moving = -1;
		} else if (Input.GetKey("left") || Input.GetKey("a")) {
			moving = 1;
		} else {
			moving = 0;
		}

		if (moving != 0) {
			var velocityX = System.Math.Abs(rigidbody2D.velocity.x);
			if (velocityX < .5) {
				rigidbody2D.AddForce(new Vector2(moving, 0) * speed);
				if (this.transform.localScale.x != moving) {
					float oldX = System.Math.Abs(this.transform.localScale.x);
					this.transform.localScale = new Vector3(oldX * moving, this.transform.localScale.y, 1);
				}
			}
			if (velocityX > maxSpeed)
				rigidbody2D.velocity = new Vector2(maxSpeed * moving, 0);
		}
	}
}
