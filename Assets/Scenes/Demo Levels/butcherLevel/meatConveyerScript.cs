using UnityEngine;

public class meatConveyerScript : MonoBehaviour
{
    new float xPosition;
    new float yPosition;
    new float zPosition;

    // Update is called once per frame
    void Update()
    {
        xPosition = transform.position.x; // finds the x position of the object
        yPosition = transform.position.y; // finds the y position of the object
        zPosition = transform.position.z; // finds the z position of the object

        if (xPosition > -38.5)
        {
            transform.position = new Vector3(xPosition - 0.01f, yPosition, zPosition); // moves the meat along the x axis
        }
        else if (zPosition < 14 - 30)
        {
            transform.position = new Vector3(xPosition, yPosition, zPosition + 0.01f); // moves the meat along the z axis
        }
        else
        {
            transform.position = new Vector3(-0.5f, yPosition, 4.5f - 30f); // returns the meat to the beginning of the conveyer belt
            // NOTE TO SELF: For some reason when returning back to the beginning of the conveyer belt, the z axis start and end position would always be off by a margin of 30.
            // I could not for the life of me figure out why this was happening - fortunately I don't need to understand to know how to fix it (hence why I've subtracted 30)
            // [I did it this way because it seemed more modular than just writing -25.5f, that way we can adjust the offset should I ever want to make another conveyer belt]
        }
    }
}
