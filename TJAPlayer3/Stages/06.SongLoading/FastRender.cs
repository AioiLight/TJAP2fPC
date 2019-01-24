using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FDK;

namespace TJAPlayer3
{
    class FastRender
    {
        public FastRender()
        {
            
        }

        public void Render()
        {
            for (int nPlayer = 0; nPlayer < TJAPlayer3.ConfigIni.nPlayerCount; nPlayer++)
            {
                for (int i = 0; i < TJAPlayer3.Skin.Game_Chara_Ptn_10combo[nPlayer]; i++)
                {
                    NullCheckAndRender(ref TJAPlayer3.Tx.Chara_10Combo[nPlayer][i]);
                }
                for (int i = 0; i < TJAPlayer3.Skin.Game_Chara_Ptn_10combo_Max[nPlayer]; i++)
                {
                    NullCheckAndRender(ref TJAPlayer3.Tx.Chara_10Combo_Maxed[nPlayer][i]);
                }
                for (int i = 0; i < TJAPlayer3.Skin.Game_Chara_Ptn_GoGoStart[nPlayer]; i++)
                {
                    NullCheckAndRender(ref TJAPlayer3.Tx.Chara_GoGoStart[nPlayer][i]);
                }
                for (int i = 0; i < TJAPlayer3.Skin.Game_Chara_Ptn_GoGoStart_Max[nPlayer]; i++)
                {
                    NullCheckAndRender(ref TJAPlayer3.Tx.Chara_GoGoStart_Maxed[nPlayer][i]);
                }
                for (int i = 0; i < TJAPlayer3.Skin.Game_Chara_Ptn_Normal[nPlayer]; i++)
                {
                    NullCheckAndRender(ref TJAPlayer3.Tx.Chara_Normal[nPlayer][i]);
                }
                for (int i = 0; i < TJAPlayer3.Skin.Game_Chara_Ptn_Clear[nPlayer]; i++)
                {
                    NullCheckAndRender(ref TJAPlayer3.Tx.Chara_Normal_Cleared[nPlayer][i]);
                }
                for (int i = 0; i < TJAPlayer3.Skin.Game_Chara_Ptn_ClearIn[nPlayer]; i++)
                {
                    NullCheckAndRender(ref TJAPlayer3.Tx.Chara_Become_Cleared[nPlayer][i]);
                }
                for (int i = 0; i < TJAPlayer3.Skin.Game_Chara_Ptn_SoulIn[nPlayer]; i++)
                {
                    NullCheckAndRender(ref TJAPlayer3.Tx.Chara_Become_Maxed[nPlayer][i]);
                }
                for (int i = 0; i < TJAPlayer3.Skin.Game_Chara_Ptn_Balloon_Breaking[nPlayer]; i++)
                {
                    NullCheckAndRender(ref TJAPlayer3.Tx.Chara_Balloon_Breaking[nPlayer][i]);
                }
                for (int i = 0; i < TJAPlayer3.Skin.Game_Chara_Ptn_Balloon_Broke[nPlayer]; i++)
                {
                    NullCheckAndRender(ref TJAPlayer3.Tx.Chara_Balloon_Broke[nPlayer][i]);
                }
                for (int i = 0; i < TJAPlayer3.Skin.Game_Chara_Ptn_Balloon_Miss[nPlayer]; i++)
                {
                    NullCheckAndRender(ref TJAPlayer3.Tx.Chara_Balloon_Miss[nPlayer][i]);
                }
            }

            for (int i = 0; i < 5; i++)
            {
                for (int k = 0; k < TJAPlayer3.Skin.Game_Dancer_Ptn; k++)
                {
                    NullCheckAndRender(ref TJAPlayer3.Tx.Dancer[i][k]);
                }
            }

            NullCheckAndRender(ref TJAPlayer3.Tx.Effects_GoGoSplash);
            NullCheckAndRender(ref TJAPlayer3.Tx.Runner);
            for (int i = 0; i < TJAPlayer3.Skin.Game_Mob_Ptn; i++)
            {
                NullCheckAndRender(ref TJAPlayer3.Tx.Mob[i]);
            }

            NullCheckAndRender(ref TJAPlayer3.Tx.PuchiChara);
            
        }

        private void NullCheckAndRender(ref CTexture tx)
        {
            if (tx == null) return;
            tx.n透明度 = 0;
            tx.t2D描画(TJAPlayer3.app.Device, 0, 0);
            tx.n透明度 = 255;
        }
    }
}
