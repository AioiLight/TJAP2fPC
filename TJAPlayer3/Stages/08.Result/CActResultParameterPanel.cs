using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Drawing;
using System.IO;
using SlimDX;
using FDK;

namespace TJAPlayer3
{
	internal class CActResultParameterPanel : CActivity
	{
		// コンストラクタ

		public CActResultParameterPanel()
		{
			ST文字位置[] st文字位置Array = new ST文字位置[ 11 ];
			ST文字位置 st文字位置 = new ST文字位置();
			st文字位置.ch = '0';
			st文字位置.pt = new Point( 0, 0 );
			st文字位置Array[ 0 ] = st文字位置;
			ST文字位置 st文字位置2 = new ST文字位置();
			st文字位置2.ch = '1';
			st文字位置2.pt = new Point( 32, 0 );
			st文字位置Array[ 1 ] = st文字位置2;
			ST文字位置 st文字位置3 = new ST文字位置();
			st文字位置3.ch = '2';
			st文字位置3.pt = new Point( 64, 0 );
			st文字位置Array[ 2 ] = st文字位置3;
			ST文字位置 st文字位置4 = new ST文字位置();
			st文字位置4.ch = '3';
			st文字位置4.pt = new Point( 96, 0 );
			st文字位置Array[ 3 ] = st文字位置4;
			ST文字位置 st文字位置5 = new ST文字位置();
			st文字位置5.ch = '4';
			st文字位置5.pt = new Point( 128, 0 );
			st文字位置Array[ 4 ] = st文字位置5;
			ST文字位置 st文字位置6 = new ST文字位置();
			st文字位置6.ch = '5';
			st文字位置6.pt = new Point( 160, 0 );
			st文字位置Array[ 5 ] = st文字位置6;
			ST文字位置 st文字位置7 = new ST文字位置();
			st文字位置7.ch = '6';
			st文字位置7.pt = new Point( 192, 0 );
			st文字位置Array[ 6 ] = st文字位置7;
			ST文字位置 st文字位置8 = new ST文字位置();
			st文字位置8.ch = '7';
			st文字位置8.pt = new Point( 224, 0 );
			st文字位置Array[ 7 ] = st文字位置8;
			ST文字位置 st文字位置9 = new ST文字位置();
			st文字位置9.ch = '8';
			st文字位置9.pt = new Point( 256, 0 );
			st文字位置Array[ 8 ] = st文字位置9;
			ST文字位置 st文字位置10 = new ST文字位置();
			st文字位置10.ch = '9';
			st文字位置10.pt = new Point( 288, 0 );
			st文字位置Array[ 9 ] = st文字位置10;
			ST文字位置 st文字位置11 = new ST文字位置();
			st文字位置11.ch = ' ';
			st文字位置11.pt = new Point( 0, 0 );
			st文字位置Array[ 10 ] = st文字位置11;
			this.st小文字位置 = st文字位置Array;

			ST文字位置[] st文字位置Array2 = new ST文字位置[ 11 ];
			ST文字位置 st文字位置12 = new ST文字位置();
			st文字位置12.ch = '0';
			st文字位置12.pt = new Point( 0, 0 );
			st文字位置Array2[ 0 ] = st文字位置12;
			ST文字位置 st文字位置13 = new ST文字位置();
			st文字位置13.ch = '1';
			st文字位置13.pt = new Point( 32, 0 );
			st文字位置Array2[ 1 ] = st文字位置13;
			ST文字位置 st文字位置14 = new ST文字位置();
			st文字位置14.ch = '2';
			st文字位置14.pt = new Point( 64, 0 );
			st文字位置Array2[ 2 ] = st文字位置14;
			ST文字位置 st文字位置15 = new ST文字位置();
			st文字位置15.ch = '3';
			st文字位置15.pt = new Point( 96, 0 );
			st文字位置Array2[ 3 ] = st文字位置15;
			ST文字位置 st文字位置16 = new ST文字位置();
			st文字位置16.ch = '4';
			st文字位置16.pt = new Point( 128, 0 );
			st文字位置Array2[ 4 ] = st文字位置16;
			ST文字位置 st文字位置17 = new ST文字位置();
			st文字位置17.ch = '5';
			st文字位置17.pt = new Point( 160, 0 );
			st文字位置Array2[ 5 ] = st文字位置17;
			ST文字位置 st文字位置18 = new ST文字位置();
			st文字位置18.ch = '6';
			st文字位置18.pt = new Point( 192, 0 );
			st文字位置Array2[ 6 ] = st文字位置18;
			ST文字位置 st文字位置19 = new ST文字位置();
			st文字位置19.ch = '7';
			st文字位置19.pt = new Point( 224, 0 );
			st文字位置Array2[ 7 ] = st文字位置19;
			ST文字位置 st文字位置20 = new ST文字位置();
			st文字位置20.ch = '8';
			st文字位置20.pt = new Point( 256, 0 );
			st文字位置Array2[ 8 ] = st文字位置20;
			ST文字位置 st文字位置21 = new ST文字位置();
			st文字位置21.ch = '9';
			st文字位置21.pt = new Point( 288, 0 );
			st文字位置Array2[ 9 ] = st文字位置21;
			ST文字位置 st文字位置22 = new ST文字位置();
			st文字位置22.ch = '%';
			st文字位置22.pt = new Point( 0x37, 0 );
			st文字位置Array2[ 10 ] = st文字位置22;
			this.st大文字位置 = st文字位置Array2;

            ST文字位置[] stScore文字位置Array = new ST文字位置[10];
            ST文字位置 stScore文字位置 = new ST文字位置();
            stScore文字位置.ch = '0';
            stScore文字位置.pt = new Point(0, 0);
            stScore文字位置Array[0] = stScore文字位置;
            ST文字位置 stScore文字位置2 = new ST文字位置();
            stScore文字位置2.ch = '1';
            stScore文字位置2.pt = new Point(24, 0);
            stScore文字位置Array[1] = stScore文字位置2;
            ST文字位置 stScore文字位置3 = new ST文字位置();
            stScore文字位置3.ch = '2';
            stScore文字位置3.pt = new Point(48, 0);
            stScore文字位置Array[2] = stScore文字位置3;
            ST文字位置 stScore文字位置4 = new ST文字位置();
            stScore文字位置4.ch = '3';
            stScore文字位置4.pt = new Point(72, 0);
            stScore文字位置Array[3] = stScore文字位置4;
            ST文字位置 stScore文字位置5 = new ST文字位置();
            stScore文字位置5.ch = '4';
            stScore文字位置5.pt = new Point(96, 0);
            stScore文字位置Array[4] = stScore文字位置5;
            ST文字位置 stScore文字位置6 = new ST文字位置();
            stScore文字位置6.ch = '5';
            stScore文字位置6.pt = new Point(120, 0);
            stScore文字位置Array[5] = stScore文字位置6;
            ST文字位置 stScore文字位置7 = new ST文字位置();
            stScore文字位置7.ch = '6';
            stScore文字位置7.pt = new Point(144, 0);
            stScore文字位置Array[6] = stScore文字位置7;
            ST文字位置 stScore文字位置8 = new ST文字位置();
            stScore文字位置8.ch = '7';
            stScore文字位置8.pt = new Point(168, 0);
            stScore文字位置Array[7] = stScore文字位置8;
            ST文字位置 stScore文字位置9 = new ST文字位置();
            stScore文字位置9.ch = '8';
            stScore文字位置9.pt = new Point(192, 0);
            stScore文字位置Array[8] = stScore文字位置9;
            ST文字位置 stScore文字位置10 = new ST文字位置();
            stScore文字位置10.ch = '9';
            stScore文字位置10.pt = new Point(216, 0);
            stScore文字位置Array[9] = stScore文字位置10;
            this.stScoreFont = stScore文字位置Array;



			this.ptFullCombo位置 = new Point[] { new Point( 0x80, 0xed ), new Point( 0xdf, 0xed ), new Point( 0x141, 0xed ) };
			base.b活性化してない = true;
		}


