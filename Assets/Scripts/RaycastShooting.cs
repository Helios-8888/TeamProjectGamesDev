using UnityEngine;

public class RaycastShooting : MonoBehaviour
{
public float range = 100f;
public Camera fpsCam;

void Update()
{
if (Input.GetButtonDown("Fire1"))
{
Shoot();
}
}

void Shoot()
{
RaycastHit hit;
if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
{
Debug.Log("Hit: " + hit.transform.name);
// Add effects like damage or particle systems here
}
}
}