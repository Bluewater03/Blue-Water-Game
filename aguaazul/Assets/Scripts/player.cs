using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    //Vari�veis
    public float Speed;
    public float jumpForce;
    private Rigidbody2D body;
    
    public bool isJumping, doubleJump;

    private Animator anime;


    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anime = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    //Criar m�todo de movimento
    void Move()
    {
        //O Input serve para detectar teclas e definir valores para elas
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        // transform.position so funciona com Vector3
        
        transform.position += movement * Time.deltaTime * Speed;

        if (Input.GetAxis("Horizontal") > 0f){
        anime.SetBool("run", true);
        transform.eulerAngles = new Vector3(0f, 0f, 0f);
        
        }

        if (Input.GetAxis("Horizontal") < 0f){
        anime.SetBool("run", true);
        transform.eulerAngles = new Vector3(0f, 180f, 0f);
        
        }
     
     if (Input.GetAxis("Horizontal") == 0f){
        anime.SetBool("run", false);
        }
    }

    void Jump()
    {
        //Para pular, usaremos o RigidBody para movimentar o personagem
        if (Input.GetButtonDown("Jump"))
        {
            if (!isJumping)
            {
                //ativa a op��o de pular duas vezes
                body.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
                
            }   
            
        }

    }

    //M�todos para verificar se o personagem toca em algo
    //tamb�m corrige um problema de pular a cada vez que se pressiona a tecla espa�o

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            isJumping = false;
        }

        if(collision.gameObject.tag == "damage")
        {
            healthController.acesso.TakeDamage();
            
            if (healthController.acesso.Health == 0){
                
                SavePoint.acesso.ShowGameOver();
                Destroy(gameObject);
            }
        }
        if(collision.gameObject.tag == "heal")
        {
            healthController.acesso.Heal();
        }
    
        if(collision.gameObject.tag == "vitoria")
        {
            SavePoint.acesso.ShowVitoria();
            Destroy(gameObject);
        }
    
        if(collision.gameObject.tag == "morte")
        {
            SavePoint.acesso.ShowGameOver();
            Destroy(gameObject);
        }
      
      if(collision.gameObject.tag == "porta")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
      
      }
    

    void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            isJumping = true;
        }
    }
}
