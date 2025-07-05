using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.Image;

public class search : MonoBehaviour
{
    // Start is called before the first frame update
    public float angle = 45f;
    public bool phit;
    //public bool debug1, debug2, debug3;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player") //Ž‹ŠE‚Ì”ÍˆÍ“à‚Ì“–‚½‚è”»’è
        {
            //Ž‹ŠE‚ÌŠp“x“à‚ÉŽû‚Ü‚Á‚Ä‚¢‚é‚©
            Vector3 posDelta = other.transform.position - this.transform.position;
            float target_angle = Vector3.Angle(this.transform.forward, posDelta);

            if (target_angle < angle) //target_angle‚ªangle‚ÉŽû‚Ü‚Á‚Ä‚¢‚é‚©‚Ç‚¤‚©
            {
                Ray ray = new Ray(this.transform.position, posDelta);
                UnityEngine.Debug.DrawRay(ray.origin, ray.direction * 30, Color.red, 0.1f);
                if (Physics.Raycast(this.transform.position, posDelta, out RaycastHit hit)) //Ray‚ðŽg—p‚µ‚Ätarget‚É“–‚½‚Á‚Ä‚¢‚é‚©”»•Ê
                {

                    if (hit.collider.gameObject.tag == "Player")
                    {
                        phit = true;
                    }
                    if (hit.collider == other)
                    {
                        phit = true;
                    }
                }
            }
        }
    }
    void Update()
    {
        if (phit)
        {
            phit = false;
        }
    }
}
