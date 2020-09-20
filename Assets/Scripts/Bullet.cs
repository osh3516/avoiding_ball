using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f; 
    public GameObject explosion;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
  
    }

    IEnumerator FadeIn()
    {
        for (float i = 1f; i >= 0; i -= 0.01f)
        {
            Color color = new Vector4(1, 1, 1, i);
            transform.GetComponent<Renderer>().material.color = color;
            Destroy(gameObject, 0.7f);
            yield return 0;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        Debug.Log("Hit");
     
        if (other.gameObject.tag =="Ground")
        {
            Debug.Log("Hit Ground");
          
            StartCoroutine("FadeIn");
           
        }
        else if (other.gameObject.tag == "Player")
        {
            Instantiate(explosion, transform.position, transform.rotation);
            gameObject.SetActive(false);
        }
    }
    

}