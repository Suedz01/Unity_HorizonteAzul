using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    public Transform target;  // objeto a seguir
    public float distance;  // distância da câmera ao objeto
    public float height;  // altura da câmera em relação ao objeto

    void LateUpdate()
    {
        // Verifica se o objeto está definido
        if (target == null)
            return;

        // Define a posição da câmera baseada na posição do objeto
        transform.position = target.position - target.forward * distance + Vector3.up * height;

        // Faz a câmera olhar para o objeto
        transform.LookAt(target);
    }
}

