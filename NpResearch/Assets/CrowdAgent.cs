using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner;
using BehaviorDesigner.Runtime.Tasks;
using Sirenix.OdinInspector;

public class CrowdAgent : MonoBehaviour
{
    public BehaviorTree BehaviorTree;
    public int ActiveIndex;

    public List<CrowdAgentBehavior> CrowdAgentBehaviors = new List<CrowdAgentBehavior>();


    private void OnEnable()
    {
        ActiveIndex = 0;
        BehaviorTree.OnBehaviorEnd += CurrentTreeFinished;

    }

    private void OnDisable()
    {
        BehaviorTree.OnBehaviorEnd -= CurrentTreeFinished;

    }


    [Button]
    public void SetBehaviorAndPlay()
    {
        if(ActiveIndex < CrowdAgentBehaviors.Count)
        {
       

            BehaviorTree.ExternalBehavior = CrowdAgentBehaviors[ActiveIndex].ExternalBehaviorTree;
            

          //  Debug.Log("Play " + BehaviorTree.ExternalBehavior.name);

            if(CrowdAgentBehaviors[ActiveIndex].Target != null)
            {

                BehaviorTree.SetVariableValue("Target", CrowdAgentBehaviors[ActiveIndex].Target);


            }


            Debug.Log("Set waitTime to " + CrowdAgentBehaviors[ActiveIndex].WaitTime + " On " + BehaviorTree.ExternalBehavior.name);

           // BehaviorTree.ExternalBehavior.SetVariableValue("WaitTime", CrowdAgentBehaviors[ActiveIndex].WaitTime);
           BehaviorTree.SetVariableValue("WaitTime", CrowdAgentBehaviors[ActiveIndex].WaitTime);

           

            BehaviorTree.EnableBehavior();
        }
        else
        {
            Debug.Log("Trees finito breh so repeat");

            ActiveIndex = 0;

            SetBehaviorAndPlay();
        }

    }

    public void CurrentTreeFinished(Behavior source)
    {

        Debug.Log(
            BehaviorTree.ExternalBehavior.name + " tree finished");

        BehaviorTree.DisableBehavior();

        ActiveIndex++;

        SetBehaviorAndPlay();
    }

    //ADD code to this class to run the random farts etc- using MEC?
    //Most performant way?

}

[System.Serializable]
public class CrowdAgentBrain
{
    public List<AgentActionData> Behaviors = new List<AgentActionData>();

    //Attributes
    public bool Flammable;
    public bool Explosive;
    public bool HasVoice;
    public bool MirrorActor1Anims;
    public bool MirrorActor2Anims;
    public int AnimationSet;
    public bool RandomizesAnimations;
    public bool RandomBurps;
    public bool RandomFarts;
    public bool RandomDies;
    public bool RandomSpins;
    public bool RandomPuke;
    public bool RandomBleed;

    public List<string> VoiceAudioFilePaths = new List<string>();

    public bool RandomizeVoiceFilePitch;

}
