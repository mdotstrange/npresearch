using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using BehaviorDesigner;

public class CrapCrowdSimConfig : MonoBehaviour
{
    public List<DropdownHelper_Behavior> ActionSlots = new List<DropdownHelper_Behavior>();
    public CrowdAgentSequencer CrowdAgentSequencer;


    //Load in vrm to use as CrowdAgent + add components etc

    public GameObject CrowdAgentPrefab;


    //get this by doing GetComponent on SpawnedAgent
    public CrowdAgent TargetCrowdAgent;

    //user sets this
    public int CrowdAgentCount;


    public List<string> ActionNames = new List<string>();
    public List<string> Targets = new List<string>();
    public List<string> WaitTimes = new List<string>();

    private void OnEnable()
    {
        foreach (var item in ActionSlots)
        {

            item.gameObject.SetActive(false);
        }

        ActionSlots[0].gameObject.SetActive(true);

        Targets.Clear();
        WaitTimes.Clear();

        foreach (var item in ActionSlots[0].TargetDropdown.options)
        {
            Targets.Add(item.text);
        }

        foreach (var item in ActionSlots[0].TimeDropdown.options)
        {
            WaitTimes.Add(item.text);
        }

        foreach (var item in ActionSlots[0].MyDropdown.options)
        {
            ActionNames.Add(item.text);
        }

    }


    [Button]
    public void SendDropdownsToSequencer()
    {
        TargetCrowdAgent.CrowdAgentBehaviors.Clear();


        //Loops through Dropdowns and makes AgentActionData
        foreach (var item in ActionSlots)
        {
            if (item.MyDropdown.value != 0)
            {

                var Bname = item.MyDropdown.options[item.MyDropdown.value].text;

                var wTime = 0f;
                var targo = string.Empty;


                if (Bname != "End")
                {
                     wTime = item._Time;
                     targo = item._Target;

                }


                var newData = new AgentActionData(Bname,wTime,targo);

                CrowdAgentSequencer.ReceiveActionData(newData, TargetCrowdAgent);

            }
        }

        CrowdAgentSequencer.SequencingComplete(TargetCrowdAgent);
    }



}