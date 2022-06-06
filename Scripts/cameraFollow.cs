// Bibliotecas do Unity que são carregadas assim que o arquivo C#, sem estás 03 bibliotecas o script não irá funcionar.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Classe criada junto do arquivo C# e deve conter restritamente o nome do arquivo.
public class cameraFollow : MonoBehaviour
{
    // Variáveis públicas, as variáveis do tipo "float" indica que pode ser editada na interface do Unity e aceitam valores quebrados e a variável "Trasform" informa uma variável que influencia um compomente do inspector no Unity
    public float FollowSpeed = 2f;
    public float yOffset = 1f;
    public Transform target;

    // Método que é ativado uma vez a cada frame com o jogo ativo, e com isso atualiza a posição da câmera para o personagem.
    void Update()
    {
        Vector3 newPos = new Vector3(target.position.x,target.position.y + yOffset,-10f);
        transform.position = Vector3.Slerp(transform.position,newPos,FollowSpeed*Time.deltaTime);
    }
}