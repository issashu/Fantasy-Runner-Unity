using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	public float ManaCost;
	public int Lives = 3;

    private float CurHealth;
	public float curHealth 
	{
        get { return CurHealth; }
        set {
        	CurHealth = value;
            if(CurHealth > maxHealth) {
                CurHealth = maxHealth;
            }
            if(CurHealth < 0) {
                Die();
                curHealth = 0;
            }
        }
    }

    [SerializeField]
    private float MaxHealth;
	public float maxHealth {
        get { return MaxHealth; }
        set { MaxHealth = value; }
    }

    private float CurMana;
	public float curMana {
        get { return CurMana; }
        set {
        	CurMana = value;
            if(CurMana > maxMana) {
                CurMana = maxMana;
            }
            if(CurMana < 0) {
                CurMana = 0;
            }
        }
    }

    [SerializeField]
    private float MaxMana;
	public float maxMana {
        get { return MaxMana; }
        set { MaxMana = value; }
    }

    [SerializeField]
    private float HealthRegenSpeed;
	public float healthRegenSpeed {
        get { return HealthRegenSpeed; }
        set { HealthRegenSpeed = value; }
    }

    [SerializeField]
    private float ManaRegenSpeed;
	public float manaRegenSpeed {
        get { return ManaRegenSpeed; }
        set { ManaRegenSpeed = value; }
    }


	// Use this for initialization
	void Start () 
	{
        curHealth = maxHealth;
        curMana = maxMana;
		ManaCost = 2f;
	}
	
	// Update is called once per frame
	void Update () 
	{

		curHealth += Time.deltaTime * healthRegenSpeed;

		curMana += Time.deltaTime * manaRegenSpeed;

		uGUIHealthController.Instance.UpdateVitals();
	}

	public void CastSpell() 
	{
		curMana -= ManaCost;  // Позволява всяка магия да си има различен мана кост, като използва ManaCost
        uGUIHealthController.Instance.UpdateVitals();
	}

	public void TakeDamage(float Damage) 
	{
		curHealth -= Damage;
		//curHealth -= Random.Range(10,20);
        uGUIHealthController.Instance.UpdateVitals();
	}

   
	public void Die() 
	{
		if (Lives >= 1) 
		{
			GameObject.FindGameObjectWithTag ("Checkpoint").GetComponent<PlayerCheckpoint> ().RestartCheckpoint ();
			GameObject.FindGameObjectWithTag ("ScoreControl").GetComponent<ScoreManage> ().ScoreCount = false;
			Lives -= 1;
		} 

		if (Lives <= 0)
		{
			Application.LoadLevel (1);
		}
    }
}
