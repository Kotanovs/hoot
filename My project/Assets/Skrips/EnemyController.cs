using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public NavMeshAgent agent;
    public Animator animator;
    private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine (findPath ());
        StartCoroutine (playerDetect ());
    }

    IEnumerator playerDetect()
    {
        while (true)
        {
            if (player == null)
                break;
            if (Vector3.Distance(transform.position, player.position) < 2f)
            {
                animator.SetBool("attack", true);
                player.SendMessage("damage");
            }
            yield return new WaitForSeconds(.3f);
        }
    }
    IEnumerator findPath()
    {
        while(true)
        {
            if (player != null)
            {
                agent.SetDestination(player.position);
                yield return new WaitForSeconds(2f);
            }
            else break;
        }
    }
    public void damage()
    {
        StopAllCoroutines ();
        agent.enabled = false;
        animator.SetTrigger ("die");
        gameObject.GetComponent<CapsuleCollider> ().enabled = false;
        Destroy (gameObject, 5f);
        GameManager.instance.deadUnit (gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