		// メソッド

		public void tアニメを完了させる()
		{
			this.ct表示用.n現在の値 = this.ct表示用.n終了値;
		}


		// CActivity 実装

		public override void On活性化()
		{
			this.sdDTXで指定されたフルコンボ音 = null;
			this.bフルコンボ音再生済み = false;
			base.On活性化();
		}
		public override void On非活性化()
		{
			if( this.ct表示用 != null )
			{
				this.ct表示用 = null;
			}
			if( this.sdDTXで指定されたフルコンボ音 != null )
			{
				TJAPlayer3.Sound管理.tサウンドを破棄する( this.sdDTXで指定されたフルコンボ音 );
				this.sdDTXで指定されたフルコンボ音 = null;
			}
			base.On非活性化();
		}
		public override void OnManagedリソースの作成()
		{
			if( !base.b活性化してない )
			{
                Dan_Plate = TJAPlayer3.tテクスチャの生成(Path.GetDirectoryName(TJAPlayer3.DTX[0].strファイル名の絶対パス) + @"\Dan_Plate.png");
                base.OnManagedリソースの作成();
			}
		}
		public override void OnManagedリソースの解放()
		{
			if( !base.b活性化してない )
			{
                Dan_Plate?.Dispose();
                base.OnManagedリソースの解放();
			}
		}
		public override int On進行描画()
		{
			if( base.b活性化してない )
			{
				return 0;
			}
			if( base.b初めての進行描画 )
			{
				this.ct表示用 = new CCounter( 0, 0x3e7, 2, TJAPlayer3.Timer );
				base.b初めての進行描画 = false;
			}
			this.ct表示用.t進行();
			if(TJAPlayer3.Tx.Result_Panel != null )
			{
                TJAPlayer3.Tx.Result_Panel.t2D描画( TJAPlayer3.app.Device, TJAPlayer3.Skin.nResultPanelP1X, TJAPlayer3.Skin.nResultPanelP1Y );
			}
			if(TJAPlayer3.Tx.Result_Score_Text != null )
			{
                TJAPlayer3.Tx.Result_Score_Text.t2D描画( TJAPlayer3.app.Device, 753, 249 ); //点
			}
            if(TJAPlayer3.Tx.Result_Judge != null )
            {
                TJAPlayer3.Tx.Result_Judge.t2D描画( TJAPlayer3.app.Device, TJAPlayer3.Skin.nResultJudge1_P1X, TJAPlayer3.Skin.nResultJudge1_P1Y );
            }
            if(TJAPlayer3.Tx.Result_Judge != null )
            {
                //CDTXMania.Tx.Result_Judge.t2D描画( CDTXMania.app.Device, CDTXMania.Skin.nResultJudge2_P1X, CDTXMania.Skin.nResultJudge2_P1Y );
            }
            if(TJAPlayer3.Tx.Result_Gauge_Base != null && TJAPlayer3.Tx.Result_Gauge != null )
            {
                //int nRectX = (int)( CDTXMania.stage結果.st演奏記録.Drums.fゲージ / 2) * 12;
                double Rate = TJAPlayer3.stage結果.st演奏記録.Drums.fゲージ;
                //nRectX = CDTXMania.stage結果.st演奏記録.Drums.fゲージ >= 80.0f ? 80 : nRectX;
                TJAPlayer3.Tx.Result_Gauge_Base.t2D描画( TJAPlayer3.app.Device, TJAPlayer3.Skin.nResultGaugeBaseP1X, TJAPlayer3.Skin.nResultGaugeBaseP1Y, new Rectangle( 0, 0, 691, 47 ) );
                #region[ ゲージ本体 ]
                if( Rate > 2 )
                    TJAPlayer3.Tx.Result_Gauge.t2D描画( TJAPlayer3.app.Device, 559, 145, new Rectangle( 0, 20, 12, 20 ) );
                if( Rate > 4 )
                    TJAPlayer3.Tx.Result_Gauge.t2D描画( TJAPlayer3.app.Device, 559 + 12, 145, new Rectangle( 0, 20, 12, 20 ) );
                if( Rate > 6 )
                    TJAPlayer3.Tx.Result_Gauge.t2D描画( TJAPlayer3.app.Device, 559 + 24, 145, new Rectangle( 0, 20, 12, 20 ) );
                if( Rate > 8 )
                    TJAPlayer3.Tx.Result_Gauge.t2D描画( TJAPlayer3.app.Device, 559 + 36, 145, new Rectangle( 12, 20, 13, 20 ) );
                if( Rate > 10 )
                    TJAPlayer3.Tx.Result_Gauge.t2D描画( TJAPlayer3.app.Device, 559 + 49, 145, new Rectangle( 12, 20, 13, 20 ) );
                if( Rate > 12 )
                    TJAPlayer3.Tx.Result_Gauge.t2D描画( TJAPlayer3.app.Device, 559 + 62, 145, new Rectangle( 0, 20, 12, 20 ) );
                if( Rate > 14 )
                    TJAPlayer3.Tx.Result_Gauge.t2D描画( TJAPlayer3.app.Device, 559 + 74, 145, new Rectangle( 0, 20, 12, 20 ) );
                if( Rate > 16 )
                    TJAPlayer3.Tx.Result_Gauge.t2D描画( TJAPlayer3.app.Device, 559 + 86, 145, new Rectangle( 12, 20, 13, 20 ) );
                if( Rate > 18 )
                    TJAPlayer3.Tx.Result_Gauge.t2D描画( TJAPlayer3.app.Device, 559 + 99, 145, new Rectangle( 12, 20, 13, 20 ) );
                if( Rate > 20 )
                    TJAPlayer3.Tx.Result_Gauge.t2D描画( TJAPlayer3.app.Device, 559 + 112, 145, new Rectangle( 12, 20, 13, 20 ) );
                if( Rate > 22 )
                    TJAPlayer3.Tx.Result_Gauge.t2D描画( TJAPlayer3.app.Device, 559 + 125, 145, new Rectangle( 12, 20, 13, 20 ) );
                if( Rate > 24 )
                    TJAPlayer3.Tx.Result_Gauge.t2D描画( TJAPlayer3.app.Device, 559 + 138, 145, new Rectangle( 0, 20, 12, 20 ) );
                if( Rate > 26 )
                    TJAPlayer3.Tx.Result_Gauge.t2D描画( TJAPlayer3.app.Device, 559 + 150, 145, new Rectangle( 0, 20, 12, 20 ) );
                if( Rate > 28 )
                    TJAPlayer3.Tx.Result_Gauge.t2D描画( TJAPlayer3.app.Device, 559 + 162, 145, new Rectangle( 12, 20, 13, 20 ) );
                if( Rate > 30 )
                    TJAPlayer3.Tx.Result_Gauge.t2D描画( TJAPlayer3.app.Device, 559 + 175, 145, new Rectangle( 0, 20, 12, 20 ) );
                if( Rate > 32 )
                    TJAPlayer3.Tx.Result_Gauge.t2D描画( TJAPlayer3.app.Device, 559 + 187, 145, new Rectangle( 12, 20, 13, 20 ) );
                if( Rate > 34 )
                    TJAPlayer3.Tx.Result_Gauge.t2D描画( TJAPlayer3.app.Device, 559 + 200, 145, new Rectangle( 0, 20, 12, 20 ) );
                if( Rate > 36 )
                    TJAPlayer3.Tx.Result_Gauge.t2D描画( TJAPlayer3.app.Device, 559 + 212, 145, new Rectangle( 12, 20, 13, 20 ) );
                if( Rate > 38 )
                    TJAPlayer3.Tx.Result_Gauge.t2D描画( TJAPlayer3.app.Device, 559 + 225, 145, new Rectangle( 12, 20, 13, 20 ) );
                if( Rate > 40 )
                    TJAPlayer3.Tx.Result_Gauge.t2D描画( TJAPlayer3.app.Device, 559 + 238, 145, new Rectangle( 12, 20, 13, 20 ) );
                if( Rate > 42 )
                    TJAPlayer3.Tx.Result_Gauge.t2D描画( TJAPlayer3.app.Device, 559 + 251, 145, new Rectangle( 0, 20, 12, 20 ) );
                if( Rate > 44 )
                    TJAPlayer3.Tx.Result_Gauge.t2D描画( TJAPlayer3.app.Device, 559 + 263, 145, new Rectangle( 12, 20, 13, 20 ) );
                if( Rate > 46 )
                    TJAPlayer3.Tx.Result_Gauge.t2D描画( TJAPlayer3.app.Device, 559 + 276, 145, new Rectangle( 0, 20, 12, 20 ) );
                if( Rate > 48 )
                    TJAPlayer3.Tx.Result_Gauge.t2D描画( TJAPlayer3.app.Device, 559 + 288, 145, new Rectangle( 12, 20, 13, 20 ) );
                if( Rate > 50 )
                    TJAPlayer3.Tx.Result_Gauge.t2D描画( TJAPlayer3.app.Device, 559 + 301, 145, new Rectangle( 0, 20, 12, 20 ) );
                if( Rate > 52 )
                    TJAPlayer3.Tx.Result_Gauge.t2D描画( TJAPlayer3.app.Device, 559 + 313, 145, new Rectangle( 12, 20, 13, 20 ) );
                if( Rate > 54 )
                    TJAPlayer3.Tx.Result_Gauge.t2D描画( TJAPlayer3.app.Device, 559 + 326, 145, new Rectangle( 12, 20, 13, 20 ) );
                if( Rate > 56 )
                    TJAPlayer3.Tx.Result_Gauge.t2D描画( TJAPlayer3.app.Device, 559 + 339, 145, new Rectangle( 12, 20, 13, 20 ) );
                if( Rate > 58 )
                    TJAPlayer3.Tx.Result_Gauge.t2D描画( TJAPlayer3.app.Device, 559 + 352, 145, new Rectangle( 0, 20, 12, 20 ) );
                if( Rate > 60 )
                    TJAPlayer3.Tx.Result_Gauge.t2D描画( TJAPlayer3.app.Device, 559 + 364, 145, new Rectangle( 12, 20, 13, 20 ) );
                if( Rate > 62 )
                    TJAPlayer3.Tx.Result_Gauge.t2D描画( TJAPlayer3.app.Device, 559 + 377, 145, new Rectangle( 12, 20, 13, 20 ) );
                if( Rate > 64 )
                    TJAPlayer3.Tx.Result_Gauge.t2D描画( TJAPlayer3.app.Device, 559 + 390, 145, new Rectangle( 0, 20, 12, 20 ) );
                if( Rate > 66 )
                    TJAPlayer3.Tx.Result_Gauge.t2D描画( TJAPlayer3.app.Device, 559 + 402, 145, new Rectangle( 12, 20, 13, 20 ) );
                if( Rate > 68 )
                    TJAPlayer3.Tx.Result_Gauge.t2D描画( TJAPlayer3.app.Device, 559 + 415, 145, new Rectangle( 0, 20, 12, 20 ) );
                if( Rate > 70 )
                    TJAPlayer3.Tx.Result_Gauge.t2D描画( TJAPlayer3.app.Device, 559 + 427, 145, new Rectangle( 12, 20, 13, 20 ) );
                if( Rate > 72 )
                    TJAPlayer3.Tx.Result_Gauge.t2D描画( TJAPlayer3.app.Device, 559 + 440, 145, new Rectangle( 0, 20, 12, 20 ) );
                if( Rate > 74 )
                    TJAPlayer3.Tx.Result_Gauge.t2D描画( TJAPlayer3.app.Device, 559 + 452, 145, new Rectangle( 12, 20, 13, 20 ) );
                if( Rate > 76 )
                    TJAPlayer3.Tx.Result_Gauge.t2D描画( TJAPlayer3.app.Device, 559 + 465, 145, new Rectangle( 12, 20, 13, 20 ) );
                if( Rate > 78 )
                    TJAPlayer3.Tx.Result_Gauge.t2D描画( TJAPlayer3.app.Device, 559 + 478, 145, new Rectangle( 12, 20, 13, 20 ) );

                if( Rate > 80 )
                    TJAPlayer3.Tx.Result_Gauge.t2D描画( TJAPlayer3.app.Device, 559 + 491, 125, new Rectangle( 25, 0, 12, 40 ) );
                if( Rate > 82 )
                    TJAPlayer3.Tx.Result_Gauge.t2D描画( TJAPlayer3.app.Device, 559 + 503, 125, new Rectangle( 49, 0, 13, 40 ) );
                if( Rate > 84 )
                    TJAPlayer3.Tx.Result_Gauge.t2D描画( TJAPlayer3.app.Device, 559 + 516, 125, new Rectangle( 37, 0, 12, 40 ) );
                if( Rate > 86 )
                    TJAPlayer3.Tx.Result_Gauge.t2D描画( TJAPlayer3.app.Device, 559 + 528, 125, new Rectangle( 49, 0, 13, 40 ) );
                if( Rate > 88 )
                    TJAPlayer3.Tx.Result_Gauge.t2D描画( TJAPlayer3.app.Device, 559 + 541, 125, new Rectangle( 37, 0, 12, 40 ) );
                if( Rate > 90 )
                    TJAPlayer3.Tx.Result_Gauge.t2D描画( TJAPlayer3.app.Device, 559 + 553, 125, new Rectangle( 49, 0, 13, 40 ) );
                if( Rate > 92 )
                    TJAPlayer3.Tx.Result_Gauge.t2D描画( TJAPlayer3.app.Device, 559 + 566, 125, new Rectangle( 49, 0, 13, 40 ) );
                if( Rate > 94 )
                    TJAPlayer3.Tx.Result_Gauge.t2D描画( TJAPlayer3.app.Device, 559 + 579, 125, new Rectangle( 37, 0, 12, 40 ) );
                if( Rate > 96 )
                    TJAPlayer3.Tx.Result_Gauge.t2D描画( TJAPlayer3.app.Device, 559 + 591, 125, new Rectangle( 49, 0, 13, 40 ) );
                if( Rate > 98 )
                    TJAPlayer3.Tx.Result_Gauge.t2D描画( TJAPlayer3.app.Device, 559 + 604, 125, new Rectangle( 37, 0, 12, 40 ) );
                if( Rate > 100 )
                    TJAPlayer3.Tx.Result_Gauge.t2D描画( TJAPlayer3.app.Device, 559 + 616, 125, new Rectangle( 49, 0, 10, 40 ) );

                #endregion
            }
            if(TJAPlayer3.Tx.Gauge_Soul != null )
            {
                if(TJAPlayer3.Tx.Gauge_Soul_Fire != null && TJAPlayer3.stage結果.st演奏記録.Drums.fゲージ >= 100.0f )
                    TJAPlayer3.Tx.Gauge_Soul_Fire.t2D描画( TJAPlayer3.app.Device, 1100, 34, new Rectangle( 0, 0, 230, 230 ) );
                TJAPlayer3.Tx.Gauge_Soul.t2D描画( TJAPlayer3.app.Device, 1174, 107, new Rectangle( 0, 0, 80, 80 ) );
            }
            //演奏中のやつ使いまわせなかった。ファック。
            this.tスコア文字表示( TJAPlayer3.Skin.nResultScoreP1X, TJAPlayer3.Skin.nResultScoreP1Y, string.Format( "{0,7:######0}",TJAPlayer3.stage結果.st演奏記録.Drums.nスコア ) );
            this.t小文字表示( TJAPlayer3.Skin.nResultGreatP1X, TJAPlayer3.Skin.nResultGreatP1Y, string.Format( "{0,4:###0}", TJAPlayer3.stage結果.st演奏記録.Drums.nPerfect数.ToString() ) );
            this.t小文字表示( TJAPlayer3.Skin.nResultGoodP1X, TJAPlayer3.Skin.nResultGoodP1Y, string.Format( "{0,4:###0}", TJAPlayer3.stage結果.st演奏記録.Drums.nGreat数.ToString() ) );
            this.t小文字表示( TJAPlayer3.Skin.nResultBadP1X, TJAPlayer3.Skin.nResultBadP1Y, string.Format( "{0,4:###0}", TJAPlayer3.stage結果.st演奏記録.Drums.nMiss数.ToString() ) );

            this.t小文字表示( TJAPlayer3.Skin.nResultComboP1X, TJAPlayer3.Skin.nResultComboP1Y, string.Format( "{0,4:###0}", TJAPlayer3.stage結果.st演奏記録.Drums.n最大コンボ数.ToString() ) );
            this.t小文字表示( TJAPlayer3.Skin.nResultRollP1X, TJAPlayer3.Skin.nResultRollP1Y, string.Format( "{0,4:###0}", TJAPlayer3.stage結果.st演奏記録.Drums.n連打数.ToString() ) );
            //CDTXMania.act文字コンソール.tPrint( 960, 200, C文字コンソール.Eフォント種別.白, string.Format( "{0,4:###0}",CDTXMania.stage結果.st演奏記録.Drums.nPerfect数.ToString()) );
            //CDTXMania.act文字コンソール.tPrint( 960, 236, C文字コンソール.Eフォント種別.白, string.Format( "{0,4:###0}",CDTXMania.stage結果.st演奏記録.Drums.nGreat数.ToString()) );
            //CDTXMania.act文字コンソール.tPrint( 960, 276, C文字コンソール.Eフォント種別.白, string.Format( "{0,4:###0}",CDTXMania.stage結果.st演奏記録.Drums.nMiss数.ToString()) );

            //CDTXMania.act文字コンソール.tPrint( 1150, 200, C文字コンソール.Eフォント種別.白, string.Format( "{0,4:###0}",CDTXMania.stage結果.st演奏記録.Drums.n最大コンボ数.ToString()) );
			int num = this.ct表示用.n現在の値;

            //this.txプレイヤーナンバー.t2D描画(CDTXMania.app.Device, 254, 93);
            //this.txネームプレート.t2D描画( CDTXMania.app.Device, 254, 93 );

            #region 段位認定モード用
            if(TJAPlayer3.stage選曲.nSeelectedCource[0] == (int)Difficulty.Dan)
            {
                TJAPlayer3.stage演奏ドラム画面.actDan.DrawExam(TJAPlayer3.stage結果.st演奏記録.Drums.Dan_C);
                switch (TJAPlayer3.stage演奏ドラム画面.actDan.GetExamStatus(TJAPlayer3.stage結果.st演奏記録.Drums.Dan_C))
                {
                    case global::TJAPlayer3.Exam.Status.Failure:
                        TJAPlayer3.Tx.Result_Dan.t2D描画(TJAPlayer3.app.Device, TJAPlayer3.Skin.Result_Dan_XY[0], TJAPlayer3.Skin.Result_Dan_XY[1], new Rectangle(0, 0, TJAPlayer3.Skin.Result_Dan[0], TJAPlayer3.Skin.Result_Dan[1]));
                        break;
                    case global::TJAPlayer3.Exam.Status.Success:
                        TJAPlayer3.Tx.Result_Dan.t2D描画(TJAPlayer3.app.Device, TJAPlayer3.Skin.Result_Dan_XY[0], TJAPlayer3.Skin.Result_Dan_XY[1], new Rectangle(TJAPlayer3.Skin.Result_Dan[0], 0, TJAPlayer3.Skin.Result_Dan[0], TJAPlayer3.Skin.Result_Dan[1]));
                        break;
                    case global::TJAPlayer3.Exam.Status.Better_Success:
                        TJAPlayer3.Tx.Result_Dan.t2D描画(TJAPlayer3.app.Device, TJAPlayer3.Skin.Result_Dan_XY[0], TJAPlayer3.Skin.Result_Dan_XY[1], new Rectangle(TJAPlayer3.Skin.Result_Dan[0] * 2, 0, TJAPlayer3.Skin.Result_Dan[0], TJAPlayer3.Skin.Result_Dan[1]));
                        break;
                    default:
                        break;
                }
                // Dan_Plate
                Dan_Plate?.t2D中心基準描画(TJAPlayer3.app.Device, TJAPlayer3.Skin.Result_Dan_Plate_XY[0], TJAPlayer3.Skin.Result_Dan_Plate_XY[1]);
            }
            #endregion


            if ( !this.ct表示用.b終了値に達した )
			{
				return 0;
			}
			return 1;
		}
		

