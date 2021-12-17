using UnityEngine;


public class StartConversation : MonoBehaviour {
    [Tooltip("The distance in which the conversation disappears.")]
    [SerializeField] private float rayLength;

    [SerializeField] private LayerMask layermask;

    [Tooltip("The Background of the TwineTextPlayer.")]
    [SerializeField] private GameObject background;

    [Tooltip("The ScrollView of the TwineTextPlayer.")]
    [SerializeField] private GameObject ConversationView;

    [SerializeField] private KeyCode keyToStartConversation = KeyCode.E;

    NPC otherObject;
    bool isInConversation = false;
    float distance;

    private void OpenConversation() {
        isInConversation = true;
        background.SetActive(true);
        ConversationView.SetActive(true);
        otherObject.GoToPassage();
        otherObject.Activate();
    }

    private void CloseConversation() {
        background.SetActive(false);
        ConversationView.SetActive(false);
        otherObject.ShotDown();
        isInConversation = false;
    }

    private void Start() {
        CloseConversation();
    }

    private void Update()  {

        if (isInConversation) {
            distance = Vector3.Distance(otherObject.transform.position, transform.position);
            if (distance > rayLength)              // If the player is too far away, close conversation
                CloseConversation();
        } else {
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(keyToStartConversation)) {
                RaycastHit hit;
                // Does the ray intersect any objects excluding the player layer
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, rayLength, layermask)) {
                    otherObject = hit.collider.gameObject.GetComponent<NPC>();
                    Debug.Log("hit " + otherObject.name);
                    OpenConversation();
                }
            }
        }
    }
}
