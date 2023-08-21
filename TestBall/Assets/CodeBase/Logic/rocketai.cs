using UnityEngine;

namespace CodeBase.Logic
{
    public class rocketai : MonoBehaviour
    {
        [SerializeField, Range(.01f, .1f)] private float enemyRocketSpeed;
        public GameObject ball;

        private void Start()
        {
            ball = GameObject.Find("Ball(Clone)");
        }

        private void Update()
        {
            if (ball.transform.position.z > 0)

            {
                var x = Mathf.Lerp(gameObject.transform.position.x, ball.transform.position.x, enemyRocketSpeed);
                gameObject.transform.position =
                    new (x, gameObject.transform.position.y, gameObject.transform.position.z);
    
            }
        }
    }
}