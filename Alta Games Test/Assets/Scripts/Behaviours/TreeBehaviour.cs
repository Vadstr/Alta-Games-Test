using System;
using System.Collections;
using System.Collections.Generic;
using Behaviours;
using Controllers;
using UnityEngine;

public class TreeBehaviour : MonoBehaviour
{
    [SerializeField] private Material secondMaterial;
    [SerializeField] private MeshRenderer Mesh;

    private void OnTriggerEnter(Collider other)
    {
        EventSystem.Anigilate += Anigilate;
        if (other.tag == "StopTrigger")
        {
            other.gameObject.GetComponentInParent<BulletBehaviour>().StopMoove();
            EventSystem.InvokeAnigilate();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        EventSystem.Anigilate -= Anigilate;
    }

    public void Anigilate()
    {
        StartCoroutine(AnigilateTree());
    }

    public IEnumerator AnigilateTree()
    {
        EventSystem.Anigilate -= Anigilate;
        this.gameObject.GetComponent<Collider>().enabled = false;
        secondMaterial.color = Color.white;
        Mesh.materials[0] = secondMaterial;
        for (int i = 0; i < 100; i++)
        {
            Mesh.materials[0].color = new Color(1, 1 - i/100f , 1 - i/100f);
            yield return new WaitForSeconds(0.007f);
        }
        
        Destroy(this.gameObject);
    }
}
