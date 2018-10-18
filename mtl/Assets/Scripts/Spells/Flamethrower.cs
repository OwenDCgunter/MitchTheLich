﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flamethrower : Abstract_Spell {

	//declare specific properties
	public float launchSpeed;
	public float coneAngle;
	private Rigidbody rb;

	//set specific stats
	public Flamethrower() {
		this.damage = mtl.Damage.DEV_TEST_BULLET_DAMAGE;
		this.manaCost = 10f;
		this.fireDelay = 0.1f;


		this.launchSpeed = mtl.Movement.BASE_PROJECTILE_SPEED;
		this.coneAngle = 45f;
	}

	public override void Launch(GameObject spawner) {
		GameObject r = Resources.Load("Element1RedBullet") as GameObject;

		rb = r.GetComponent<Rigidbody>();
		Rigidbody projectileInstance;
		projectileInstance = Instantiate(rb, spawner.transform.position + new Vector3(0f, mtl.Camera.SPELL_DEFAULT_CAST_HEIGHT, 0f) + (mtl.Camera.SPELL_DEFAULT_CAST_OFFSET_DISTANCE * spawner.transform.forward), spawner.transform.rotation) as Rigidbody;

		projectileInstance.velocity = launchSpeed * spawner.transform.forward;
		Debug.Log("Instantiate Flamethrower Particle");
	}

	public override void UseMana(GameObject o) {
		o.GetComponent<HealthState>().UseMana(manaCost);
	}

	public override void ApplyBuffs(GameObject o) {
		List<Abstract_TimedBuff> buffs = this.BList(o);
		Buffable b = o.GetComponent<Buffable>();

		foreach (Abstract_TimedBuff atb in buffs) {
			b.AddBuff(atb);
			Debug.Log("Applied Buff: " + atb.ToString() + " to " + o.tag + ".");
		}
	}
}
