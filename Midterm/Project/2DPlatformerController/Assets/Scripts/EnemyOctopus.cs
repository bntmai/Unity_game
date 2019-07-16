using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOctopus : PhysicsObject
{
	public int dame;
	public float maxSpeed = 5;
	public float jumpTakeOffSpeed = 4;
	public float moveSpeed = -0.3f;

	private SpriteRenderer spriteRenderer;
	private Animator animator;

	// Use this for initialization
	void Awake () 
	{
		spriteRenderer = GetComponent<SpriteRenderer> ();    
		animator = GetComponent<Animator> ();
	}

	protected override void ComputeVelocity()
	{
		Vector2 move = Vector2.zero;

		if (Mathf.Abs(velocity.x) < 0.01f)
			moveSpeed = -moveSpeed;
		move.x = moveSpeed;

		bool flipSprite = (spriteRenderer.flipX ? (move.x > 0.01f) : (move.x < 0.01f));
		if (flipSprite) 
		{
			spriteRenderer.flipX = !spriteRenderer.flipX;
		}

		animator.SetBool ("grounded", grounded);
		animator.SetFloat ("velocityX", Mathf.Abs (velocity.x) / maxSpeed);

		targetVelocity = move * maxSpeed;
	}

	void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
             collision.GetComponent<HealthController>().takeMana(dame);
        }
    }
}
