using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Diagnostics;
using SlimDX;
using FDK;

namespace TJAPlayer3
{
	internal class CAct演奏パネル文字列 : CActivity
	{

		// コンストラクタ

		public CAct演奏パネル文字列()
		{
			base.b活性化してない = true;
			this.Start();
		}


        // メソッド

        public void SetPanelString(string songName, string genreName, string stageText = null)
		{
			if( base.b活性化してる )
			{
				TJAPlayer3.tテクスチャの解放( ref this.txPanel );
				if( (songName != null ) && (songName.Length > 0 ) )
				{
					try
					{
					    using (var bmpSongTitle = pfMusicName.DrawPrivateFont(songName, TJAPlayer3.Skin.Game_MusicName_ForeColor, TJAPlayer3.Skin.Game_MusicName_BackColor))
					    {
					        this.txMusicName = TJAPlayer3.tテクスチャの生成( bmpSongTitle, false );
					    }

                        Bitmap bmpDiff;
                        string strDiff = "";
                        if (TJAPlayer3.Skin.eDiffDispMode == E難易度表示タイプ.n曲目に表示)
                        {
                            switch (TJAPlayer3.stage選曲.nSeelectedCource[0])
                            {
                                case 0:
                                    strDiff = "かんたん ";
                                    break;
                                case 1:
                                    strDiff = "ふつう ";
                                    break;
                                case 2:
                                    strDiff = "むずかしい ";
                                    break;
                                case 3:
                                    strDiff = "おに ";
                                    break;
                                case 4:
                                    strDiff = "えでぃと ";
                                    break;
                                default:
                                    strDiff = "おに ";
                                    break;
                            }
                            bmpDiff = pfMusicName.DrawPrivateFont(strDiff + stageText, TJAPlayer3.Skin.Game_StageText_ForeColor, TJAPlayer3.Skin.Game_StageText_BackColor );
                        }
                        else
                        {
                            bmpDiff = pfMusicName.DrawPrivateFont(stageText, TJAPlayer3.Skin.Game_StageText_ForeColor, TJAPlayer3.Skin.Game_StageText_BackColor );
                        }

					    using (bmpDiff)
					    {
					        this.tx難易度とステージ数 = TJAPlayer3.tテクスチャの生成( bmpDiff, false );
					    }
					}
					catch( CTextureCreateFailedException e )
					{
						Trace.TraceError( e.ToString() );
						Trace.TraceError( "パネル文字列テクスチャの生成に失敗しました。" );
						this.txPanel = null;
					}
				}
                if( !string.IsNullOrEmpty(genreName) )
                {
                    if(genreName.Equals( "アニメ" ) )
                    {
                        this.txGENRE = TJAPlayer3.Tx.TxCGen("Anime");
                    }
                    else if(genreName.Equals( "J-POP" ) )
                    {
                        this.txGENRE = TJAPlayer3.Tx.TxCGen("J-POP");
                    }
                    else if(genreName.Equals( "ゲームミュージック" ) )
                    {
                        this.txGENRE = TJAPlayer3.Tx.TxCGen("Game");
                    }
                    else if(genreName.Equals( "ナムコオリジナル" ) )
                    {
                        this.txGENRE = TJAPlayer3.Tx.TxCGen("Namco");
                    }
                    else if(genreName.Equals( "クラシック" ) )
                    {
                        this.txGENRE = TJAPlayer3.Tx.TxCGen("Classic");
                    }
                    else if(genreName.Equals( "どうよう" ) )
                    {
                        this.txGENRE = TJAPlayer3.Tx.TxCGen("Child");
                    }
                    else if(genreName.Equals( "バラエティ" ) )
                    {
                        this.txGENRE = TJAPlayer3.Tx.TxCGen("Variety");
                    }
                    else if(genreName.Equals( "ボーカロイド" ) || genreName.Equals( "VOCALOID" ) )
                    {
                        this.txGENRE = TJAPlayer3.Tx.TxCGen("Vocaloid");
                    }
                    else
                    {
                        using (var bmpDummy = new Bitmap( 1, 1 ))
                        {
                            this.txGENRE = TJAPlayer3.tテクスチャの生成( bmpDummy, true );
                        }
                    }
                }

			    this.ct進行用 = new CCounter( 0, 2000, 2, TJAPlayer3.Timer );
				this.Start();



			}
		}

