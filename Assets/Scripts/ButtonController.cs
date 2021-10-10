using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ButtonController : MonoBehaviour
{
    
    public void scale(float scale)
    {
        transform.localScale = new Vector2(1 / scale, 1 * scale);
    }

    // fungsi pemanggilan scene 

    public void Scene(string scene)
    {
        Application.LoadLevel(scene);
    }
    // Update is called once per frame
    void Update()
    {

    }
}