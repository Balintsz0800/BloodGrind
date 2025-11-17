using UnityEngine;

namespace DefaultNamespace
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] Transform healthBar;

        public void State(int current, int max)
        {
            float state = (float) current;
            state /= max;
            if (state < 0f)
            {
                state = 0f;
            }
            healthBar.localScale = new Vector3(state, 1f, 1f);
        }
    }
}