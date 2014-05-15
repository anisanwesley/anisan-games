using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace Chess
{
	public class ChessForm : System.Windows.Forms.Form
	{
		#region These are the global variables and objects for ChessForm class
		private PictureBox[,] pb;
		private ListBox lb;
		Label label1;
		Label label2;
		Label label3;
		Label label4;
		Label label5;
		Label label6;
		Label label7;
		Label label8;
		Label labela;
		Label labelb;
		Label labelc;
		Label labeld;
		Label labele;
		Label labelf;
		Label labelg;
		Label labelh;

		private int cl;
		private int order;
		private int x1;
		private int y1;
		private Board brd;
		private Image img1;
		private Image img2;
		private Image img3;
		private Image img4;
		private Image img5;
		private Image img6;
		private Image img7;
		private Image img8;
		private Image img9;
		private Image img10;
		private Image img11;
		private Image img12;

		private Image img21;
		private Image img22;
		private Image img23;
		private Image img24;
		private Image img25;
		private Image img26;
		private Image img27;
		private Image img28;
		private Image img29;
		private Image img30;
		private Image img31;
		private Image img32;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion

		public ChessForm()
		{
			//InitializeComponent();
			init();
			init2();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		public void init()
		{
			pb=new PictureBox[8,8];
			brd=new Board();
			for(int i=0; i<8; i++)
				for(int j=0; j<8; j++)
				{
					pb[i,j]=new PictureBox();
					if(brd.getbcolor(i,j)==2)
						this.pb[i,j].BackColor = System.Drawing.Color.White;
					else
						this.pb[i,j].BackColor = System.Drawing.Color.Silver;
					this.pb[i,j].Location = new System.Drawing.Point(30+i*60, 10+j*60);
					this.pb[i,j].Name = "pb1";
					this.pb[i,j].Size = new System.Drawing.Size(60, 60);
					this.pb[i,j].TabIndex = i;
					this.pb[i,j].TabStop = false;
					this.Controls.AddRange(new System.Windows.Forms.Control[] {this.pb[i,j]});
				}
			lb=new ListBox();
			this.lb.Location=new System.Drawing.Point(530,10);
			this.lb.Name="lb";
			this.lb.Size=new System.Drawing.Size(150,500);
			this.lb.TabIndex=64;
			this.lb.TabStop=false;
			this.Controls.AddRange(new Control[] {this.lb});

			label1=new Label();
			this.label1.Location=new System.Drawing.Point(10,30);
			this.label1.Name="label1";
			this.label1.Size=new System.Drawing.Size(20,20);
			this.label1.TabIndex=65;
			this.label1.TabStop=false;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(162)));
			label1.Text="1";
			this.Controls.AddRange(new Control[] {this.label1});
			
			label2=new Label();
			this.label2.Location=new System.Drawing.Point(10,90);
			this.label2.Name="label2";
			this.label2.Size=new System.Drawing.Size(20,20);
			this.label2.TabIndex=65;
			this.label2.TabStop=false;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(162)));
			label2.Text="2";
			this.Controls.AddRange(new Control[] {this.label2});

			label3=new Label();
			this.label3.Location=new System.Drawing.Point(10,150);
			this.label3.Name="label3";
			this.label3.Size=new System.Drawing.Size(20,20);
			this.label3.TabIndex=65;
			this.label3.TabStop=false;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(162)));
			label3.Text="3";
			this.Controls.AddRange(new Control[] {this.label3});

			label4=new Label();
			this.label4.Location=new System.Drawing.Point(10,210);
			this.label4.Name="label4";
			this.label4.Size=new System.Drawing.Size(20,20);
			this.label4.TabIndex=65;
			this.label4.TabStop=false;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(162)));
			label4.Text="4";
			this.Controls.AddRange(new Control[] {this.label4});

			label5=new Label();
			this.label5.Location=new System.Drawing.Point(10,270);
			this.label5.Name="label5";
			this.label5.Size=new System.Drawing.Size(20,20);
			this.label5.TabIndex=65;
			this.label5.TabStop=false;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(162)));
			label5.Text="5";
			this.Controls.AddRange(new Control[] {this.label5});

			label6=new Label();
			this.label6.Location=new System.Drawing.Point(10,330);
			this.label6.Name="label6";
			this.label6.Size=new System.Drawing.Size(20,20);
			this.label6.TabIndex=65;
			this.label6.TabStop=false;
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(162)));
			label6.Text="6";
			this.Controls.AddRange(new Control[] {this.label6});

			label7=new Label();
			this.label7.Location=new System.Drawing.Point(10,390);
			this.label7.Name="label7";
			this.label7.Size=new System.Drawing.Size(20,20);
			this.label7.TabIndex=65;
			this.label7.TabStop=false;
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(162)));
			label7.Text="7";
			this.Controls.AddRange(new Control[] {this.label7});

			label8=new Label();
			this.label8.Location=new System.Drawing.Point(10,450);
			this.label8.Name="label8";
			this.label8.Size=new System.Drawing.Size(20,20);
			this.label8.TabIndex=65;
			this.label8.TabStop=false;
			this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(162)));
			label8.Text="8";
			this.Controls.AddRange(new Control[] {this.label8});

			labelh=new Label();
			this.labelh.Location=new System.Drawing.Point(50,490);
			this.labelh.Name="labelh";
			this.labelh.Size=new System.Drawing.Size(20,20);
			this.labelh.TabIndex=65;
			this.labelh.TabStop=false;
			this.labelh.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(162)));
			labelh.Text="h";
			this.Controls.AddRange(new Control[] {this.labelh});
			
			labelg=new Label();
			this.labelg.Location=new System.Drawing.Point(110,490);
			this.labelg.Name="labelg";
			this.labelg.Size=new System.Drawing.Size(20,30);
			this.labelg.TabIndex=65;
			this.labelg.TabStop=false;
			this.labelg.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(162)));
			labelg.Text="g";
			this.Controls.AddRange(new Control[] {this.labelg});

			labelf=new Label();
			this.labelf.Location=new System.Drawing.Point(175,490);
			this.labelf.Name="labelf";
			this.labelf.Size=new System.Drawing.Size(20,20);
			this.labelf.TabIndex=65;
			this.labelf.TabStop=false;
			this.labelf.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(162)));
			labelf.Text="f";
			this.Controls.AddRange(new Control[] {this.labelf});
			
			labele=new Label();
			this.labele.Location=new System.Drawing.Point(230,490);
			this.labele.Name="labele";
			this.labele.Size=new System.Drawing.Size(20,20);
			this.labele.TabIndex=65;
			this.labele.TabStop=false;
			this.labele.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(162)));
			labele.Text="e";
			this.Controls.AddRange(new Control[] {this.labele});
			
			labeld=new Label();
			this.labeld.Location=new System.Drawing.Point(290,490);
			this.labeld.Name="labeld";
			this.labeld.Size=new System.Drawing.Size(20,20);
			this.labeld.TabIndex=65;
			this.labeld.TabStop=false;
			this.labeld.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(162)));
			labeld.Text="d";
			this.Controls.AddRange(new Control[] {this.labeld});

			labelc=new Label();
			this.labelc.Location=new System.Drawing.Point(350,490);
			this.labelc.Name="labelc";
			this.labelc.Size=new System.Drawing.Size(20,20);
			this.labelc.TabIndex=65;
			this.labelc.TabStop=false;
			this.labelc.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(162)));
			labelc.Text="c";
			this.Controls.AddRange(new Control[] {this.labelc});
			
			labelb=new Label();
			this.labelb.Location=new System.Drawing.Point(410,490);
			this.labelb.Name="labelb";
			this.labelb.Size=new System.Drawing.Size(20,20);
			this.labelb.TabIndex=65;
			this.labelb.TabStop=false;
			this.labelb.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(162)));
			labelb.Text="b";
			this.Controls.AddRange(new Control[] {this.labelb});

			labela=new Label();
			this.labela.Location=new System.Drawing.Point(470,490);
			this.labela.Name="labela";
			this.labela.Size=new System.Drawing.Size(20,20);
			this.labela.TabIndex=65;
			this.labela.TabStop=false;
			this.labela.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(162)));
			labela.Text="a";
			this.Controls.AddRange(new Control[] {this.labela});

			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(700, 520);
			this.Name = "ChessForm";
			this.Text = "Xadrez v1.0 adaptado por www.macoratti.net (autor - Tarýk Cörüt)";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.pb[0,0].Click+=new System.EventHandler(pb_Click1);
			this.pb[1,0].Click+=new System.EventHandler(pb_Click2);
			this.pb[2,0].Click+=new System.EventHandler(pb_Click3);
			this.pb[3,0].Click+=new System.EventHandler(pb_Click4);
			this.pb[4,0].Click+=new System.EventHandler(pb_Click5);
			this.pb[5,0].Click+=new System.EventHandler(pb_Click6);
			this.pb[6,0].Click+=new System.EventHandler(pb_Click7);
			this.pb[7,0].Click+=new System.EventHandler(pb_Click8);

			this.pb[0,1].Click+=new System.EventHandler(pb_Click9);
			this.pb[1,1].Click+=new System.EventHandler(pb_Click10);
			this.pb[2,1].Click+=new System.EventHandler(pb_Click11);
			this.pb[3,1].Click+=new System.EventHandler(pb_Click12);
			this.pb[4,1].Click+=new System.EventHandler(pb_Click13);
			this.pb[5,1].Click+=new System.EventHandler(pb_Click14);
			this.pb[6,1].Click+=new System.EventHandler(pb_Click15);
			this.pb[7,1].Click+=new System.EventHandler(pb_Click16);

			this.pb[0,2].Click+=new System.EventHandler(pb_Click17);
			this.pb[1,2].Click+=new System.EventHandler(pb_Click18);
			this.pb[2,2].Click+=new System.EventHandler(pb_Click19);
			this.pb[3,2].Click+=new System.EventHandler(pb_Click20);
			this.pb[4,2].Click+=new System.EventHandler(pb_Click21);
			this.pb[5,2].Click+=new System.EventHandler(pb_Click22);
			this.pb[6,2].Click+=new System.EventHandler(pb_Click23);
			this.pb[7,2].Click+=new System.EventHandler(pb_Click24);

			this.pb[0,3].Click+=new System.EventHandler(pb_Click25);
			this.pb[1,3].Click+=new System.EventHandler(pb_Click26);
			this.pb[2,3].Click+=new System.EventHandler(pb_Click27);
			this.pb[3,3].Click+=new System.EventHandler(pb_Click28);
			this.pb[4,3].Click+=new System.EventHandler(pb_Click29);
			this.pb[5,3].Click+=new System.EventHandler(pb_Click30);
			this.pb[6,3].Click+=new System.EventHandler(pb_Click31);
			this.pb[7,3].Click+=new System.EventHandler(pb_Click32);

			this.pb[0,4].Click+=new System.EventHandler(pb_Click33);
			this.pb[1,4].Click+=new System.EventHandler(pb_Click34);
			this.pb[2,4].Click+=new System.EventHandler(pb_Click35);
			this.pb[3,4].Click+=new System.EventHandler(pb_Click36);
			this.pb[4,4].Click+=new System.EventHandler(pb_Click37);
			this.pb[5,4].Click+=new System.EventHandler(pb_Click38);
			this.pb[6,4].Click+=new System.EventHandler(pb_Click39);
			this.pb[7,4].Click+=new System.EventHandler(pb_Click40);

			this.pb[0,5].Click+=new System.EventHandler(pb_Click41);
			this.pb[1,5].Click+=new System.EventHandler(pb_Click42);
			this.pb[2,5].Click+=new System.EventHandler(pb_Click43);
			this.pb[3,5].Click+=new System.EventHandler(pb_Click44);
			this.pb[4,5].Click+=new System.EventHandler(pb_Click45);
			this.pb[5,5].Click+=new System.EventHandler(pb_Click46);
			this.pb[6,5].Click+=new System.EventHandler(pb_Click47);
			this.pb[7,5].Click+=new System.EventHandler(pb_Click48);

			this.pb[0,6].Click+=new System.EventHandler(pb_Click49);
			this.pb[1,6].Click+=new System.EventHandler(pb_Click50);
			this.pb[2,6].Click+=new System.EventHandler(pb_Click51);
			this.pb[3,6].Click+=new System.EventHandler(pb_Click52);
			this.pb[4,6].Click+=new System.EventHandler(pb_Click53);
			this.pb[5,6].Click+=new System.EventHandler(pb_Click54);
			this.pb[6,6].Click+=new System.EventHandler(pb_Click55);
			this.pb[7,6].Click+=new System.EventHandler(pb_Click56);

			this.pb[0,7].Click+=new System.EventHandler(pb_Click57);
			this.pb[1,7].Click+=new System.EventHandler(pb_Click58);
			this.pb[2,7].Click+=new System.EventHandler(pb_Click59);
			this.pb[3,7].Click+=new System.EventHandler(pb_Click60);
			this.pb[4,7].Click+=new System.EventHandler(pb_Click61);
			this.pb[5,7].Click+=new System.EventHandler(pb_Click62);
			this.pb[6,7].Click+=new System.EventHandler(pb_Click63);
			this.pb[7,7].Click+=new System.EventHandler(pb_Click64);
		}

		private void init2()
		{
			cl = 0;
			order = 2;
			x1 = 1;
			y1 = 1;
			img1=Image.FromFile("pic/siyahkale1.jpg");
			img2=Image.FromFile("pic/siyahkale2.jpg");
			img3=Image.FromFile("pic/siyahat1.jpg");
			img4=Image.FromFile("pic/siyahat2.jpg");
			img5=Image.FromFile("pic/siyahfil1.jpg");
			img6=Image.FromFile("pic/siyahfil2.jpg");
			img7=Image.FromFile("pic/siyahvezir1.jpg");
			img8=Image.FromFile("pic/siyahvezir2.jpg");
			img9=Image.FromFile("pic/siyahsah1.jpg");
			img10=Image.FromFile("pic/siyahsah2.jpg");
			img11=Image.FromFile("pic/siyahpiyon1.jpg");
			img12=Image.FromFile("pic/siyahpiyon2.jpg");

			img21=Image.FromFile("pic/beyazkale1.jpg");
			img22=Image.FromFile("pic/beyazkale2.jpg");
			img23=Image.FromFile("pic/beyazat1.jpg");
			img24=Image.FromFile("pic/beyazat2.jpg");
			img25=Image.FromFile("pic/beyazfil1.jpg");
			img26=Image.FromFile("pic/beyazfil2.jpg");
			img27=Image.FromFile("pic/beyazvezir1.jpg");
			img28=Image.FromFile("pic/beyazvezir2.jpg");
			img29=Image.FromFile("pic/beyazsah1.jpg");
			img30=Image.FromFile("pic/beyazsah2.jpg");
			img31=Image.FromFile("pic/beyazpiyon1.jpg");
			img32=Image.FromFile("pic/beyazpiyon2.jpg");

			pb[0,0].Image=img1;
			pb[1,0].Image=img4;
			pb[2,0].Image=img5;
			pb[3,0].Image=img8;
			pb[4,0].Image=img9;
			pb[5,0].Image=img6;
			pb[6,0].Image=img3;
			pb[7,0].Image=img2;

			pb[0,7].Image=img22;
			pb[1,7].Image=img23;
			pb[2,7].Image=img26;
			pb[3,7].Image=img27;
			pb[4,7].Image=img30;
			pb[5,7].Image=img25;
			pb[6,7].Image=img24;
			pb[7,7].Image=img21;

			pb[0,1].Image=img12;
			pb[1,1].Image=img11;
			pb[2,1].Image=img12;
			pb[3,1].Image=img11;
			pb[4,1].Image=img12;
			pb[5,1].Image=img11;
			pb[6,1].Image=img12;
			pb[7,1].Image=img11;

			pb[0,6].Image=img31;
			pb[1,6].Image=img32;
			pb[2,6].Image=img31;
			pb[3,6].Image=img32;
			pb[4,6].Image=img31;
			pb[5,6].Image=img32;
			pb[6,6].Image=img31;
			pb[7,6].Image=img32;

		}

		[STAThread]
		static void Main() 
		{
			Application.Run(new ChessForm());
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			
				
		}

		public int play(int i, int j)
		{
			int played=0;
			int k=brd.getInfo(i,j);
			string lstr=" ";
			if(k > 6)
			{
				played = 2;
			}
			else if(k < 7 && k != 0)
			{
				played = 1;
			}

			if(cl == 0 && k != 0 && played == order)
			{
				x1=i;
				y1=j;
				this.pb[i,j].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
				cl=1;
				return 0;
			}

			if(cl == 1)
			{
				int m = brd.getInfo(x1, y1);
				King king2=new King(order,x1,y1);
				Board b=new Board();
				int y,z;
				for(y=0;y<8;y++)
					for(z=0;z<8;z++)
						b.setSquare(brd.getInfo(y,z),y,z);
				switch(m)
				{
					case 1:
						Castle cs2=new Castle(1,x1,y1);
						if(cs2.move(brd,i,j)==1)
						{
							b.setSquare(0,x1,y1);
							b.setSquare(1,i,j);
							if(king2.isChecked(b)==1)
							{
								this.pb[x1,y1].BorderStyle = 0;
								cl=0;
								MessageBox.Show("Você não pode jogar ai !!! Você estará em Xeque-mate");
								return 0;
							}
							lstr="R";
							pb[x1,y1].Image=null;
							brd.setSquare(0,x1,y1);
							brd.setSquare(1,i,j);
							order++;
							if(brd.getbcolor(i,j)==2)
							{
								pb[i,j].Image=img1;
							}
							else if(brd.getbcolor(i,j)==1)
							{
								pb[i,j].Image=img2;
							}
						}
						else
						{
							cl=0;
							pb[x1,y1].BorderStyle=0;
							return 0;
						}
						break;

					case 2:
						Knight kn=new Knight(1,x1,y1);
						if(kn.move(brd,i,j)==1)
						{
							b.setSquare(0,x1,y1);
							b.setSquare(2,i,j);
							if(king2.isChecked(b)==1)
							{
								this.pb[x1,y1].BorderStyle = 0;
								cl=0;
                                MessageBox.Show("Você não pode jogar ai !!! Você estará em Xeque-mate");
								return 0;
							}
							lstr="N";
							pb[x1,y1].Image=null;
							brd.setSquare(0,x1,y1);
							brd.setSquare(2,i,j);
							order++;
							if(brd.getbcolor(i,j)==2)
							{
								pb[i,j].Image=img3;
							}
							else if(brd.getbcolor(i,j)==1)
							{
								pb[i,j].Image=img4;
							}
						}
						else
						{
							cl=0;
							pb[x1,y1].BorderStyle=0;
							return 0;
						}
						break;

					case 3:
						Bishop bsp=new Bishop(1,x1,y1);
						if(bsp.move(brd,i,j)==1)
						{
							b.setSquare(0,x1,y1);
							b.setSquare(3,i,j);
							if(king2.isChecked(b)==1)
							{
								this.pb[x1,y1].BorderStyle = 0;
								cl=0;
                                MessageBox.Show("Você não pode jogar ai !!! Você estará em Xeque-mate");
								return 0;
							}
							lstr="B";
							pb[x1,y1].Image=null;
							brd.setSquare(0,x1,y1);
							brd.setSquare(3,i,j);
							order++;
							if(brd.getbcolor(i,j)==2)
							{
								pb[i,j].Image=img5;
							}
							else if(brd.getbcolor(i,j)==1)
							{
								pb[i,j].Image=img6;
							}
						}
						else
						{
							cl=0;
							pb[x1,y1].BorderStyle=0;
							return 0;
						}
						break;

					case 4:
						Queen qn2=new Queen(1,x1,y1);
						if(qn2.move(brd,i,j)==1)
						{
							b.setSquare(0,x1,y1);
							b.setSquare(4,i,j);
							if(king2.isChecked(b)==1)
							{
								this.pb[x1,y1].BorderStyle = 0;
								cl=0;
								MessageBox.Show("Você não pode jogar ai !!! Você estará em Xeque-mate");
								return 0;
							}
							lstr="Q";
							pb[x1,y1].Image=null;
							brd.setSquare(0,x1,y1);
							brd.setSquare(4,i,j);
							order++;
							if(brd.getbcolor(i,j)==2)
							{
								pb[i,j].Image=img7;
							}
							else if(brd.getbcolor(i,j)==1)
							{
								pb[i,j].Image=img8;
							}
						}
						else
						{
							cl=0;
							pb[x1,y1].BorderStyle=0;
							return 0;
						}
						break;

					case 5:
						King kg2=new King(1,x1,y1);
						if(kg2.move(brd,i,j)==1)
						{
							b.setSquare(0,x1,y1);
							b.setSquare(5,i,j);
							if(king2.isChecked(b)==1)
							{
								this.pb[x1,y1].BorderStyle = 0;
								cl=0;
                                MessageBox.Show("Você não pode jogar ai !!! Você estará em Xeque-mate");
								return 0;
							}
							pb[x1,y1].Image=null;
							brd.setSquare(0,x1,y1);
							brd.setSquare(5,i,j);
							order++;
							if(brd.getbcolor(i,j)==2)
							{
								pb[i,j].Image=img9;
							}
							else if(brd.getbcolor(i,j)==1)
							{
								pb[i,j].Image=img10;
							}
						}
						else if(kg2.move(brd,i,j)==2)
						{
							b.setSquare(0,x1,y1);
							b.setSquare(5,i,j);
							if(king2.isChecked(b)==1)
							{
								this.pb[x1,y1].BorderStyle = 0;
								cl=0;
                                MessageBox.Show("Você não pode jogar ai !!! Você estará em Xeque-mate");
								return 0;
							}
							lstr="0-0";
							pb[x1,y1].Image=null;
							pb[0,0].Image=null;
							pb[2,0].Image=img9;
							pb[3,0].Image=img2;
							brd.setSquare(0,0,0);
							brd.setSquare(0,4,0);
							brd.setSquare(5,2,0);
							brd.setSquare(1,3,0);
							order++;
						}

						else if(kg2.move(brd,i,j)==3)
						{
							b.setSquare(0,x1,y1);
							b.setSquare(5,i,j);
							if(king2.isChecked(b)==1)
							{
								this.pb[x1,y1].BorderStyle = 0;
								cl=0;
                                MessageBox.Show("Você não pode jogar ai !!! Você estará em Xeque-mate");
								return 0;
							}
							lstr="0-0";
							pb[x1,y1].Image=null;
							pb[7,0].Image=null;
							pb[5,0].Image=img2;
							pb[6,0].Image=img9;
							brd.setSquare(0,4,0);
							brd.setSquare(0,7,0);
							brd.setSquare(1,5,0);
							brd.setSquare(5,6,0);
							order++;
						}
						else
						{
							cl=0;
							pb[x1,y1].BorderStyle=0;
							return 0;
						}
						break;
					case 6:
						Pawn p=new Pawn(1,x1,y1);
						if(p.move(brd,i,j)==1)
						{
							b.setSquare(0,x1,y1);
							b.setSquare(6,i,j);
							if(king2.isChecked(b)==1)
							{
								this.pb[x1,y1].BorderStyle = 0;
								cl=0;
								MessageBox.Show("Você não pode jogar ai !!! Você estará em Xeque-mate");
								return 0;
							}
							lstr="P";
							pb[x1,y1].Image=null;
							brd.setSquare(0,x1,y1);
							brd.setSquare(6,i,j);
							order++;
							if(brd.getbcolor(i,j)==2)
							{
								pb[i,j].Image=img11;
							}
							else if(brd.getbcolor(i,j)==1)
							{
								pb[i,j].Image=img12;
							}
						}
						else
						{
							cl=0;
							pb[x1,y1].BorderStyle=0;
							return 0;
						}
						break;

					case 7:
						Castle cs=new Castle(2,x1,y1);
						if(cs.move(brd,i,j)==1)
						{
							b.setSquare(0,x1,y1);
							b.setSquare(7,i,j);
							if(king2.isChecked(b)==1)
							{
								this.pb[x1,y1].BorderStyle = 0;
								cl=0;
								MessageBox.Show("Você não pode jogar ai !!! Você estará em Xeque-mate");
								return 0;
							}
							lstr="R";
							pb[x1,y1].Image=null;
							brd.setSquare(0,x1,y1);
							brd.setSquare(7,i,j);
							order--;
							if(brd.getbcolor(i,j)==2)
							{
								pb[i,j].Image=img21;
							}
							else if(brd.getbcolor(i,j)==1)
							{
								pb[i,j].Image=img22;
							}
						}
						else
						{
							cl=0;
							pb[x1,y1].BorderStyle=0;
							return 0;
						}
						break;
					
					case 8:
						Knight kn2=new Knight(2,x1,y1);
						if(kn2.move(brd,i,j)==1)
						{
							b.setSquare(0,x1,y1);
							b.setSquare(8,i,j);
							if(king2.isChecked(b)==1)
							{
								this.pb[x1,y1].BorderStyle = 0;
								cl=0;
								MessageBox.Show("Você não pode jogar ai !!! Você estará em Xeque-mate");
								return 0;
							}
							lstr="N";
							pb[x1,y1].Image=null;
							brd.setSquare(0,x1,y1);
							brd.setSquare(8,i,j);
							order--;
							if(brd.getbcolor(i,j)==2)
							{
								pb[i,j].Image=img23;
							}
							else if(brd.getbcolor(i,j)==1)
							{
								pb[i,j].Image=img24;
							}
						}
						else
						{
							cl=0;
							pb[x1,y1].BorderStyle=0;
							return 0;
						}
						break;
			
					case 9:
						Bishop bsp2=new Bishop(2,x1,y1);
						if(bsp2.move(brd,i,j)==1)
						{
							b.setSquare(0,x1,y1);
							b.setSquare(9,i,j);
							if(king2.isChecked(b)==1)
							{
								this.pb[x1,y1].BorderStyle = 0;
								cl=0;
								MessageBox.Show("Você não pode jogar ai !!! Você estará em Xeque-mate");
								return 0;
							}
							lstr="B";
							pb[x1,y1].Image=null;
							brd.setSquare(0,x1,y1);
							brd.setSquare(9,i,j);
							order--;
							if(brd.getbcolor(i,j)==2)
							{
								pb[i,j].Image=img25;
							}
							else if(brd.getbcolor(i,j)==1)
							{
								pb[i,j].Image=img26;
							}
						}
						else
						{
							cl=0;
							pb[x1,y1].BorderStyle=0;
							return 0;
						}
						break;

					case 10:
						Queen qn=new Queen(2,x1,y1);
						if(qn.move(brd,i,j)==1)
						{
							b.setSquare(0,x1,y1);
							b.setSquare(10,i,j);
							if(king2.isChecked(b)==1)
							{
								this.pb[x1,y1].BorderStyle = 0;
								cl=0;
								MessageBox.Show("Você não pode jogar ai !!! Você estará em Xeque-mate");
								return 0;
							}
							lstr="Q";
							pb[x1,y1].Image=null;
							brd.setSquare(0,x1,y1);
							brd.setSquare(10,i,j);
							order--;
							if(brd.getbcolor(i,j)==2)
							{
								pb[i,j].Image=img27;
							}
							else if(brd.getbcolor(i,j)==1)
							{
								pb[i,j].Image=img28;
							}
						}
						else
						{
							cl=0;
							pb[x1,y1].BorderStyle=0;
							return 0;
						}
						break;

					case 11:
						King kg=new King(2,x1,y1);
						if(kg.move(brd,i,j)==1)
						{
							b.setSquare(0,x1,y1);
							b.setSquare(11,i,j);
							if(king2.isChecked(b)==1)
							{
								this.pb[x1,y1].BorderStyle = 0;
								cl=0;
								MessageBox.Show("Você não pode jogar ai !!! Você estará em Xeque-mate");
								return 0;
							}
							lstr="K";
							pb[x1,y1].Image=null;
							brd.setSquare(0,x1,y1);
							brd.setSquare(11,i,j);
							order--;
							if(brd.getbcolor(i,j)==2)
							{
								pb[i,j].Image=img29;
							}
							else if(brd.getbcolor(i,j)==1)
							{
								pb[i,j].Image=img30;
							}
						}

						else if(kg.move(brd,i,j)==2)
						{
							b.setSquare(0,x1,y1);
							b.setSquare(11,i,j);
							if(king2.isChecked(b)==1)
							{
								this.pb[x1,y1].BorderStyle = 0;
								cl=0;
								MessageBox.Show("Você não pode jogar ai !!! Você estará em Xeque-mate");
								return 0;
							}
							lstr="0-0";
							pb[x1,y1].Image=null;
							pb[0,7].Image=null;
							pb[ 2, 7].Image=img30;
							pb[ 3, 7].Image=img21;
							brd.setSquare(0,0,7);
							brd.setSquare(0,4,7);
							brd.setSquare(11,2,7);
							brd.setSquare(5,3,7);
							order--;
						}

						else if(kg.move(brd,i,j)==3)
						{
							b.setSquare(0,x1,y1);
							b.setSquare(11,i,j);
							if(king2.isChecked(b)==1)
							{
								this.pb[x1,y1].BorderStyle = 0;
								cl=0;
								MessageBox.Show("Você não pode jogar ai !!! Você estará em Xeque-mate");
								return 0;
							}
							lstr="0-0";
							pb[x1,y1].Image=null;
							pb[7,7].Image=null;
							pb[5,7].Image=img21;
							pb[6,7].Image=img30;
							brd.setSquare(0,4,7);
							brd.setSquare(0,7,7);
							brd.setSquare(7,5,7);
							brd.setSquare(11,6,7);
							order--;
						}
						else
						{
							cl=0;
							pb[x1,y1].BorderStyle=0;
							return 0;
						}
						break;

					case 12:
						Pawn p2=new Pawn(2,x1,y1);					
						if(p2.move(brd,i,j)==1)
						{
							b.setSquare(0,x1,y1);
							b.setSquare(12,i,j);
							if(king2.isChecked(b)==1)
							{
								cl=0;
								this.pb[x1,y1].BorderStyle = 0;
								MessageBox.Show("Você não pode jogar ai !!! Você estará em Xeque-mate");
								return 0;
							}
							lstr="P";
							pb[x1,y1].Image=null;
							brd.setSquare(0,x1,y1);
							brd.setSquare(12,i,j);
							order--;
							if(brd.getbcolor(i,j)==2)
							{
								pb[i,j].Image=img31;
							}
							else if(brd.getbcolor(i,j)==1)
							{
								pb[i,j].Image=img32;
							}
						}
						else
						{
							cl=0;
							pb[x1,y1].BorderStyle=0;
							return 0;
						}
						break;
				}
				this.pb[x1,y1].BorderStyle = 0;
				cl=0;
				string str,str2;
				King king=new King(order,x1,y1);
				if(order==1)
				{
					str="Pretas";
					str2="Brancas";
				}
				else
				{
					str="Brancas";
					str2="Pretas";
				}
				string lstr2=" ",lstr3=" ";
				switch(i)
				{
					case 0:
						lstr2="h";
						break;
					case 1:
						lstr2="g";
						break;
					case 2:
						lstr2="f";
						break;
					case 3:
						lstr2="e";
						break;
					case 4:
						lstr2="d";
						break;
					case 5:
						lstr2="c";
						break;
					case 6:
						lstr2="b";
						break;
					case 7:
						lstr2="a";
						break;
				}

				switch(x1)
				{
					case 0:
						lstr3="h";
						break;
					case 1:
						lstr3="g";
						break;
					case 2:
						lstr3="f";
						break;
					case 3:
						lstr3="e";
						break;
					case 4:
						lstr3="d";
						break;
					case 5:
						lstr3="c";
						break;
					case 6:
						lstr3="b";
						break;
					case 7:
						lstr3="a";
						break;
				}
				
				if(king.isChecked(brd)==1)
				{
					if(brd.isMated(order)==1)
					{
						this.lb.Items.AddRange(new object[] {lstr});
						lstr=str2+" "+lstr + " " + lstr3 + (y1+1).ToString() + " Para " +lstr2 + (j+1).ToString();
						MessageBox.Show(str + " XEQUE MATE");
						Application.Exit();
					}
					else
					{
						lstr=str2+" XEQUE "+lstr + " " + lstr3 + (y1+1).ToString() + " Para " +lstr2 + (j+1).ToString();
						this.lb.Items.AddRange(new object[] {lstr});
						MessageBox.Show(str2 + " XEQUE");
					}

				}
				else
				{	
					lstr=str2+" "+lstr + " " + lstr3 + (y1+1).ToString() + " Para " +lstr2 + (j+1).ToString();
					this.lb.Items.AddRange(new object[] {lstr});
				}

				return 1;
			}
			return 0;
		}

		#region These are the Click events for Picture Boxes in the form
		
		private void pb_Click1(object sender, System.EventArgs e)
		{
			play(0,0);
		}

		private void pb_Click2(object sender, System.EventArgs e)
		{
			play(1,0);
		}

		private void pb_Click3(object sender, System.EventArgs e)
		{
			play(2,0);
		}

		private void pb_Click4(object sender, System.EventArgs e)
		{
			play(3,0);
		}

		private void pb_Click5(object sender, System.EventArgs e)
		{
			play(4,0);
		}

		private void pb_Click6(object sender, System.EventArgs e)
		{
			play(5,0);
		}

		private void pb_Click7(object sender, System.EventArgs e)
		{
			play(6,0);
		}

		private void pb_Click8(object sender, System.EventArgs e)
		{
			play(7,0);
		}

		private void pb_Click9(object sender, System.EventArgs e)
		{
			play(0,1);
		}

		private void pb_Click10(object sender, System.EventArgs e)
		{
			play(1,1);
		}

		private void pb_Click11(object sender, System.EventArgs e)
		{
			play(2,1);
		}

		private void pb_Click12(object sender, System.EventArgs e)
		{
			play(3,1);
		}

		private void pb_Click13(object sender, System.EventArgs e)
		{
			play(4,1);
		}

		private void pb_Click14(object sender, System.EventArgs e)
		{
			play(5,1);
		}

		private void pb_Click15(object sender, System.EventArgs e)
		{
			play(6,1);
		}

		private void pb_Click16(object sender, System.EventArgs e)
		{
			play(7,1);
		}

		private void pb_Click17(object sender, System.EventArgs e)
		{
			play(0,2);
		}

		private void pb_Click18(object sender, System.EventArgs e)
		{
			play(1,2);
		}

		private void pb_Click19(object sender, System.EventArgs e)
		{
			play(2,2);
		}

		private void pb_Click20(object sender, System.EventArgs e)
		{
			play(3,2);
		}

		private void pb_Click21(object sender, System.EventArgs e)
		{
			play(4,2);
		}

		
		private void pb_Click22(object sender, System.EventArgs e)
		{
			play(5,2);
		}

		private void pb_Click23(object sender, System.EventArgs e)
		{
			play(6,2);
		}

		private void pb_Click24(object sender, System.EventArgs e)
		{
			play(7,2);
		}

		private void pb_Click25(object sender, System.EventArgs e)
		{
			play(0,3);
		}

		private void pb_Click26(object sender, System.EventArgs e)
		{
			play(1,3);
		}

		private void pb_Click27(object sender, System.EventArgs e)
		{
			play(2,3);
		}

		private void pb_Click28(object sender, System.EventArgs e)
		{
			play(3,3);
		}

		private void pb_Click29(object sender, System.EventArgs e)
		{
			play(4,3);
		}

		
		private void pb_Click30(object sender, System.EventArgs e)
		{
			play(5,3);
		}

		private void pb_Click31(object sender, System.EventArgs e)
		{
			play(6,3);
		}

		private void pb_Click32(object sender, System.EventArgs e)
		{
			play(7,3);
		}

		private void pb_Click33(object sender, System.EventArgs e)
		{
			play(0,4);
		}

		private void pb_Click34(object sender, System.EventArgs e)
		{
			play(1,4);
		}

		private void pb_Click35(object sender, System.EventArgs e)
		{
			play(2,4);
		}

		private void pb_Click36(object sender, System.EventArgs e)
		{
			play(3,4);
		}

		private void pb_Click37(object sender, System.EventArgs e)
		{
			play(4,4);
		}

		
		private void pb_Click38(object sender, System.EventArgs e)
		{
			play(5,4);
		}

		private void pb_Click39(object sender, System.EventArgs e)
		{
			play(6,4);
		}

		private void pb_Click40(object sender, System.EventArgs e)
		{
			play(7,4);
		}

		private void pb_Click41(object sender, System.EventArgs e)
		{
			play(0,5);
		}

		private void pb_Click42(object sender, System.EventArgs e)
		{
			play(1,5);
		}

		private void pb_Click43(object sender, System.EventArgs e)
		{
			play(2,5);
		}

		private void pb_Click44(object sender, System.EventArgs e)
		{
			play(3,5);
		}

		private void pb_Click45(object sender, System.EventArgs e)
		{
			play(4,5);
		}

		
		private void pb_Click46(object sender, System.EventArgs e)
		{
			play(5,5);
		}

		private void pb_Click47(object sender, System.EventArgs e)
		{
			play(6,5);
		}

		private void pb_Click48(object sender, System.EventArgs e)
		{
			play(7,5);
		}

		private void pb_Click49(object sender, System.EventArgs e)
		{
			play(0,6);
		}

		private void pb_Click50(object sender, System.EventArgs e)
		{
			play(1,6);
		}

		private void pb_Click51(object sender, System.EventArgs e)
		{
			play(2,6);
		}

		private void pb_Click52(object sender, System.EventArgs e)
		{
			play(3,6);
		}

		private void pb_Click53(object sender, System.EventArgs e)
		{
			play(4,6);
		}

		
		private void pb_Click54(object sender, System.EventArgs e)
		{
			play(5,6);
		}

		private void pb_Click55(object sender, System.EventArgs e)
		{
			play(6,6);
		}

		private void pb_Click56(object sender, System.EventArgs e)
		{
			play(7,6);
		}

		private void pb_Click57(object sender, System.EventArgs e)
		{
			play(0,7);
		}

		private void pb_Click58(object sender, System.EventArgs e)
		{
			play(1,7);
		}

		private void pb_Click59(object sender, System.EventArgs e)
		{
			play(2,7);
		}

		private void pb_Click60(object sender, System.EventArgs e)
		{
			play(3,7);
		}

		private void pb_Click61(object sender, System.EventArgs e)
		{
			play(4,7);
		}

		private void pb_Click62(object sender, System.EventArgs e)
		{
			play(5,7);
		}

		private void pb_Click63(object sender, System.EventArgs e)
		{
			play(6,7);
		}

		private void pb_Click64(object sender, System.EventArgs e)
		{
			play(7,7);
		}
		#endregion
	}

}
