using UnityEngine;

namespace Behaviours
{
    public class BulletBehaviour : MonoBehaviour
    {
        [SerializeField] private int speed;
        private float bulletPower;
        private bool isMoove = false;
        
        private void Start()
        {
            bulletPower = 0;
        }

        private void Update()
        {
            if(isMoove)
                gameObject.transform.position += new Vector3(0,0,speed) * Time.deltaTime;
        }

        public void StartMoove()
        {
            isMoove = true;
        }

        public void StopMoove()
        {
            isMoove = false;
            Destroy(gameObject);
        }

        public void SetPowerForBullet(float addpower)
        {
            bulletPower += addpower;
            var scale = 0.7f + (bulletPower / 100f);
            gameObject.GetComponent<SphereCollider>().radius = bulletPower/5;
            gameObject.transform.localScale = new Vector3(scale,scale,scale);
        }
    }
}