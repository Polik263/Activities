using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    
    void OnCollisionEnter (Collision collisionInfo)
    {
        Scene currentscene = SceneManager.GetActiveScene();

        if (collisionInfo.collider.tag == "Enemy")

        {
            SceneManager.LoadScene("SampleScene");

        }

    }

   
}
