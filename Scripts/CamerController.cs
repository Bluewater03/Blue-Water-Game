// Bibliotecas do Unity que são carregadas assim que o arquivo C#, sem estás 03 bibliotecas o script não irá funcionar.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*

A função deste script no projeto é controlar a câmera de forma automática.

Métodos deste Script:

void Start();
void Update();

GameObject atribuido:

Player.

*/

// Classe criada junto do arquivo C# e deve conter restritamente o nome do arquivo.
public class CamerController : MonoBehaviour {
    
    // Variáveis públicas com método float que servem para receberem valores quebrados.
    public float speed;
    public float clampLeft;
    public float clampRight;

    // Variável privada que só pode ser editada via código.
    private float cameraX;

    // Método que é ativado uma vez apenas e é quando o jogo começa.
    void Start () {
        cameraX = transform.position.x;
		
	}
	
	// Método que é ativado uma vez a cada frame com o jogo ativo.
	void Update () {

        // O sintaxe abaixo define a câmera para mover-se junto do "GameObject" referenciado, no caso o "GameObject" tag "Player".
        if (Input.GetKey(KeyCode.RightArrow) && transform.position.x < clampRight)
        {
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        }
        if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x > clampLeft)
        {
            transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
        }
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log(cameraX);
        }
    }
}
