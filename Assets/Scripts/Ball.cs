using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private Reticle reticleManager;
    [SerializeField] private Projectile[] projectiles;

    private new SpriteRenderer renderer;

    private int startIndex = 0;

    private void Awake()
    {
        renderer = GetComponent<SpriteRenderer>();
        SetSpriteAndProjectile();
    }

    public void ChangeBall()
    {
        startIndex += 1;

        if (startIndex == projectiles.Length)
        {
            startIndex = 0;
        }

        SetSpriteAndProjectile();
    }

    void SetSpriteAndProjectile()
    {
        renderer.sprite = projectiles[startIndex].GetComponent<SpriteRenderer>().sprite;
        reticleManager.SetupProjectile(projectiles[startIndex].gameObject);
    }

    private void OnMouseDown()
    {
        reticleManager.Selected(this.gameObject);
    }

    private void OnMouseUp()
    {
        reticleManager.Deselect();
    }
}
