using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Sirenix.OdinInspector;

public class DropdownHelper_Behavior : MonoBehaviour
{
    public TMP_Dropdown MyDropdown;
    public TMP_Dropdown TimeDropdown;
    public TMP_Dropdown TargetDropdown;

    public CrapCrowdSimConfig CrapCrowdSimConfig;

    public int EndIndex;

    public string _Target
    {
        get
        {
            string newTarget = Target;

            Target = string.Empty;

            return newTarget;
        }

        set
        {
            Target = value;
        }
    }

    public string Target;

    public float _Time
    {
        get
        {
            string newTime = Time;

            Time = string.Empty;

            float timeF = 0f;

            if(float.TryParse(newTime, out timeF))
            {
                return timeF;

            }
            else
            {
                return 0f;
            }

        }

        set
        {
            Time = value.ToString();
        }
    }

    public string Time;

    public List<int> MyBehaviorsWithTargets = new List<int>();

    

    public void ReceiveChange(int newValue)
    {
        if(MyBehaviorsWithTargets.Contains(newValue))
        {
            TargetDropdown.gameObject.SetActive(true);
        }
        else
        {
            TargetDropdown.gameObject.SetActive(false);

        }

        //7 is END
       if(newValue != EndIndex)
        {
            if (newValue != 0)
            {
                string MyIndex = gameObject.name;
                int myIndexInt = int.Parse(MyIndex);
                int nextIndex = myIndexInt + 1;

                if (nextIndex < CrapCrowdSimConfig.ActionSlots.Count)
                {
                    CrapCrowdSimConfig.ActionSlots[nextIndex].gameObject.SetActive(true);

                }

            }
        }
        else
        {
            TargetDropdown.gameObject.SetActive(false);
            TimeDropdown.gameObject.SetActive(false);
        }

   
    }

    public void ReceiveTarget(int value)
    {
        Debug.Log("Target = " + TargetDropdown.options[value].text);
        _Target = TargetDropdown.options[value].text;
    }

    public void ReceiveTime(int value)
    {
        Debug.Log("Time = " + TimeDropdown.options[value].text);
        _Time = float.Parse( TimeDropdown.options[value].text);
    }

    private void OnEnable()
    {
        EndIndex = MyDropdown.options.Count - 1;


        CrapCrowdSimConfig = GetComponentInParent<CrapCrowdSimConfig>();
        TimeDropdown.gameObject.SetActive(true);

        ReceiveChange(0);

    }
}

[System.Serializable]
public class AgentActionData
{
    public string BehaviorName;
    public float WaitTime;
    public string TargetName;


    public AgentActionData (string BName, float wTime, string Target)
    {
        BehaviorName = BName;
        WaitTime = wTime;
        TargetName = Target;
    
    }
}