        public void t歌詞テクスチャを生成する( string str歌詞 )
        {
            using (var bmpleric = this.pf歌詞フォント.DrawPrivateFont( str歌詞, TJAPlayer3.Skin.Game_Lyric_ForeColor, TJAPlayer3.Skin.Game_Lyric_BackColor ))
            {
                this.tx歌詞テクスチャ = TJAPlayer3.tテクスチャの生成( bmpleric, false );
            }
        }

        /// <summary>
        /// レイヤー管理のため、On進行描画から分離。
        /// </summary>
        public void t歌詞テクスチャを描画する()
        {
            if( this.tx歌詞テクスチャ != null )
            {
                if (TJAPlayer3.Skin.Game_Lyric_ReferencePoint == CSkin.ReferencePoint.Left)
                {
                this.tx歌詞テクスチャ.t2D描画(TJAPlayer3.app.Device, TJAPlayer3.Skin.Game_Lyric_X , TJAPlayer3.Skin.Game_Lyric_Y);
                }
                else if (TJAPlayer3.Skin.Game_Lyric_ReferencePoint == CSkin.ReferencePoint.Right)
                {
                this.tx歌詞テクスチャ.t2D描画(TJAPlayer3.app.Device, TJAPlayer3.Skin.Game_Lyric_X - this.tx歌詞テクスチャ.szテクスチャサイズ.Width, TJAPlayer3.Skin.Game_Lyric_Y);
                }
                else
                {
                this.tx歌詞テクスチャ.t2D描画(TJAPlayer3.app.Device, TJAPlayer3.Skin.Game_Lyric_X - (this.tx歌詞テクスチャ.szテクスチャサイズ.Width / 2), TJAPlayer3.Skin.Game_Lyric_Y);
                }
            }
        }

		public void Stop()
		{
			this.bMute = true;
		}
		public void Start()
		{
			this.bMute = false;
		}


		// CActivity 実装

