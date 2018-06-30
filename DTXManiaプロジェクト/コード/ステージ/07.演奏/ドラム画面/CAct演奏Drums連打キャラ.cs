using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Runtime.InteropServices;
using SlimDX;
using FDK;

namespace DTXMania
{
	internal class CAct演奏Drums連打キャラ : CActivity
	{
		// コンストラクタ

		public CAct演奏Drums連打キャラ()
		{
			base.b活性化してない = true;
		}
		
		
		// メソッド
        public virtual void Start( int nLane )
		{
            if( CDTXMania.Tx.Effects_Roll[0] != null )
            {
                int[] arXseed = new int[] { 56, -10, 200, 345, 100, 451, 600, 260, -30, 534, 156, 363 };
                for (int i = 0; i < 1; i++)
                {
                    for (int j = 0; j < 64; j++)
                    {
                        if (!this.st連打キャラ[j].b使用中)
                        {
                            this.st連打キャラ[j].b使用中 = true;
                            if(this.nTex枚数 <= 1) this.st連打キャラ[j].nColor = 0;
                            else this.st連打キャラ[j].nColor = CDTXMania.Random.Next( 0, this.nTex枚数 - 1);
                            this.st連打キャラ[j].ct進行 = new CCounter( 0, 1000, 4, CDTXMania.Timer); // カウンタ

                            //位置生成(β版)
                            int nXseed = CDTXMania.Random.Next(12);
                            this.st連打キャラ[ j ].fX開始点 = arXseed[ nXseed ];
                            this.st連打キャラ[j].fX = arXseed[ nXseed ];
                            this.st連打キャラ[j].fY = 720;
                            this.st連打キャラ[j].fX加速度 = 5/2;
                            this.st連打キャラ[j].fY加速度 = 5/2;
                            break;
                        }
                    }
                }
            }
		}

		// CActivity 実装

		public override void On活性化()
		{
            for (int i = 0; i < 64; i++)
            {
                this.st連打キャラ[i] = new ST連打キャラ();
                this.st連打キャラ[i].b使用中 = false;
                this.st連打キャラ[i].ct進行 = new CCounter();
            }
            base.On活性化();
		}
		public override void On非活性化()
		{
            for (int i = 0; i < 64; i++)
            {
                this.st連打キャラ[i].ct進行 = null;
            }
			base.On非活性化();
		}
		public override void OnManagedリソースの作成()
		{
			if( !base.b活性化してない )
			{
                this.nTex枚数 = 4;
                //this.txChara = new CTexture[ this.nTex枚数 ];

                //for (int i = 0; i < this.nTex枚数; i++)
                //{
                //    this.txChara[ i ] = CDTXMania.tテクスチャの生成( CSkin.Path( @"Graphics\RollEffect\00\" + i.ToString() + ".png" ) );
                //}
				base.OnManagedリソースの作成();
			}
		}
		public override void OnManagedリソースの解放()
		{
			if( !base.b活性化してない )
			{
        //        for (int i = 0; i < this.nTex枚数; i++)
        //        {
				    //CDTXMania.tテクスチャの解放( ref this.txChara[ i ] );
        //        }
				base.OnManagedリソースの解放();
			}
		}
		public override int On進行描画()
		{
			if( !base.b活性化してない )
			{
                for( int i = 0; i < 64; i++ )
                {
                    if( this.st連打キャラ[i].b使用中 )
                    {
                        this.st連打キャラ[i].n前回のValue = this.st連打キャラ[i].ct進行.n現在の値;
                        this.st連打キャラ[i].ct進行.t進行();
                        if (this.st連打キャラ[i].ct進行.b終了値に達した)
                        {
                            this.st連打キャラ[i].ct進行.t停止();
                            this.st連打キャラ[i].b使用中 = false;
                        }
                        for (int n = this.st連打キャラ[i].n前回のValue; n < this.st連打キャラ[i].ct進行.n現在の値; n++)
                        {
                            this.st連打キャラ[i].fX += this.st連打キャラ[i].fX加速度;
                            this.st連打キャラ[i].fY -= this.st連打キャラ[i].fY加速度;
                        }

                        if(CDTXMania.Tx.Effects_Roll[ this.st連打キャラ[ i ].nColor ] != null )
                        {
                            CDTXMania.Tx.Effects_Roll[ this.st連打キャラ[ i ].nColor ].t2D描画( CDTXMania.app.Device, (int)this.st連打キャラ[i].fX, (int)this.st連打キャラ[i].fY, new Rectangle( this.st連打キャラ[i].nColor * 0, 0, 128, 128 ) );
                        }
                    }

                }
			}
			return 0;
		}
		

		// その他

		#region [ private ]
		//-----------------
        //private CTexture[] txChara;
        private int nTex枚数;

        [StructLayout(LayoutKind.Sequential)]
        private struct ST連打キャラ
        {
            public int nColor;
            public bool b使用中;
            public CCounter ct進行;
            public int n前回のValue;
            public float fX;
            public float fY;
            public float fX開始点;
            public float fY開始点;
            public float f進行方向; //進行方向 0:左→右 1:左下→右上 2:右→左
            public float fX加速度;
            public float fY加速度;
        }
        private ST連打キャラ[] st連打キャラ = new ST連打キャラ[64];
		//-----------------
		#endregion
	}
}
　
