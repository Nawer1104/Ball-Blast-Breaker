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

            collision.gameObject.GetComponent<SpriteRenderer>().color -= new Color(0, 0, 0, 0.2f);

            if (collision.gameObject.GetComponent<SpriteRenderer>().color.a < 0.2)
            {
                GameManager.Instance.levels[GameManager.Instance.GetCurrentIndex()].gameObjects.Remove(collision.gameObject);
                GameManager.Instance.CheckLevelUp();
            }

            Destroy(gameObject);
        }
        else if (collision != null && collision.gameObject.tag != gameObject.tag) 
        {
            GameObject vfx = Instantiate(vfxFail, transform.position, Quaternion.identity) as GameObject;
            Destroy(vfx, 1f);
            Destroy(gameObject);
        }
        
    }
}
