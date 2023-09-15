using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Switch : MonoBehaviour, Minigame
{
    [SerializeField] string passcode;
    [SerializeField] GameObject[] buttons;
    [SerializeField] Sprite up;
    [SerializeField] Sprite down;

    [SerializeField] GameObject Indicator;
    [SerializeField] Sprite indicatorGreen;
    [SerializeField] Sprite indicatorRed;
    [SerializeField] Sprite indicatorOff;
    Interactable myInteractable = null;

    public void PressButton(string buttonInput) 
    {
        //G, B, Y, SwitchTop, SwitchBottom
        if(buttonInput == "SwitchTop")
        {
            flipSwitch();
            int i = CheckAnswer();
            UpdateIndicator(i);
        }
        if(buttonInput == "SwitchBottom")
        {
            flipSwitch();
            UpdateIndicator(0);
        }
    }

    void flipSwitch()
    {
        if(this.GetComponentInParent<Image>().sprite == up)
            this.GetComponentInParent<Image>().sprite = down;
        else
            this.GetComponentInParent<Image>().sprite = up;
    }

    int CheckAnswer()
    {
        for(int i = 0; i < passcode.Length; i++)    //checks to see if each color in the password was turned on
        {
            bool foundColor = false;
            foreach(GameObject b in buttons)
            {
                Button btn = b.GetComponent<Button>();
                //Debug.Log("Checking:"); Debug.Log(btn.getInput()); Debug.Log(passcode[i].ToString()); Debug.Log(btn.isUsed());
                if(btn.getInput() == passcode[i].ToString() && btn.isUsed())
                    foundColor = true;
            }
            if(!foundColor)
            {
                return 1;
            }
        }

        foreach(GameObject b in buttons)            //checks to make sure no additional buttons were on
        {
            bool wasSupposedToBeOn = false;
            bool wasOn = false;
            for(int i = 0; i < passcode.Length; i++)
            {
                Button btn = b.GetComponent<Button>();
                if(btn.getInput() == passcode[i].ToString())
                    wasSupposedToBeOn = true;
                if(btn.isUsed())
                    wasOn = true;
            }
            if(!wasSupposedToBeOn && wasOn)
            {
                return 1;
            }
        }

        return 2;
    }

    void UpdateIndicator(int i)
    {
        //0 = both off, 1 means red, 2 means green
        if(i == 0)
        {
            SendSignal(false);
            Indicator.GetComponent<Image>().sprite = indicatorOff;
        }
        if(i == 1)
        {
            SendSignal(false);
            Indicator.GetComponent<Image>().sprite = indicatorRed;
        }
        if(i == 2)
        {
            SendSignal(true);
            Indicator.GetComponent<Image>().sprite = indicatorGreen;
        }
    }

    public void MinigameTriggered(bool isActivated)
    {
        if(isActivated)
        {
            this.GetComponentInParent<Image>().sprite = down;
            Indicator.GetComponent<Image>().sprite = indicatorGreen;
        }
    }
    public void MinigameStopped()
    {
        Destroy(gameObject);
    }

    public void SendSignal(bool wasWon)
    {
        myInteractable.MinigameSwitched(wasWon);
    }
    public void setInteractable(Interactable i)
    {
        myInteractable = i;
    }
}
