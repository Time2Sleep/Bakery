using UnityEngine;

 public class Technics: MonoBehaviour
 {
     private Animator _animation;
     private bool isOpen = false;
     private void Start()
     {
         _animation = GetComponent<Animator>();
     }

     public void playAnimation()
     {
         if (isOpen)
         {
             isOpen = false;
             _animation.Play("Close");
         }
         else
         {
             isOpen = true;
             _animation.Play("Scene");
         }
     }
 }