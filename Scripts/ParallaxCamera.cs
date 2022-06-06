// Bibliotecas do Unity que são carregadas assim que o arquivo C#, sem estás 03 bibliotecas o script não irá funcionar.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*

A função deste script no projeto é atribuir o efeito Parallax ao componente MainCamera na interface do Unity.

Métodos deste Script:

void Start();
void Update();

GameObject atribuido:

MainCamera.

*/

// Classe criada junto do arquivo C# e deve conter restritamente o nome do arquivo.
public class ParallaxCamera : MonoBehaviour

 {
     // Variável pública com o componente "ParallaxCameraDelegate" com um valor "float", no caso significa que recebe números quebrados.
     public delegate void ParallaxCameraDelegate(float deltaMovement);
     
     // Variável pública com o componente "ParallaxCameraDelegate" e pode ser editada via interface do Unity.
     public ParallaxCameraDelegate onCameraTranslate;
     
     // Variável privada do tipo "float" para valores quebrados, e pode ser alterado apenas via código no script.
     private float oldPosition;
    
    // Método que é ativado uma vez apenas e é quando o jogo começa.
    void Start()
     {
         // Atribui á variável oldPosition o eixo X de movimentação, para a câmera mover-se horizontalmente.
         oldPosition = transform.position.x;
     }

     // Método que é ativado uma vez a cada frame com o jogo ativo.
     void Update()
     {
         // A cascata de condição abaixo compara se a posição no eixo X é diferente da variável, se este parâmetro for acatado, ele executa a função contida no if.
         if (transform.position.x != oldPosition)
         {
             // A cascata de condição abaixo compara se a variável "onCameraTranslate" for diferente de nulo, o script vai executar uma sintaxe que altera a posição no eixo X.
             if (onCameraTranslate != null)
             {
                 float delta = oldPosition - transform.position.x;
                 onCameraTranslate(delta);
             }
             oldPosition = transform.position.x;
         }
     }
 }