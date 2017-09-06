using UnityEngine;
using System.Collections;

public class MicInput : MonoBehaviour {

    public static float MicLoudness;

    private string _device;

    //A handle to the attached AudioSource  
    public AudioSource goAudioSource;

    void Start()
    {
        //Check if there is at least one microphone connected  
        if (Microphone.devices.Length <= 0)
        {
            //Throw a warning message at the console if there isn't  
            Debug.LogWarning("Microphone not connected!");
        }
        else //At least one microphone is present  
        {
            //Get the attached AudioSource component  
            goAudioSource = this.GetComponent<AudioSource>();
        }
    }

    AudioClip _clipRecord = new AudioClip();
    int _sampleWindow = 128;

    //mic initialization
    void InitMic()
    {
        if (_device == null) _device = Microphone.devices[0];
        _clipRecord = Microphone.Start(_device, true, 10, 44100);
    }

    void StopMicrophone()
    {
        Microphone.End(_device);
    }

    //get data from microphone into audioclip
    float LevelMax()
    {
        float levelMax = 0;
        float[] waveData = new float[_sampleWindow];
        int micPosition = Microphone.GetPosition(null) - (_sampleWindow + 1); // null means the first microphone
        //Debug.Log("This is the current mic position" + micPosition); 
        if (micPosition < 0) return 0;
        _clipRecord.GetData(waveData, micPosition);
        // Getting a peak on the last 128 samples
        for (int i = 0; i < _sampleWindow; i++)
        {
            float wavePeak = waveData[i] * waveData[i];
            if (levelMax < wavePeak)
            {
                levelMax = wavePeak;
            }
        }

        //Debug.Log("This is the level max " + levelMax);
        return levelMax;
    }



    void Update()
    {
        // levelMax equals to the highest normalized value power 2, a small number because < 1
        // pass the value to a static var so we can access it from anywhere
        MicLoudness = LevelMax();
        //Debug.Log("This is the current MicLoudness" + MicLoudness);
        goAudioSource.clip = _clipRecord;


        goAudioSource.Stop();
        goAudioSource.loop = true;
        // Mute the sound with an Audio Mixer group becuase we don't want the player to hear it
        Debug.Log(Microphone.IsRecording(_device).ToString());

        if (Microphone.IsRecording(_device))
        { //check that the mic is recording, otherwise you'll get stuck in an infinite loop waiting for it to start
            while (!(Microphone.GetPosition(_device) > 0))
            {
            } // Wait until the recording has started. 

            Debug.Log("recording started with " + _device);

            if (!goAudioSource.isPlaying)
            {
                // Start playing the audio source
                goAudioSource.Play();
            }
        }
        else
        {
            //microphone doesn't work for some reason

            Debug.Log(_device + " doesn't work!");
        }

    }

    bool _isInitialized;
    // start mic when scene starts
    void OnEnable()
    {
        InitMic();
        _isInitialized = true;
    }

    //stop mic when loading a new level or quit application
    void OnDisable()
    {
        StopMicrophone();
    }

    void OnDestroy()
    {
        StopMicrophone();
    }


    // make sure the mic gets started & stopped when application gets focused
    void OnApplicationFocus(bool focus)
    {
        if (focus)
        {
            //Debug.Log("Focus");

            if (!_isInitialized)
            {
                //Debug.Log("Init Mic");
                InitMic();
                _isInitialized = true;
            }
        }
        if (!focus)
        {
            //Debug.Log("Pause");
            StopMicrophone();
            //Debug.Log("Stop Mic");
            _isInitialized = false;

        }
    }
}//end of class
