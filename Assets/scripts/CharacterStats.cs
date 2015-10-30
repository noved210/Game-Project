using UnityEngine;
using System.Collections;

public class CharacterStats : MonoBehaviour {

	public float health = 10;

	public void DealDamage(float amount)
	{
		health -= amount;
	}

}
