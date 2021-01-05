using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Waypoint : MonoBehaviour
{
    private Image iconImage;
    private Text distanceText;

    public Transform player;
    public Transform target;
    public Camera cam;

    public float closeEnoughDistance;

    // Start is called before the first frame update
    void Start()
    {
        iconImage = GetComponent<Image>();
        distanceText = GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            GetDistance();
            CheckOnScreen();
        }
    }

    void GetDistance()
    {
        float dist = Vector3.Distance(player.position, target.position);
        distanceText.text = dist.ToString("f1") + "m";

        if (dist < closeEnoughDistance)
        {
            Destroy(gameObject);
        }
    }

    void CheckOnScreen()
    {
        float thing = Vector3.Dot((target.position - cam.transform.position).normalized, cam.transform.forward);

        if (thing <= 0)
        {
            ToggleUI(false);

        }
        else
        {
            ToggleUI(true);
            Vector3 screenPos = cam.WorldToScreenPoint(target.position);
            transform.position = screenPos;
            //transform.position = new Vector3(screenPos.x, screenPos.y, screenPos.z);
            //Debug.Log("target is " + screenPos.x + " pixels from the left");
        }
    }

    void ToggleUI(bool _value)
    {
        iconImage.enabled = _value;
        distanceText.enabled = _value;
    }
}
