using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // ← NECESARIO PARA CAMBIAR DE ESCENA

public class PuzzleManager : MonoBehaviour
{
    public PuzzleSlot[] slots;

    public void CheckPuzzle()
    {
        foreach (PuzzleSlot slot in slots)
        {
            if (slot.currentPiece == null) return;

            // PIEZA CORRECTA?
            if (slot.currentPiece.correctSlotIndex != slot.slotIndex)
            {
                Debug.Log("❌ Puzzle incorrecto");
                return;
            }
        }

        Debug.Log("🎉 Puzzle completado!");
    }

    // ✔ NUEVA FUNCIÓN PARA REGRESAR A LA ESCENA ANTERIOR
    public void RegresarAlJuego()
    {
        SceneManager.LoadScene("OpenGameScene");
    }
}

