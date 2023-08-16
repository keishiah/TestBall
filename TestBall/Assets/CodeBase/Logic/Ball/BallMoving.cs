using UnityEngine;
using Random = UnityEngine.Random;

namespace CodeBase.Logic
{
    public class BallMoving : MonoBehaviour
    {
        private float startSpeed = 1f;

        private void Start()
        {
            SetStartForce();
        }

        public void SetStartForce()
        {
            Vector3 randomVector =
                new Vector3(Random.Range(-.9f, .9f), 0, startSpeed * Random.value > .5f ? -1 : 1);


            gameObject.GetComponent<Rigidbody>().AddForce(randomVector * 10f, ForceMode.VelocityChange);
        }
    }
}