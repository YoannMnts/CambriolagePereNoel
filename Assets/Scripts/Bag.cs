using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class Bag : MonoBehaviour
{
    public event Action OnBagTriggered;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IInterctable interactable))
        {
            OnBagTriggered?.Invoke();
            interactable.Interact();
        }
    }
}
