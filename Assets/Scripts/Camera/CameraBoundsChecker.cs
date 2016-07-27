using UnityEngine;
using System.Collections;

public class CameraBoundsChecker {

    public Vector2 isInsideCameraBounds(Vector2 posToCheck, Vector2 size)
    {
        Vector2 cameraBound = new Vector2(0, 0);
        if (posToCheck.y + size.y > Camera.main.transform.position.y + Camera.main.orthographicSize)
        {
            cameraBound.y = 1;
        }
        else if (posToCheck.y - size.y < Camera.main.transform.position.y - Camera.main.orthographicSize)
        {
            cameraBound.y = -1;
        }

        float screenRatio = Screen.width / (float)Screen.height;
        float widthOrtho = Camera.main.orthographicSize * screenRatio;

        if (posToCheck.x + size.x > Camera.main.transform.position.x + widthOrtho)
        {
            cameraBound.x = 1;
        }
        else if (posToCheck.x - size.x < Camera.main.transform.position.x - widthOrtho)
        {
            cameraBound.x = -1;
        }

        return cameraBound;
    }


}
