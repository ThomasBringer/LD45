using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineManager : MonoBehaviour
{
    [SerializeField] float time = .0001f;

    static public TimelineManager tm;

    void Awake() { tm = this; }

    [SerializeField] PlayableDirector startDirector;
    [SerializeField] PlayableDirector endDirector;

    //void Awake() { director = GetComponent<PlayableDirector>(); }

    //void Update()
    //{
    //    PlayerMovement.controllable = director.state == PlayState.Playing;
    //}

    void OnEnable() { startDirector.stopped += OnPlayableDirectorStopped; }
    void OnDisable() { startDirector.stopped -= OnPlayableDirectorStopped; }

    void OnPlayableDirectorStopped(PlayableDirector aDirector)
    {
        if (startDirector == aDirector) StartGame();
    }

    [SerializeField] GameObject player;

    void StartGame()
    {
        player.SetActive(true);
        //FindObjectOfType<Player>().gameObject.SetActive(true);

        //Player.player.gameObject.SetActive(true);

        //PlayerMovement.controllable = true;

        Levels.Level = 0;
        //Levels.Level++;
    }

    [SerializeField] Camera cutsceneCam;

    public void EndGame()
    {
        cutsceneCam.cullingMask = Layers.layers.everything;

        PlayerMovement.controllable = false;

        endDirector.Play();

        StartCoroutine(Destroy());
    }

    [SerializeField] string[] introTexts;

    int introIndex = -1;

    [SerializeField] string[] endTexts;

    int endIndex = -1;

    public void IntroText()
    {
        introIndex++;
        UIManager.ui.Console(true, introTexts[introIndex]);
    }

    public void EndText()
    {
        endIndex++;
        UIManager.ui.Console(true, endTexts[endIndex]);
    }

    public void IntroEnd()
    {
        UIManager.ui.Console(false);
    }

    IEnumerator Destroy()
    {
        foreach (var tile in FindObjectsOfType<Tile>())
        {
            yield return new WaitForSeconds(time);

            tile.gameObject.SetActive(false);
        }
        cutsceneCam.cullingMask = Layers.layers.cutscene;
    }
}