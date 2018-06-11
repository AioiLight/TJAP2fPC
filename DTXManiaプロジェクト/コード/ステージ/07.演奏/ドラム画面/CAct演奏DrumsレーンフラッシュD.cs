
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Drawing;
using FDK;

namespace DTXMania
{
	internal class CAct演奏DrumsレーンフラッシュD : CActivity
	{
		// コンストラクタ

		public CAct演奏DrumsレーンフラッシュD()
		{
			base.b活性化してない = true;
		}
		
		
		// メソッド

		public void Start( int nLane, float f強弱度合い, int player )
		{
			int num = (int) ( ( 1f - f強弱度合い ) * 55f );
            this.ct進行[ nLane + ( 3 * player ) ] = new CCounter( 0, 100, 2, CDTXMania.Timer );
            //if( nLane == 0 )
            //{
            //    this.ct進行[ 0 + ( 3 * player ) ] = new CCounter( 0, 100, 2, CDTXMania.Timer );
            //}
            //else if( nLane == 1 )
            //{
            //    this.ct進行[ 1 + ( 3 * player ) ] = new CCounter( 0, 100, 2, CDTXMania.Timer );
            //}
            //else if( nLane == 2 )
            //{
            //    this.ct進行[ 2 + ( 3 * player ) ] = new CCounter( 0, 100, 2, CDTXMania.Timer );
            //}
		}


		// CActivity 実装

		public override void On活性化()
		{
			for( int i = 0; i < 12; i++ )
			{
				this.ct進行[ i ] = new CCounter();
			}
			base.On活性化();
		}
		public override void On非活性化()
		{
			for( int i = 0; i < 12; i++ )
			{
				this.ct進行[ i ] = null;
			}
			base.On非活性化();
		}
		public override void OnManagedリソースの作成()
		{
			if( !base.b活性化してない )
			{
                //this.txRed = CDTXMania.tテクスチャの生成( CSkin.Path(@"Graphics\7_LaneFlush_Red.png") );
                //this.txBlue = CDTXMania.tテクスチャの生成( CSkin.Path(@"Graphics\7_LaneFlush_Blue.png") );
                //this.txYellow = CDTXMania.tテクスチャの生成( CSkin.Path(@"Graphics\7_LaneFlush_Yellow.png") );
				base.OnManagedリソースの作成();
			}
		}
		public override void OnManagedリソースの解放()
		{
			if( !base.b活性化してない )
			{
                //CDTXMania.tテクスチャの解放( ref this.txRed );
                //CDTXMania.tテクスチャの解放( ref this.txBlue );
                //CDTXMania.tテクスチャの解放( ref this.txYellow );
				base.OnManagedリソースの解放();
			}
		}
		public override int On進行描画()
		{
			if( !base.b活性化してない )
			{
				for( int i = 0; i < 12; i++ )
				{
					if( !this.ct進行[ i ].b停止中 )
					{
						this.ct進行[ i ].t進行();
						if( this.ct進行[ i ].b終了値に達した )
						{
							this.ct進行[ i ].t停止();
						}
					}
				}

                for( int i = 0; i < CDTXMania.ConfigIni.nPlayerCount; i++ )
                {
                    //レーンフラッシュ面
		    if( this.ct進行[ i * 3 ].b進行中 )
                    {
	                    int num8 = ( ( ( 150 - this.ct進行[i * 3].n現在の値 ) * 0xff ) / 100 );
					    if( CDTXMania.Tx.Lane_Red != null && CDTXMania.Tx.Lane_Yellow != null )
					    {
                            CDTXMania.Tx.Lane_Red.n透明度 = ( num8 );
                            CDTXMania.Tx.Lane_Red.t2D描画( CDTXMania.app.Device, 333, CDTXMania.Skin.nScrollFieldY[ i ] );
                            //CDTXMania.Tx.Lane_Yellow.n透明度 = ( num8 );
                            //CDTXMania.Tx.Lane_Yellow.t2D描画( CDTXMania.app.Device, 333, CDTXMania.Skin.nScrollFieldY[ i ] );
					    }
                    }
		    //レーンフラッシュ縁
                    if( this.ct進行[ 1 + ( i * 3 ) ].b進行中 )
                    {
	                    int num8 = ( ( ( 150 - this.ct進行[ 1 + ( i * 3 ) ].n現在の値 ) * 0xff ) / 100 );
					    if( CDTXMania.Tx.Lane_Blue != null && CDTXMania.Tx.Lane_Yellow != null )
					    {
                            CDTXMania.Tx.Lane_Blue.n透明度 = ( num8 );
                            CDTXMania.Tx.Lane_Blue.t2D描画( CDTXMania.app.Device, 333, CDTXMania.Skin.nScrollFieldY[ i ] );
                            //CDTXMania.Tx.Lane_Yellow.n透明度 = ( num8 );
                            //CDTXMania.Tx.Lane_Yellow.t2D描画( CDTXMania.app.Device, 333, CDTXMania.Skin.nScrollFieldY[ i ] );
					    }
                    }
		    //レーンフラッシュ連打
                    //if( this.ct進行[ 2 + ( i * 3 ) ].b進行中 )
                    //{
	            //        int num8 = ( ( ( 100 - this.ct進行[ 2 + ( i * 3 ) ].n現在の値 ) * 0xff ) / 100 );
			//		    if(CDTXMania.Tx.Lane_Yellow != null )
			//		    {
                    //        CDTXMania.Tx.Lane_Yellow.n透明度 = ( num8 );
                    //        CDTXMania.Tx.Lane_Yellow.t2D描画( CDTXMania.app.Device, 333, CDTXMania.Skin.nScrollFieldY[ i ] );
			//		    }
                    //}
                }


			}
			return 0;
		}

		
		// その他

		#region [ private ]
		//-----------------
		private CCounter[] ct進行 = new CCounter[ 3 * 4 ];
        //private CTexture txRed;
        //private CTexture txBlue;
        //private CTexture txYellow;
		//-----------------
		#endregion
	}
}
