using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//by Frieder
public class TutorialController : MonoBehaviour
{
    //UI components
    public GameObject screen;
    public TextMeshProUGUI textfield;

    //Prefab references
    public GameObject waterdrop;
    public GameObject wood;
    public GameObject stone;
    public GameObject coin;
    public GameObject heart;
    public GameObject miniboss;

    //States for the state machine
    public TutorialBaseState tutorial_state;
    public TutorialState1 tutorial_state_1 = new();
    public TutorialState2 tutorial_state_2 = new();
    public TutorialState3 tutorial_state_3 = new();
    public TutorialState4 tutorial_state_4 = new();
    public TutorialState5 tutorial_state_5 = new();
    public TutorialState6 tutorial_state_6 = new();
    public TutorialStateEND tutorial_state_end = new();
    // Start is called before the first frame update
    void Start()
    {
        tutorial_state = tutorial_state_1;
        tutorial_state.StateEnter(this);
    }

    // Update is called once per frame
    void Update()
    {
        tutorial_state.StateUpdate(this);
    }
}