		public override void On活性化()
		{
            if( !string.IsNullOrEmpty( TJAPlayer3.ConfigIni.FontName ) )
            {
                this.pfMusicName = new CPrivateFastFont( new FontFamily( TJAPlayer3.ConfigIni.FontName), TJAPlayer3.Skin.Game_MusicName_FontSize);
                //this.pf縦書きテスト = new CPrivateFastFont( new FontFamily( CDTXMania.ConfigIni.strPrivateFontで使うフォント名 ), 22 );
            }
            else
                this.pfMusicName = new CPrivateFastFont( new FontFamily("MS UI Gothic"), TJAPlayer3.Skin.Game_MusicName_FontSize);

            if( !string.IsNullOrEmpty(TJAPlayer3.Skin.Game_Lyric_FontName))
            {
                this.pf歌詞フォント = new CPrivateFastFont(new FontFamily(TJAPlayer3.Skin.Game_Lyric_FontName), TJAPlayer3.Skin.Game_Lyric_FontSize);
            }
            else
            {
                this.pf歌詞フォント = new CPrivateFastFont(new FontFamily("MS UI Gothic"), TJAPlayer3.Skin.Game_Lyric_FontSize);
            }

			this.txPanel = null;
			this.ct進行用 = new CCounter();
			this.Start();
            this.bFirst = true;
			base.On活性化();
		}
		public override void On非活性化()
		{
			this.ct進行用 = null;
			base.On非活性化();
		}
		public override void OnManagedリソースの作成()
		{
			if( !base.b活性化してない )
			{
				base.OnManagedリソースの作成();
			}
		}
		public override void OnManagedリソースの解放()
		{
			if( !base.b活性化してない )
			{
				TJAPlayer3.tテクスチャの解放( ref this.txPanel );
				TJAPlayer3.tテクスチャの解放( ref this.txMusicName );
                TJAPlayer3.tテクスチャの解放( ref this.txGENRE );
                TJAPlayer3.tテクスチャの解放(ref this.txPanel);
                TJAPlayer3.tテクスチャの解放(ref this.tx歌詞テクスチャ);
                TJAPlayer3.t安全にDisposeする(ref this.pfMusicName);
                TJAPlayer3.t安全にDisposeする(ref this.pf歌詞フォント);
                base.OnManagedリソースの解放();
			}
		}
		public override int On進行描画()
		{
			throw new InvalidOperationException( "t進行描画(x,y)のほうを使用してください。" );
		}
		public int t進行描画( int x, int y )
		{
            if (TJAPlayer3.stage演奏ドラム画面.actDan.IsAnimating) return 0;
			if( !base.b活性化してない && !this.bMute )
			{
				this.ct進行用.t進行Loop();
                if( this.bFirst )
                {
                    this.ct進行用.n現在の値 = 300;
                }
                if( this.txGENRE != null )
                    this.txGENRE.t2D描画( TJAPlayer3.app.Device, TJAPlayer3.Skin.Game_Genre_X, TJAPlayer3.Skin.Game_Genre_Y );

                if( TJAPlayer3.Skin.b現在のステージ数を表示しない )
                {
                    if( this.txMusicName != null )
                    {
                        float fRate = 660.0f / this.txMusicName.szテクスチャサイズ.Width;
                        if (this.txMusicName.szテクスチャサイズ.Width <= 660.0f)
                            fRate = 1.0f;
                        this.txMusicName.vc拡大縮小倍率.X = fRate;
                        if (TJAPlayer3.Skin.Game_MusicName_ReferencePoint == CSkin.ReferencePoint.Center)
                        {
                            this.txMusicName.t2D描画(TJAPlayer3.app.Device, TJAPlayer3.Skin.Game_MusicName_X - ((this.txMusicName.szテクスチャサイズ.Width * fRate) / 2), TJAPlayer3.Skin.Game_MusicName_Y);
                        }
                        else if (TJAPlayer3.Skin.Game_MusicName_ReferencePoint == CSkin.ReferencePoint.Left)
                        {
                            this.txMusicName.t2D描画(TJAPlayer3.app.Device, TJAPlayer3.Skin.Game_MusicName_X, TJAPlayer3.Skin.Game_MusicName_Y);
                        }
                        else
                        {
                            this.txMusicName.t2D描画(TJAPlayer3.app.Device, TJAPlayer3.Skin.Game_MusicName_X - (this.txMusicName.szテクスチャサイズ.Width * fRate), TJAPlayer3.Skin.Game_MusicName_Y);
                        }
                    }
                }
                else
                {
                    #region[ 透明度制御 ]

                    if( this.ct進行用.n現在の値 < 745 )
                    {
                        this.bFirst = false;
                        this.txMusicName.n透明度 = 255;
                        if( this.txGENRE != null )
                            this.txGENRE.n透明度 = 255;
                        this.tx難易度とステージ数.n透明度 = 0;
                    }
                    else if( this.ct進行用.n現在の値 >= 745 && this.ct進行用.n現在の値 < 1000 )
                    {
                        this.txMusicName.n透明度 = 255 - ( this.ct進行用.n現在の値 - 745 );
                        if( this.txGENRE != null )
                            this.txGENRE.n透明度 = 255 - ( this.ct進行用.n現在の値 - 745 );
                        this.tx難易度とステージ数.n透明度 = this.ct進行用.n現在の値 - 745;
                    }
                    else if( this.ct進行用.n現在の値 >= 1000 && this.ct進行用.n現在の値 <= 1745 )
                    {
                        this.txMusicName.n透明度 = 0;
                        if( this.txGENRE != null )
                            this.txGENRE.n透明度 = 0;
                        this.tx難易度とステージ数.n透明度 = 255;
                    }
                    else if( this.ct進行用.n現在の値 >= 1745 )
                    {
                        this.txMusicName.n透明度 = this.ct進行用.n現在の値 - 1745;
                        if( this.txGENRE != null )
                            this.txGENRE.n透明度 = this.ct進行用.n現在の値 - 1745;
                        this.tx難易度とステージ数.n透明度 = 255 - ( this.ct進行用.n現在の値 - 1745 );
                    }
                    #endregion
                    if( this.txMusicName != null )
                    {
                        if(this.b初めての進行描画)
                        {
                            this.txMusicName.vc拡大縮小倍率.X = TJAPlayer3.GetSongNameXScaling(ref txMusicName);
                            b初めての進行描画 = false;
                        }
                        if (TJAPlayer3.Skin.Game_MusicName_ReferencePoint == CSkin.ReferencePoint.Center)
                        {
                            this.txMusicName.t2D描画(TJAPlayer3.app.Device, TJAPlayer3.Skin.Game_MusicName_X - ((this.txMusicName.szテクスチャサイズ.Width * txMusicName.vc拡大縮小倍率.X) / 2), TJAPlayer3.Skin.Game_MusicName_Y);
                        }
                        else if (TJAPlayer3.Skin.Game_MusicName_ReferencePoint == CSkin.ReferencePoint.Left)
                        {
                            this.txMusicName.t2D描画(TJAPlayer3.app.Device, TJAPlayer3.Skin.Game_MusicName_X, TJAPlayer3.Skin.Game_MusicName_Y);
                        }
                        else
                        {
                            this.txMusicName.t2D描画(TJAPlayer3.app.Device, TJAPlayer3.Skin.Game_MusicName_X - (this.txMusicName.szテクスチャサイズ.Width * txMusicName.vc拡大縮小倍率.X), TJAPlayer3.Skin.Game_MusicName_Y);
                        }
                    }
                    if (this.tx難易度とステージ数 != null)
                        if (TJAPlayer3.Skin.Game_MusicName_ReferencePoint == CSkin.ReferencePoint.Center)
                        {
                            this.tx難易度とステージ数.t2D描画(TJAPlayer3.app.Device, TJAPlayer3.Skin.Game_MusicName_X - (this.tx難易度とステージ数.szテクスチャサイズ.Width / 2), TJAPlayer3.Skin.Game_MusicName_Y);
                        }
                        else if (TJAPlayer3.Skin.Game_MusicName_ReferencePoint == CSkin.ReferencePoint.Left)
                        {
                            this.tx難易度とステージ数.t2D描画(TJAPlayer3.app.Device, TJAPlayer3.Skin.Game_MusicName_X, TJAPlayer3.Skin.Game_MusicName_Y);
                        }
                        else
                        {
                            this.tx難易度とステージ数.t2D描画(TJAPlayer3.app.Device, TJAPlayer3.Skin.Game_MusicName_X - this.tx難易度とステージ数.szテクスチャサイズ.Width, TJAPlayer3.Skin.Game_MusicName_Y);
                        }
                }

                //CDTXMania.act文字コンソール.tPrint( 0, 0, C文字コンソール.Eフォント種別.白, this.ct進行用.n現在の値.ToString() );

				//this.txMusicName.t2D描画( CDTXMania.app.Device, 1250 - this.txMusicName.szテクスチャサイズ.Width, 14 );
			}
			return 0;
		}


		// その他

		#region [ private ]
		//-----------------
		private CCounter ct進行用;

		private CTexture txPanel;
		private bool bMute;
        private bool bFirst;

        private CTexture txMusicName;
        private CTexture tx難易度とステージ数;
        private CTexture txGENRE;
        private CTexture tx歌詞テクスチャ;
        private CPrivateFastFont pfMusicName;
        private CPrivateFastFont pf歌詞フォント;
		//-----------------
		#endregion
	}
}
　
