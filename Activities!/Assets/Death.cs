using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
     

    void OnCollisionEnter (Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Enemy")

        {
            gameObject.transform.position = new Vector3(0.1f, 0.5f, -7.16f);

        }

    }

   
}
