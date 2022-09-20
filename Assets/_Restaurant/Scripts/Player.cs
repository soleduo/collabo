using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private static Player instance;
    public static Player Instance { get { return instance; } }

    public Food food = null;

    public event VoidEvent OnPlayerArrived;


    private void Start()
    {
        if(instance == null)
          instance = this;
    }

    public IEnumerator MoveToTable(Table t)
    {
        Vector2 dir = (t.transform.position - transform.position).normalized;

        while ((t.transform.position - transform.position).sqrMagnitude > 0.5f) {
            transform.position += (Vector3.up * dir.y * 2f * Time.deltaTime) + (Vector3.right * dir.x * 3f * Time.deltaTime);
            yield return null;
        }

        t.Interact();
    }

}
