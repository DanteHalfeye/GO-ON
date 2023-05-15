using System.Collections;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayerInmunity : MonoBehaviour
{
    public int maxHealth = 5;
    public float timeInvincible = 2.0f;
  
    public int health { get { return currentHealth; } }
    public int currentHealth;

    bool wallJump=false;
    bool notwallJump = false;
    bool isInvincible;
    int canInvencible = 3;
    float invincibleTimer;
   public SpritePlayer player;
    Animator animator;
    private Health playerHealth;
    private Shields shields;
    public AudioClip damaged1;
    public AudioClip invensible;
    public AudioClip CheatCode;
    public AudioSource AudioSource;
    public AudioClip pickUp;




    // Start is called before the first frame update
    void Start()
    {
        Physics2D.IgnoreLayerCollision(7, 6, false);
        playerHealth = FindObjectOfType<Health>();
        shields = FindObjectOfType<Shields>();

        animator = GetComponent<Animator>();
        SpritePlayer player = GetComponent<SpritePlayer>();
    }
    public void DamagePlayer(int damage)
    {
        playerHealth.TakeDamage(damage);
    }

    public void ShieldPlayer(int damage)
    {
        shields.TakeDamage(damage);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire2"))
        {
            StartCoroutine("GetInvulnerable");
            
        }
        if (wallJump && notwallJump == false)
        {
            animator.Play("WallJumpPlayer");
        }
        else
        {
            if (Input.GetButton("Fire3"))
            {
                animator.Play("CrouchPlayer");

            }

            else
            {
                animator.Play("IdleMaxPlayer");
            }
        }

        if (Input.GetKeyDown(KeyCode.L) && Input.GetKeyDown(KeyCode.P) && Input.GetKeyDown(KeyCode.O))
        {
            Physics2D.IgnoreLayerCollision(7, 6, true);
            AudioSource.PlayOneShot(CheatCode);
        }
       


        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
                isInvincible = false;
        }
        if (currentHealth <= 0 )
        {
            ResetScene();
        }
    }
    public void WallJump1()
    {
        wallJump = true;
        
        notwallJump = false;
    }
    public void NotWallJump1()
    {
        wallJump = false;
        notwallJump = true;
    }
    public void RegenHealth(int amount)
    {
        DamagePlayer(amount);
    }
    public void ChangeHealth(int amount)
    {
        if (amount < 0)
        {
            AudioSource.PlayOneShot(damaged1);
            DamagePlayer(1);
            player.Ps();
            Physics2D.IgnoreLayerCollision(7, 6, true);
            StartCoroutine(DisableCollision());
        }

        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);
    }

    IEnumerator DisableCollision()
    {
        yield return new WaitForSeconds(timeInvincible);
        Physics2D.IgnoreLayerCollision(7, 6, false);
    }
    

    IEnumerator GetInvulnerable()
    {
        if (canInvencible > 0)
        {
            AudioSource.PlayOneShot(invensible);
            ShieldPlayer(1);
            Physics2D.IgnoreLayerCollision(7, 6, true);

            yield return new WaitForSeconds(2f);
            Physics2D.IgnoreLayerCollision(7, 6, false);
            canInvencible = canInvencible - 1;
           
        }
        
       
    }

    public void ResetScene()
    {
        StartCoroutine(Restart());  
        

    }

    IEnumerator Restart()
    {

        yield return new WaitForSeconds(0f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }



    public void PickUp()
    {
        AudioSource.PlayOneShot(pickUp);


    }
}