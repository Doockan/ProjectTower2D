using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    private int HP = 1;
    private Animator anim;
    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    public void TakeDamage(int value)
   {
        if (HP - value > 0)
        {
            HP -= value;
           // anim.SetTrigger("Hurt");
        }
        else
        {
            // anim.SetTrigger("Dead");
            StartCoroutine(DeadAnim());
            //DeadBecome();
        }
   }

    IEnumerator DeadAnim()
    {
        gameObject.tag = "Untagged";
        yield  return new WaitForSeconds(0.01f);
        gameObject.GetComponent<SpriteRenderer>().color = gameObject.GetComponent<SpriteRenderer>().color = new Color(1 , 1, 1, 0.9f);
        yield return new WaitForSeconds(0.01f);
        gameObject.GetComponent<SpriteRenderer>().color = gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.8f);
        yield return new WaitForSeconds(0.01f);
        gameObject.GetComponent<SpriteRenderer>().color = gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.7f);
        yield return new WaitForSeconds(0.01f);
        gameObject.GetComponent<SpriteRenderer>().color = gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.6f);
        yield return new WaitForSeconds(0.01f);
        gameObject.GetComponent<SpriteRenderer>().color = gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);
        yield return new WaitForSeconds(0.01f);
        gameObject.GetComponent<SpriteRenderer>().color = gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.4f);
        yield return new WaitForSeconds(0.01f);
        gameObject.GetComponent<SpriteRenderer>().color = gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.3f);
        yield return new WaitForSeconds(0.01f);
        gameObject.GetComponent<SpriteRenderer>().color = gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.2f);
        yield return new WaitForSeconds(0.01f);
        gameObject.GetComponent<SpriteRenderer>().color = gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.1f);
        yield return new WaitForSeconds(0.01f);
        DeadBecome();
    }
    public void DeadBecome()
    {
        gameObject.SetActive(false);
    
    }
    /*
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "PlayerBullet")
        {
            if (coll.gameObject.GetComponent<Sword>().CanTake)
            {

                TakeDamage(coll.gameObject.GetComponent<Sword>().Damage);
            }
        }
    }
    */

}