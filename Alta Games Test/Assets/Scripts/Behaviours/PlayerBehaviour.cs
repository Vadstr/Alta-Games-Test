using System;
using Behaviours;
using Controllers;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject wayLine;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject bulletPref;

    [SerializeField] private int StartScore;
    
    private PlayerController playerController;
    private BulletBehaviour bulletBehaviour = null;
    private GameObject bullet = null;
    private bool isTouch = false;
    
    
    private void Awake()
    {
        playerController = new PlayerController(StartScore);
    }

    private void Update()
    {
        
        if (Input.touchCount > 0)
        {
            isTouch = true;
            if (bullet == null)
            {
                bullet = Instantiate(bulletPref);
                bullet.transform.position = player.transform.position + new Vector3(0,0,7);
                bulletBehaviour = bullet.GetComponent<BulletBehaviour>();
                bulletBehaviour.SetPowerForBullet(10);
                playerController.GetPowerForBullet(10);
            }
            else
            {
                bulletBehaviour.SetPowerForBullet(5f * Time.deltaTime);
                playerController.GetPowerForBullet(5f * Time.deltaTime);
                ChangeSize();
            }
        }
        else if (isTouch)
        {
            isTouch = false;
            bulletBehaviour.StartMoove();
            bullet = null;
        }
    }

    private void ChangeSize()
    {
        var scale = 3 * (playerController.PlayerScore/StartScore);
        player.transform.localScale = new Vector3(scale, scale, scale);
        wayLine.transform.localScale = new Vector3(scale, 1, 1);
    }
}
