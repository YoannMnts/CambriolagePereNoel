using System;
using UI;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class Bag : MonoBehaviour
{
    public event Action OnBagTriggered;
    
    public int CurrentCoin { get; private set; }
    public int MaxCoin { get; private set; }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInParent<XRGrabInteractable>().TryGetComponent(out IInterctable interactable))
        {
            interactable.Interact(this);
            OnBagTriggered?.Invoke();
            PlayerPrefs.SetInt("MaxCoinAmount", CurrentCoin);
        }
    }

    public void AddCoin(int amount)
    {
        CurrentCoin += amount;
    }
}
