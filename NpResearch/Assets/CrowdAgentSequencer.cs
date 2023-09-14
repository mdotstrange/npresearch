using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner;
using Sirenix.OdinInspector;

public class CrowdAgentSequencer : MonoBehaviour
{
    public List<CrowdAgentBehavior> CrowdAgentBehaviors = new List<CrowdAgentBehavior>();

    public AgentActionData ActiveDataSelection;

    public void ReceiveActionData(AgentActionData theData, CrowdAgent crowdAgent)
    {

        CrowdAgentBehavior externalBehaviorTree = null;

        string target = string.Empty;
        string behaviorName = theData.BehaviorName;

        if (behaviorName == "End")
        {
            Debug.Log("LAst behavior so don't add");
            SequencingComplete(crowdAgent);
            return;
        }

        float waitTime = theData.WaitTime;



        foreach (var item in CrowdAgentBehaviors)
        {
            if (item.BehaviorName == behaviorName)
            {
                Debug.Log("Found tree! " + behaviorName);
                externalBehaviorTree = item;
                break;
            }
        }

        //get target if its gameObject is active

        if (theData.TargetName != "None" && theData.TargetName != string.Empty)
        {
            //use target if active
            target = theData.TargetName;

            if (target == "Actor1")
            {
                Debug.Log("Set target to Actor1");
                externalBehaviorTree.Target = null;

            }
            else if (target == "Actor2")
            {
                Debug.Log("Set target to Actor2");

                externalBehaviorTree.Target = null;

            }
            else if (target == "Randos")
            {
                Debug.Log("Set target to Randos");

                externalBehaviorTree.Target = null;

            }
            else if (target == "Agents")
            {
                Debug.Log("Set target to Agents");

                externalBehaviorTree.Target = null;

            }
            else
            {

            }
        }
        else
        {

        }




        if (waitTime != 0)
        {
            //set waitTime
            Debug.Log("Set wait as " + waitTime);
            externalBehaviorTree.WaitTime = waitTime;

        }

        if (externalBehaviorTree != null)
        {

            SequenceAgent(crowdAgent, externalBehaviorTree);

        }
        else
        {
            Debug.Log("Could not find tree! " + behaviorName);
        }

    }

    public void SequenceAgent(CrowdAgent agent, CrowdAgentBehavior tree)
    {
        Debug.Log("Add tree! " + tree.ExternalBehaviorTree.name);
        agent.CrowdAgentBehaviors.Add(tree);
    }

    public void SequencingComplete( CrowdAgent agent)
    {
        Debug.Log("Sequencing Complete");

        if (agent.CrowdAgentBehaviors.Count != 0)
        {
           // SelectedAgent.externalBehaviorTrees.Reverse();
            Debug.Log("Play trees");
            agent.SetBehaviorAndPlay();
        }
        else
        {
            Debug.Log("No trees to play!");
        }

      
    }

}

[System.Serializable]
public class CrowdAgentBehavior
{
    public string BehaviorName;
    public float WaitTime;
    public GameObject Target;
    public ExternalBehaviorTree ExternalBehaviorTree;
}

[System.Serializable]
public class CrowdActionSlot
{



}
