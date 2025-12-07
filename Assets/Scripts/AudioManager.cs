using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;   // THÊM DÒNG NÀY

    [SerializeField] private AudioSource backgroundAudioSource;
    [SerializeField] private AudioSource effectAudioSource;

    [SerializeField] private AudioClip BackGroundClip;
    [SerializeField] private AudioClip jumpClip;
    [SerializeField] private AudioClip landClip;
    [SerializeField] private AudioClip DashClip;
    [SerializeField] private AudioClip SwordClip;
    
    private void Awake()
    {
        // THÊM TOÀN BỘ ĐOẠN NÀY
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);   // Giữ nguyên qua các scene
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    void Start()
    {
        PlayBackGroundMusic();
    }

    public void PlayBackGroundMusic()
    {
        if (BackGroundClip != null)
        {
            backgroundAudioSource.clip = BackGroundClip;
            backgroundAudioSource.Play();
        }
    }

    public void PlayDashSound() => effectAudioSource.PlayOneShot(DashClip);
    public void PlayJumpSound() => effectAudioSource.PlayOneShot(jumpClip);
    public void PlaySwordSound() => effectAudioSource.PlayOneShot(SwordClip);
    public void PlayLandSound() => effectAudioSource.PlayOneShot(landClip);
}