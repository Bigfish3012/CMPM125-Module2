using UnityEngine;

public class WallButtonFire : MonoBehaviour
{
    public ParticleSystem[] fireBursts;
    public AudioSource fireSound; // https://pixabay.com/sound-effects/fireworks-01-419018/
    public AudioSource musicSound; //
    public float cooldownTime = 0.5f;

    bool playerInRange = false;
    float lastFireTime = -999f;
    public GameObject pressEHint;

    void Update()
    {
        if (!playerInRange) return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Time.time - lastFireTime < cooldownTime)
                return;

            lastFireTime = Time.time;

            if (fireBursts != null)
            {
                foreach (var ps in fireBursts)
                {
                    if (ps != null)
                        ps.Play();
                }
            }

            if (fireSound != null)
                fireSound.Play();
            if (musicSound != null)
                musicSound.Play();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
        if (pressEHint != null)
        {
            pressEHint.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
        if (pressEHint != null)
        {
            pressEHint.SetActive(false);
        }
    }
}
