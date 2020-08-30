using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CharacterStats))]
public class HealthUI : MonoBehaviour
{
    public GameObject uiPrefab;
    public Transform target;

    private float visibleTime = 5f;
    private float lastMadeVisible;

    private Transform UI;
    private Image healthSlider;
    private Transform cam;

    private void Start()
    {
        cam = Camera.main.transform;

        foreach(Canvas c in FindObjectsOfType<Canvas>())
        {
            if(c.renderMode == RenderMode.WorldSpace)
            {
                UI = Instantiate(uiPrefab, c.transform).transform;
                //green health slider is a child of the red image to make the green render above the red
                healthSlider = UI.GetChild(0).GetComponent<Image>();
                UI.gameObject.SetActive(false);

                break;
            }
        }

        GetComponent<CharacterStats>().OnHealthChanged += OnHealthChanged;
    }

    //target position is set in Update, so wait to set UI's position until we are sure it was set
    private void LateUpdate()
    {
        if (UI != null)
        {
            UI.position = target.position;
            UI.forward = -cam.forward;

            if(Time.time - lastMadeVisible > visibleTime)
            {
                UI.gameObject.SetActive(false);
            }
        }
    }

    private void OnHealthChanged(int maxHealth, int currentHealth)
    {
        if (UI != null)
        {
            UI.gameObject.SetActive(true);
            lastMadeVisible = Time.time;

            float healthPercent = currentHealth / (float)maxHealth;
            healthSlider.fillAmount = healthPercent;
            if (currentHealth <= 0)
            {
                Destroy(UI.gameObject);
            }
        }
    }
}