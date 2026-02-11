using UnityEngine;

public class XpBar : MonoBehaviour
{
    [SerializeField] Transform xpBar;

    public void State(int current, int max)
    {
        float state = (float) current;
        state /= max;
        if (state < 0f)
        {
            state = 0f;
        }
        xpBar.localScale = new Vector3(state, 1f, 1f);
    }
}