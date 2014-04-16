﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using FlameBadge;
namespace FlameBadge
{
    public partial class Form1 : Form
    {
        public FlameBadge game;
        public static Image[] textures;
        public static GameBoard board;
        public Form1(FlameBadge game)
        {
            InitializeComponent();
            textures = new Image[10000];
            textures[(int)'%'] = Image.FromFile("Art/grass.png");
            textures[(int)'^'] = Image.FromFile("Art/mountain.png");
            textures[(int)'~'] = Image.FromFile("Art/water.png");
            textures[(int)'z'] = Image.FromFile("Art/selected.png");
            textures[(int)'='] = Image.FromFile("Art/bridge.png");
            textures[(int)'#'] = Image.FromFile("Art/tree.png");
            textures[(int)'&'] = Image.FromFile("Art/road.png");
            textures[(int)'+'] = Image.FromFile("Art/castle1.png");
            textures[(int)'*'] = Image.FromFile("Art/castle2.png");
            textures[(int)'<'] = Image.FromFile("Art/enemy.png");
            textures[(int)'>'] = Image.FromFile("Art/player.png");
            textures[(int)'p'] = Image.FromFile("Art/possibleMove.png");

            //Debug to check that all images are same dimensions
            //foreach (Image x in textures)
            //{
            //    if(x!=null)
            //    {
            //        Console.Write(x.PhysicalDimension + "\n");
            //    }
            //}
            //textures[4] = Image.FromFile("../Art/soldier");
            //textures[5] = Image.FromFile("../Art/archer");

            panel1.Click += new EventHandler(panel1_Click);

            this.game = game;
            Invalidate();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Click(Object sender, MouseEventArgs e)
        {
        }
        private void panel1_Click(Object sender, EventArgs e)
        {
            Point point = panel1.PointToClient(Cursor.Position);
            game.selectUnit((point.X / 32), (point.Y / 32));
            panel1.Invalidate();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            //Gets gameboard
            try
            {
                board = game.getGameBoard();
            }
            catch
            {
            }
            int text = 0;
            
            //Draws tiles to screen. This should be changed to represent the boards size
            for (int i = 0; i < 20  ; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    if(board!=null && textures[(int)board.getTextureAtLocation(i,j)]!=null)
                        g.DrawImage(textures[(int)board.getTextureAtLocation(i,j)], new Point(j * 32, i * 32));
                    else if(board.getTextureAtLocation(i,j)!='@')
                        g.DrawImage(textures[(int)'%'], new Point(j * 32, i * 32));
                }

                
            }

            //Draws characters to screen
            foreach(PlayerCharacter p in game.getPlayerCharacters())
            {
                g.DrawImage(textures[(int)'>'], new Point(p.xPos*32, p.yPos*32));
            }
            foreach(EnemyCharacter p in game.getEnemyCharacters())
            {
                g.DrawImage(textures[(int)'<'], new Point(p.xPos*32, p.yPos*32));
            }


            //Handles drawing for the selected playerCharacter
            if(null!=game.selectUnit())
            {
                Console.Write("Drawing\n");
                g.DrawImage(textures[(int)'z'], new Point(game.selectUnit().xPos*32, game.selectUnit().yPos*32));
                label1.Text ="Health: " + game.selectUnit().health;
                
                foreach(Tuple<int,int> x in game.selectUnit().getPossibleMoves())
                {
                    g.DrawImage(textures[(int)'p'], new Point(x.Item1*32, x.Item2*32));
                };    
            
            }
            
        }
    }
}
