using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private GameObject vfxSuccess;
    [SerializeField] private GameObject vfxFail;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.gameObject.tag == gameObject.tag)
        {
            GameObject vfx = Instantiate(vfxSuccess, transform.position, Quaternion.identity) as GameObject;
            Destroy(vfx, 1f);

            GameManager.Instance.levels[GameManager.Instance.GetCurrentIndex()].gameObjects.Remove(collision.gameObject);
            Destroy(collision.gameObject);
            Destroy(gameObject);
            GameManager.Instance.CheckLevelUp();

        }
        else if (collision != null && collision.gameObject.tag != gameObject.tag) 
        {
            GameObject vfx = Instantiate(vfxFail, transform.position, Quaternion.identity) as GameObject;
            Destroy(vfx, 1f);
            Destroy(gameObject);
        }
        
    }
}
