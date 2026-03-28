using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] Sprite _deadSprite;
    [SerializeField] ParticleSystem _ps;
    bool _hasDied;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (ShouldDieFromCollision(collision))
        {
            Die();
        }
    }

    void Die()
    {
        _hasDied = true;
        GetComponent<SpriteRenderer>().sprite = _deadSprite;
        _ps.Play();
        //gameObject.SetActive(false);
    }

    bool ShouldDieFromCollision(Collision2D collision)
    {
          if (_hasDied)
                return false;
         
          Birb bird = collision.gameObject.GetComponent<Birb>();
          if (bird != null)
                return true;

          if (collision.contacts[0].normal.y < -0.5)
                return true;

        return false;
    }

}
