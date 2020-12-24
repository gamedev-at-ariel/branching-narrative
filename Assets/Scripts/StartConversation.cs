using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class StartConversation : MonoBehaviour
{
    [SerializeField]
    private float rayLength;
    [SerializeField]
    private LayerMask layermask;

    [SerializeField]
    private GameObject ConversationPanel;
    [SerializeField]
    private GameObject background;
    [SerializeField]
    private GameObject TextConversation;

    NPC otherObject;
    bool isEnter = false;
    float distance;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)){
            RaycastHit hit;
            // Does the ray intersect any objects excluding the player layer
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, rayLength, layermask) && !isEnter)
            {
                otherObject = hit.collider.gameObject.GetComponent<NPC>();
                Debug.Log("hit " + otherObject.name);

                // Calculate the distance between Player and NPC
                distance = Vector3.Distance(otherObject.transform.position, transform.position);

                //Open conversation
                isEnter = true;
                background.SetActive(true);
                TextConversation.SetActive(true);
                otherObject.GoToPassage();
                otherObject.Active();
            }    
        }

        if (isEnter)
        {
            distance = Vector3.Distance(otherObject.transform.position, transform.position);
            // If the player is too far away, close conversation
            if (distance > rayLength)
            {
                background.SetActive(false);
                TextConversation.SetActive(false);
                otherObject.ShotDown();
                isEnter = false;
            }
        }
    }
}
