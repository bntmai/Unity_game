using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyFox : PhysicsObject {

	public int dame;
	public int energy;
	public float maxSpeed = 7;
	public float jumpTakeOffSpeed = 7;
	public float moveSpeed = -0.5f;
	public float leftX = -100000;
	public float rightX = 100000;
    public Text LoseText;
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
		else {
			if (transform.position.x < leftX)
				moveSpeed = Mathf.Abs(moveSpeed);
			if (transform.position.x > rightX)
				moveSpeed = -Mathf.Abs(moveSpeed);
		}
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
             collision.GetComponent<HealthController>().takeHealth(dame);
             collision.GetComponent<HealthController>().takeMana(energy);
             checkStatus(collision);
        }
    }

    void checkStatus(Collider2D collision) {
        int health = collision.GetComponent<HealthController>().returnHealth();
        int mana = collision.GetComponent<HealthController>().returnMana();

        if (health <=0 || mana <=0) {
   		   collision.GetComponent<HealthController>().Update();
           collision.GetComponent<PlayerController>().destroy();
           LoseText.text = LoseText.text + "\nMark: " + collision.GetComponent<MarkGold>().mark.ToString();
           LoseText.enabled = true;
        }
    }
}