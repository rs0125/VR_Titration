using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

[RequireComponent(typeof(XRGrabInteractable))]
public class VRKnob : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;
    private Quaternion initialRotation;
    private Vector3 initialGrabPosition;

    public float minAngle = -45f;  // Minimum rotation angle
    public float maxAngle = 45f;   // Maximum rotation angle

    private void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.selectEntered.AddListener(OnGrabbed);
        grabInteractable.selectExited.AddListener(OnReleased);
    }

    private void OnGrabbed(SelectEnterEventArgs args)
    {
        initialRotation = transform.localRotation;
        initialGrabPosition = args.interactorObject.transform.position;
    }

    private void OnReleased(SelectExitEventArgs args)
    {
        // Handle actions when the knob is released, if needed
    }

    private void Update()
    {
        if (grabInteractable.isSelected)
        {
            Vector3 currentGrabPosition = grabInteractable.interactorsSelecting[0].transform.position;

            // Calculate the relative rotation around the Y-axis
            Vector3 direction = currentGrabPosition - transform.position;
            float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;

            // Clamp the angle to the specified range
            float clampedAngle = Mathf.Clamp(angle, minAngle, maxAngle);

            // Apply the clamped rotation
            transform.localRotation = initialRotation * Quaternion.Euler(0, clampedAngle, 0);
        }
    }
}
