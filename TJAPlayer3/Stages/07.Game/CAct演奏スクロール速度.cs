using System;
using System.Collections.Generic;
using System.Text;
using FDK;

namespace TJAPlayer3
{
	internal class CAct演奏スクロール速度 : CActivity
	{
		// プロパティ

		public STDGBVALUE<double>[] db現在の譜面スクロール速度;


		// コンストラクタ

		public CAct演奏スクロール速度()
		{
			base.b活性化してない = true;
		}


        // CActivity 実装

        public override void On活性化()
        {
            for (int i = 0; i < 3; i++)
            {
                n速度変更制御タイマ = new STDGBVALUE<long>[2];
                this.db現在の譜面スクロール速度 = new STDGBVALUE<double>[2];
                for (int nPlayer = 0; nPlayer < 2; nPlayer++)
                {
                    this.db現在の譜面スクロール速度[nPlayer][i] = (double)TJAPlayer3.ConfigIni.n譜面スクロール速度[nPlayer][i];
                    this.n速度変更制御タイマ[nPlayer][i] = -1;
                }
                base.On活性化();
            }
        }

        public override unsafe int On進行描画()
        {
            if (!base.b活性化してない)
            {
                if (base.b初めての進行描画)
                {
                    for (int nPlayer = 0; nPlayer < 2; nPlayer++)
                    {
                        this.n速度変更制御タイマ[nPlayer].Drums = this.n速度変更制御タイマ[nPlayer].Guitar = this.n速度変更制御タイマ[nPlayer].Bass = CSound管理.rc演奏用タイマ.n現在時刻;
                    }
                    base.b初めての進行描画 = false;
                }
                long n現在時刻 = CSound管理.rc演奏用タイマ.n現在時刻;
                for (int nPlayer = 0; nPlayer < 2; nPlayer++)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        double db譜面スクロールスピード = (double)TJAPlayer3.ConfigIni.n譜面スクロール速度[nPlayer][i];
                        if (n現在時刻 < this.n速度変更制御タイマ[nPlayer][i])
                        {
                            this.n速度変更制御タイマ[nPlayer][i] = n現在時刻;
                        }
                        while ((n現在時刻 - this.n速度変更制御タイマ[nPlayer][i]) >= 2)                               // 2msに1回ループ
                        {
                            if (this.db現在の譜面スクロール速度[nPlayer][i] < db譜面スクロールスピード)                // Config.iniのスクロール速度を変えると、それに追いつくように実画面のスクロール速度を変える
                            {
                                this.db現在の譜面スクロール速度[nPlayer][i] += 0.012;

                                if (this.db現在の譜面スクロール速度[nPlayer][i] > db譜面スクロールスピード)
                                {
                                    this.db現在の譜面スクロール速度[nPlayer][i] = db譜面スクロールスピード;
                                }
                            }
                            else if (this.db現在の譜面スクロール速度[nPlayer][i] > db譜面スクロールスピード)
                            {
                                this.db現在の譜面スクロール速度[nPlayer][i] -= 0.012;

                                if (this.db現在の譜面スクロール速度[nPlayer][i] < db譜面スクロールスピード)
                                {
                                    this.db現在の譜面スクロール速度[nPlayer][i] = db譜面スクロールスピード;
                                }
                            }
                            this.n速度変更制御タイマ[nPlayer][i] += 2;
                        }
                    }
                }
            }
            return 0;
        }

		// その他

		#region [ private ]
		//-----------------
		private STDGBVALUE<long>[] n速度変更制御タイマ;
		//-----------------
		#endregion
	}
}
