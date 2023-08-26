using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class Hoe : Item, IMultipleUses
{
    public int Uses { get; set; }
    public int MaxUses { get; set; }

    public Hoe()
    {
        
    }


    public override void Use()
    {
        if (InteractionManager.Instance.SelectedItem != this)
            return;


        if (InteractionManager.Instance.SelectedTile is not IFertilizable tile)
        {
            InteractionManager.Instance.ResetSelectedItem();
            throw new InvalidOperationException("You can't use that here!");
        }


        tile.FertilizeTile();
        Uses--;


        if (Uses <= 0)
        {
            Debug.Log("Hoe broke!");
            Destroy();
        }

        base.Use();
    }

}