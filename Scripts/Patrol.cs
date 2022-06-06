// Bibliotecas do Unity que são carregadas assim que o arquivo C#, sem estás 03 bibliotecas o script não irá funcionar.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Classe criada junto do arquivo C# e deve conter restritamente o nome do arquivo.
public class Patrol : MonoBehaviour
{
// Variável pública do tipo "float" que é criada para aceitar valores quebrados e pode ser editada na interface da unity.
 public float speed;

// Variável privada do tipo "bool" que é criada para aceitar apenas "true or false" e só pode ser editada via código C#. 
 private bool MovingRight = true;

// Variável pública do tipo "transform" que é criada para editar o componente "Transform" do inspector na interface da Unity.
 public Transform groundDetection;

// Método que é ativado uma vez a cada frame com o jogo ativo.
void Update()
 {
    // A sintaxe abaixo utiliza da variável "speed" e a variável "Vector2" para configurar a velocidade e direção da movimentação do "GameObject".
    transform.Translate(Vector2.right * speed * Time.deltaTime);
    
    // Configura uma camada especifica para o script executar uma ação. 
    int layer_mask = LayerMask.GetMask ("chaoInimigo");

    // Sintaxe que configura a detecção do solo com o "GameObject" a que este script for anexado.
    RaycastHit2D groundinfo = Physics2D.Raycast (groundDetection.position, Vector2.down, 1f, layer_mask);
    
    // A cascata de condição abaixo vericifa se a colisão com o solo for falsa, caso a condição seja atendida ele executa outro if.
    if(groundinfo.collider == false){
       
        // A cascata de condição abaixo verifica se o "GameObject" está movenco-se positivamente no eixo X, caso a condição seja atendida, o "GameObject" irá girar em 180 graus. 
        if(MovingRight == true){
           transform.eulerAngles = new Vector3(0, -180, 0);
           MovingRight = false;
           
           // Caso a condição não seja atingida, ele seguirá caminhando positivamente no eixo X.
           } else {
            
            transform.eulerAngles = new Vector3(0, 0, 0);
            MovingRight = true;
        }
    }
 
 
 }

}
