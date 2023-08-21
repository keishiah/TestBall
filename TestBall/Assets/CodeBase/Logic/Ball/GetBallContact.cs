using UnityEngine;

namespace CodeBase.Logic
{
    public class GetBallContact : MonoBehaviour
    {
        private MeshRenderer rend;
        private Shader gradientShader;

        private void Awake()
        {
            rend = GetComponent<MeshRenderer>();
            gradientShader = Shader.Find("Custom/PointGradientWaveShader");

            if (rend.material.shader != gradientShader)
            {
                Debug.LogError("Ensure the GameObject has a material with the PointGradientShader!");
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            foreach (ContactPoint contact in collision.contacts)
            {
                Vector3 hitPoint = contact.point;
                Vector3 localHitPoint = transform.InverseTransformPoint(hitPoint);
                rend.material.SetVector("_Center", localHitPoint);
                rend.material.SetInt("Wave Speed", 1);
                rend.material.SetInt("Wave Width", 1);
                break;
            }
        }
    }
}