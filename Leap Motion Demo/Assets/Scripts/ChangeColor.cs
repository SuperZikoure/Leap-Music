using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public Color color;
    public bool rainbow;
    [Range(1.0f, 10.0f)]
    public float delta = 1.0f; // Determines speed of color change.
    private Renderer renderer;
    private Color newColor;
    private float cpt = 0.0f; //Cpt increase once per frame. Once at 255, it reset and increase step by one.
    private int step = 0; //Step is the step of the rotation cycle.
    //You can see it when you want to change a color in the inspector. Once it reach 7, it reset.

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
        renderer.material.color = color;
    }

    // Update is called once per frame
    void Update()
    {
        if (rainbow) {
            if (cpt >= 255) {
                step++;
                cpt = 0;
            }
            if (step == 7)
                step = 0;
            SelectChangeColor();
            cpt += delta;
        }
    }

    //According to step, this function call ParseChangeColor with differents parameters.
    void SelectChangeColor()
    {
        switch (step) {
            case (0):
                ParseChangeColor('g', '+');
                break;
            case (1):
                ParseChangeColor('r', '-');
                break;
            case (2):
                ParseChangeColor('b', '+');
                break;
            case (3):
                ParseChangeColor('g', '-');
                break;
            case (4):
                ParseChangeColor('r', '+');
                break;
            case (5):
                ParseChangeColor('b', '-');
                break;
            case (6):
                ParseChangeColor('g', '+');
                break;
            default:
                break; 
        }
    }

    //Parse the color change selected.
    void ParseChangeColor(char primary, char sign)
    {
        newColor = renderer.material.color;
        switch(primary) {
            case('g'):
                newColor.g += TransformColor(sign);
                break;
            case('r'):
                newColor.r += TransformColor(sign);
                break;
            case('b'):
                newColor.b += TransformColor(sign);
                break;
            default:
                return;
        }
        renderer.material.color = newColor;
    }

    //Get the evolution per frame of a color. It can be positive or negative.
    float TransformColor(char sign)
    {
        if (sign == '+')
            return delta / 255.0f;
        else
            return -delta / 255.0f;
    }
}