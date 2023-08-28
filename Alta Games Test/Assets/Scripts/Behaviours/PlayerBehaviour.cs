using System;
using Behaviours;
using Controllers;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject wayLine;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject bulletPref;
    [SerializeField] private GameObject door;
    
    [SerializeField] private int StartScore;
    
    private PlayerController playerController;
    private BulletBehaviour bulletBehaviour = null;
    private GameObject bullet = null;
    private bool isTouch = false;
    
    
    private void Awake()
    {
        playerController = new PlayerController(StartScore);
    }

    private void OnEnable()
    {
        EventSystem.WinGameEvent += Win;
    }

    private void OnDisable()
    {
        EventSystem.WinGameEvent -= Win;
    }

    private void Update()
    {
        if (playerController.PlayerScore < StartScore * 0.2)
        {
            EventSystem.InvokeLoseGame();
        }


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

    private void Win()
    {
        player.transform.DOJump(player.transform.position + new Vector3(0f, 0f, 50f), 2.5f, 5, 5, false);
        DOTween.Sequence()
            .AppendInterval(2)
            .Append(door.transform.DORotate(new Vector3(0,90,0),0.5f));
    }

    private void ChangeSize()
    {
        var scale = 3 * (playerController.PlayerScore/StartScore);
        player.transform.localScale = new Vector3(scale, scale, scale);
        wayLine.transform.localScale = new Vector3(scale, 1, 1);
    }
}
