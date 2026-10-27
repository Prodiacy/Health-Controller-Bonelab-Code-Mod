using BoneLib;
using BoneLib.BoneMenu;
using Il2CppSLZ.Marrow.AI;
using MelonLoader;
using UnityEngine;
using UnityEngine.SceneManagement;

[assembly: MelonInfo(typeof(NPC_Health_Controller.ModMain), "NPC Health Controller", "1.0.0", "Prodiacy")]
[assembly: MelonGame("Stress Level Zero", "BONELAB")]

namespace NPC_Health_Controller
{
    public class ModMain : MelonMod
    {
        private bool sethealth = false;
        private int Health = 100;
        
        public override void OnInitializeMelon()
        {     
            LoggerInstance.Msg("Initialized.");
            
            Page page = Page.Root.CreatePage("NPC Health Controller", Color.red);
            page.CreateBool("Enable Custom Health", Color.red, startingValue: false, (value) => sethealth = value);
            page.CreateInt("Health", Color.red, startingValue: Health, increment:5, minValue:0, maxValue:2147483647, (value) => {Health = value;});
            page.CreateFunction("Set Health", Color.red, () => {SetHealth();});
        }
        private void SetHealth()
        {
            AIBrain[] ai = Object.FindObjectsOfType<AIBrain>();
            if(ai.Length > 0)
            {
                foreach(AIBrain i in ai)
                {
                    i.behaviour.health.cur_hp = Health;
                }
            }

            
        }

        
    }
}
