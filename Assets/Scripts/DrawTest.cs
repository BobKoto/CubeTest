// Draw a yellow sphere at top-right corner of the near plane
// for the selected camera in the Scene view.
using UnityEngine;
using System.Collections;

public class DrawTest : MonoBehaviour
{
    void OnDrawGizmosSelected()
    {
        Camera camera = GetComponent<Camera>();
        Vector3 p = camera.ViewportToWorldPoint(new Vector3(1, 1, camera.nearClipPlane));
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(p, 0.9F); //original '.1f' too small/obscured
    }
}
// why?
// pertains to scene view gizmo only