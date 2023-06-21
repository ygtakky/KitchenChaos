using System;
using Unity.Netcode;
using UnityEngine;

public class PlayerAnimator : NetworkBehaviour
{
   private const string IS_WALKING = "IsWalking";

   [SerializeField] private Player player;
   
   private Animator animator;
   
   private void Awake()
   {
      animator = GetComponent<Animator>();
      animator.SetBool(IS_WALKING, player.IsWalking());
   }

   private void Update()
   {
      if (!IsOwner) return;
   
      animator.SetBool(IS_WALKING, player.IsWalking());
   }
}
