using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    private Touch touch;
    private Vector2 touchStart;
    private Vector2 touchEnd;

    private void Update()
    {
        if(Input.touchCount == 0) 
        {
            return;
        }

        Swipe();
    }

    private void Swipe()
    {
        touch = Input.GetTouch(0); 

        if(touch.phase == TouchPhase.Began) 
        {
            touchStart = touch.position;
        }    
        else if(touch.phase == TouchPhase.Moved)
        {
            touchEnd = touch.position;
        }
        else if(touch.phase == TouchPhase.Ended)
        {
            Vector2 touchValue = (touchEnd - touchStart);
            print("Valor da subtração: " + touchValue);

            
            if(Mathf.Abs(touchValue.x) > Mathf.Abs(touchValue.y))
            {
                // MOVIMENTO HORIZONTAL  (ESQUERDA OU DIREITA)

                if (touchStart.x < touchEnd.x) 
                {
                    print("Direita");
                }
                else
                {
                    print("Esquerda");
                }

            }
            else
            {
                // VERTICAL
                if (touchStart.y < touchEnd.y)
                {
                    print("Cima");
                }
                else
                {
                    print("Baixo");
                }
            }

        }
    }
}
