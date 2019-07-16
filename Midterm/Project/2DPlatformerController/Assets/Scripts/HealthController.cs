using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
	public int healthMax;
	public int manaMax;
	public int health;
	public int mana;
    public GameObject healthBar;
    public GameObject manaBar;

	void Start () {
        health = healthMax;
        mana = manaMax;
    }

    public void takeHealth(int dame){
    	health = health - dame;
    	if(health <= 0){
    		health = 0;
    	}
    }

    public void takeMana(int dame){
    	mana = manaMax - dame;
    	if(mana <= 0){
    		mana = 0;
    	}
    }

    public void Update(){
        healthBar.GetComponent<Transform>().localScale = new Vector3(health*1.0f/healthMax, 1,1);
        manaBar.GetComponent<Transform>().localScale = new Vector3(mana*1.0f/manaMax, 1,1);
    }

    public void addHeath(int energy) {
        health = health + energy;
        if(health >= healthMax){
            health = healthMax;
        }
    }

    public void addMana(int energy) {
        mana = mana + energy;
        if(mana >= manaMax){
            mana = manaMax;
        }
    }

    public int returnHealth() {
        return health;
    }

    public int returnMana() {
        return mana;
    }
}
