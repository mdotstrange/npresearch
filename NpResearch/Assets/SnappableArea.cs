using UnityEngine;
using System.Collections;

public class SnappableArea : MonoBehaviour
{
    public DraggableUI MyDraggableUI;
    private DraggableUI snappedImage = null;

    private void OnEnable()
    {
        MyDraggableUI = GetComponentInParent<DraggableUI>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DraggableUI otherImage = other.GetComponentInParent<DraggableUI>();

        if (otherImage)
        {
            snappedImage = otherImage;
            // You can add snap logic here, like making the images move together
            // For now, we'll just log which images connected
            Debug.Log($"{MyDraggableUI.imageType} connected to {snappedImage.imageType}");

            ExecuteCodeBasedOnConnection();
        }
        else
        {
            Debug.Log("NO snapper");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        DraggableUI otherImage = other.GetComponentInParent<DraggableUI>();
        if (otherImage && otherImage == snappedImage)
        {
            snappedImage = null;
            // Handle disconnection logic here if necessary
        }
    }

    private void ExecuteCodeBasedOnConnection()
    {
        if (snappedImage)
        {
            // Example: Execute specific logic if imageType is Type1 and it connects to Type2
          //  if (MyDraggableUI.imageType == MyDraggableUI.im.Start && snappedImage.imageType == ImageType.Follow)
           // {
                // Run your specific code here
          //  }
            // Add more conditions for different image combinations as needed
        }
    }

}

