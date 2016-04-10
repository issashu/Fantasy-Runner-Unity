using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public bool AnimateBG;
    
 
    public float missleSpeed;
    public float moveSpeed;
    public float JumpH;
    public GameObject Finger;
    public float Radius = 0.2f;
    public GameObject CircleArea;
    public LayerMask collidingLayer;
    public GameObject chara;
	public ParticleSystem AttackSkillEffect;

    bool allowCast = true;
    PlayerHealth ph;
    BoxCollider2D IdleCOllider;
    PolygonCollider2D CrouchedCollider;
    bool crouched;
    float CurrentMana;
    Animator animator;
    bool doubleJumped;
    GameObject[] SpellBook;
    public bool isFacingLeft = false;
    bool IsGrounded;
    public int pos = 1;
    Rigidbody2D Rb2D;

	bool Scorecounting; // за изчисление на точки, виж линии 160
	
	
	void Start () {
     
        ph = GetComponent<PlayerHealth>();
        IdleCOllider = GetComponent<BoxCollider2D>();
        CrouchedCollider = GetComponent<PolygonCollider2D>();
        doubleJumped = false;
        isFacingLeft = false;
        IsGrounded = false;
        animator = GetComponent<Animator>();
        Rb2D = GetComponent<Rigidbody2D>();

		AttackSkillEffect = GetComponentInChildren<ParticleSystem> ();

		//Проверяваме колко "Деца" има Pool-а
        int count = Finger.transform.childCount;
        //Задаваме горната бройка на Масива ни от обекти
        SpellBook = new GameObject[count];
        //Запълваме масива
        for (int i = 0; i < count; i++)
        {
            //На елементите от масива им задаваме стойноста на съотвения поред дете-обект на Pool-a
            SpellBook[i] = Finger.transform.GetChild(i).gameObject;
        }
	}
    //Метода за Достъп до Pool=a
    IEnumerator Cast(float pos)
    {
        allowCast = false;
        int count = SpellBook.Length;
        //pos е извикан по-надолу в кода, представлява посоката на която гледа героя
        Vector2 direction = new Vector2(pos, 0f);
        animator.SetTrigger("IsAttacking");
		AttackSkillEffect.GetComponent<ParticleSystem>().Play ();
        yield return new WaitForSeconds(0.3f);
        //Обхождаме всички елементи

        for (int i = 0; i < count; i++)
        {
            //проверяваме кои са активни
            if (!SpellBook[i].activeSelf)
            {
                //Ако елемента не е активен го назначаваме на новия ни елемент, който активираме и задаваме посока и сила
                GameObject spell = SpellBook[i];
                spell.SetActive(true);
				spell.GetComponent<Rigidbody2D>().AddForce(direction * missleSpeed, ForceMode2D.Impulse);
				spell.GetComponent<AudioSource>().Play ();
				break;
            }
        }
        ph.CastSpell();
        allowCast = true;
    }
   

   
    
    void Jump()
    {
        IsGrounded = false;
        Rb2D.AddForce(Vector2.up * JumpH,ForceMode2D.Impulse);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            IdleCOllider.enabled = false;
            CrouchedCollider.enabled = true;
            crouched = true;
        }
        if (Input.GetKeyUp(KeyCode.C))
        {
            crouched = false;
            IdleCOllider.enabled = true;
            CrouchedCollider.enabled = false;
        }
        
		if (Input.GetButtonDown("Jump") && (IsGrounded || !doubleJumped))
		{
            Rb2D.velocity = new Vector2(Rb2D.velocity.x, 0f);
            Jump();
            
			if (!doubleJumped && !IsGrounded)
            {
                doubleJumped = true;
            }
		}
        if (crouched)
            return;
    
		if (Input.GetButtonDown("Fire1") && allowCast && ph.curMana > ph.ManaCost )
        {
            
            StartCoroutine( Cast(pos));
           
        }
      
        

     }
   
    void FixedUpdate() 
	{
       
        animator.SetBool("Ground", IsGrounded);
        animator.SetFloat("Yvelocity", Rb2D.velocity.y);
        animator.SetFloat("Speed", Mathf.Abs(Rb2D.velocity.x));
        animator.SetBool("Crouching", crouched);
        if (crouched)
            return;
        

       
        
        IsGrounded = Physics2D.OverlapCircle(CircleArea.transform.position, Radius, collidingLayer);
        if (IsGrounded)
            doubleJumped = false;
        
          
       
        
        //Horizontal Moevement
        float Hot = Input.GetAxis("Horizontal");
		Rb2D.velocity = new Vector2(Hot * moveSpeed, Rb2D.velocity.y);

		//Код за точкова система
		if(Hot != 0)
		{
			GameObject.FindGameObjectWithTag ("ScoreControl").GetComponent<ScoreManage> ().ScoreCount = true;
			AnimateBG = true;
			//Debug.Log (AnimateBG);
		}

		if (Hot == 0) 
		{
			GameObject.FindGameObjectWithTag ("ScoreControl").GetComponent<ScoreManage> ().ScoreCount = false;
			AnimateBG = false;
			//Debug.Log (AnimateBG);
		}
		// Край на кода
        if (Hot < 0 && !isFacingLeft)
        {
            pos = -1;
            Flip();
        }
        else if(Hot >0 && isFacingLeft)
        {
            pos = 1;
            Flip();
        }
            
       
	}

    


    void Flip()
    {
        isFacingLeft = !isFacingLeft;
        Vector3 Scale = this.transform.localScale;
        Scale.x *= -1;
        transform.localScale = Scale;
        Finger.transform.Rotate(0f, 180f, 0f,Space.Self);
    }
 

  
   
}
