using System;
using System.Collections;
using System.Collections.Generic;
using Controllers;
using UnityEngine;

public class WayBehavior : MonoBehaviour
{
    [SerializeField] private List<GameObject> TreesOnWay = new List<GameObject>();

    private void OnEnable()
    {
        EventSystem.CheckTreesEvent += RegenerateListInvoke;
    }

    public void RegenerateListInvoke()
    {
        StartCoroutine(RegenerateList());
    }

    private IEnumerator RegenerateList()
    {
        yield return new WaitForSeconds(0.5f);
        for (int i = TreesOnWay.Count - 1; i >= 0; i--)
        {
            if (TreesOnWay[i] == null)
            {
                TreesOnWay.Remove(TreesOnWay[i]);
            }
        }

        if (TreesOnWay.Count == 0)
        {
            EventSystem.InvokeWinGame();
        }
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "Tree")
        {
            if (!TreesOnWay.Contains(other.gameObject))
            {
                TreesOnWay.Add(other.gameObject);
            }
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Tree")
        {
            if (TreesOnWay.Contains(other.gameObject))
            {
                TreesOnWay.Remove(other.gameObject);
            }
        }

        RegenerateListInvoke();
    }

    private void OnDisable()
    {
        EventSystem.CheckTreesEvent -= RegenerateListInvoke;
    }
}