		// その他

		#region [ private ]
		//-----------------
		[StructLayout( LayoutKind.Sequential )]
		private struct ST文字位置
		{
			public char ch;
			public Point pt;
		}

		private bool bフルコンボ音再生済み;
		private CCounter ct表示用;
		private readonly Point[] ptFullCombo位置;
		private CSound sdDTXで指定されたフルコンボ音;
		private readonly ST文字位置[] st小文字位置;
		private readonly ST文字位置[] st大文字位置;
        private ST文字位置[] stScoreFont;

        private CTexture Dan_Plate;

		private void t小文字表示( int x, int y, string str )
		{
			foreach( char ch in str )
			{
				for( int i = 0; i < this.st小文字位置.Length; i++ )
				{
                    if( ch == ' ' )
                    {
                        break;
                    }

					if( this.st小文字位置[ i ].ch == ch )
					{
						Rectangle rectangle = new Rectangle( this.st小文字位置[ i ].pt.X, this.st小文字位置[ i ].pt.Y, 32, 38 );
						if(TJAPlayer3.Tx.Result_Number != null )
						{
                            TJAPlayer3.Tx.Result_Number.t2D描画( TJAPlayer3.app.Device, x, y, rectangle );
						}
						break;
					}
				}
				x += 22;
			}
		}
		private void t大文字表示( int x, int y, string str )
		{
			this.t大文字表示( x, y, str, false );
		}
		private void t大文字表示( int x, int y, string str, bool b強調 )
		{
			foreach( char ch in str )
			{
				for( int i = 0; i < this.st大文字位置.Length; i++ )
				{
					if( this.st大文字位置[ i ].ch == ch )
					{
						Rectangle rectangle = new Rectangle( this.st大文字位置[ i ].pt.X, this.st大文字位置[ i ].pt.Y, 11, 0x10 );
						if( ch == '.' )
						{
							rectangle.Width -= 2;
							rectangle.Height -= 2;
						}
						if(TJAPlayer3.Tx.Result_Number != null )
						{
                            TJAPlayer3.Tx.Result_Number.t2D描画( TJAPlayer3.app.Device, x, y, rectangle );
						}
						break;
					}
				}
				x += 8;
			}
		}

        protected void tスコア文字表示(int x, int y, string str)
        {
            foreach (char ch in str)
            {
                for (int i = 0; i < this.stScoreFont.Length; i++)
                {
                    if (this.stScoreFont[i].ch == ch)
                    {
                        Rectangle rectangle = new Rectangle(this.stScoreFont[ i ].pt.X, 0, 24, 40);
                        if (TJAPlayer3.Tx.Result_Score_Number != null)
                        {
                            TJAPlayer3.Tx.Result_Score_Number.t2D描画(TJAPlayer3.app.Device, x, y, rectangle);
                        }
                        break;
                    }
                }
                x += 24;
            }
        }
		//-----------------
		#endregion
	}
}
