using TMPro;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.InputSystem;

public class GunShoot : MonoBehaviour
{
    [SerializeField] GameObject muzzel;
    [SerializeField] TMP_Text killtext;
    public Animator anim;
    public Camera cam;
    public float range = 100f;

    public GameObject hitEffectPrefab;  // افکت برخورد
    public GameObject muzzleeffect;

    float killcounter = 0;
    void Start()
    {
        if (cam == null)
            cam = Camera.main;
    }

    void Update()
    {
        killtext.text = killcounter.ToString();
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            anim.SetTrigger("Shoot");
            Shoot();
        }
    }

    void Shoot()
    {
        Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        RaycastHit hit;
        GameObject effect = Instantiate(muzzleeffect, muzzel.transform.position, Quaternion.identity, this.transform);

        if (Physics.Raycast(ray, out hit, range))
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                Destroy(hit.collider.gameObject);
                killcounter++;
            }

            // ساخت افکت در محل برخورد
            SpawnHitEffect(hit);
        }
    }

    void SpawnHitEffect(RaycastHit hit)
    {
        // ساخت افکت در محل برخورد با جهت برخورد
        GameObject effect = Instantiate(hitEffectPrefab, hit.point, Quaternion.LookRotation(hit.normal));


    }
}
