using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VRGaze : MonoBehaviour
{

    public Image imageGaze;
    private float totalTime = 2.0f;
    private bool gvrStatus;
    private float gvrTimer;

    public int distanceOfRay = 10;
    private RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        imageGaze.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (gvrStatus) {
            gvrTimer += Time.deltaTime;
            imageGaze.fillAmount = gvrTimer / totalTime;
        }

        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));

        if (Physics.Raycast(ray, out hit, distanceOfRay)) {
            if (imageGaze.fillAmount == 1 && hit.transform.CompareTag("Teleport")) {
                hit.transform.gameObject.GetComponent<Teleport>().TeleportPlayer();
                Debug.Log("player should be teleported now!");
            }
        }
       
    }

    public void GVROn() {
        gvrStatus = true;
    }

    public void GVROff() {
        gvrStatus = false;
        gvrTimer = 0;
        imageGaze.fillAmount = 0;
    }


}
