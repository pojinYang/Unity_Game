using UnityEngine;

public class FadeInOutController : MonoBehaviour
{
    public FadeInOut m_Fade;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            m_Fade.BackGroundControl(true);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            m_Fade.BackGroundControl(false);
        }else if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            m_Fade.BackGroundControl_White(true);
        }
    }
    public void FadeIn()
    {
        m_Fade.BackGroundControl(true);
    }
    public void FadeOut()
    {
        m_Fade.BackGroundControl(false);
    }
}
