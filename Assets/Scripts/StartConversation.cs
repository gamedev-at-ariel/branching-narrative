using UnityEngine;


public class StartConversation : MonoBehaviour {
    [SerializeField] private float rayLength;
    [SerializeField] private LayerMask layermask;

    [SerializeField] private GameObject background;
    [SerializeField] private GameObject TextConversation;
    [SerializeField] private KeyCode keyToStartConversation = KeyCode.E;

    NPC otherObject;
    bool isEnter = false;
    float distance;

    private void OpenConversation() {
        isEnter = true;
        background.SetActive(true);
        TextConversation.SetActive(true);
        otherObject.GoToPassage();
        otherObject.Active();
    }

    private void CloseConversation() {
        background.SetActive(false);
        TextConversation.SetActive(false);
        otherObject.ShotDown();
        isEnter = false;
    }

    private void Start() {
        CloseConversation();
    }

    private void Update()  {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(keyToStartConversation)) {
            RaycastHit hit;
            // Does the ray intersect any objects excluding the player layer
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, rayLength, layermask) && !isEnter) {
                otherObject = hit.collider.gameObject.GetComponent<NPC>();
                Debug.Log("hit " + otherObject.name);
                OpenConversation();
            }
        }

        if (isEnter) {
            distance = Vector3.Distance(otherObject.transform.position, transform.position);
            if (distance > rayLength)              // If the player is too far away, close conversation
                CloseConversation();
        }
    }
}
