using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Shihai.Service;

namespace Shihai.WindowsApp
{
    public partial class BaseGame : Form
    {
        private Graphics _graphicGrid;
        private Pen _gridPen;
        private Graphics _gameGraph;
        private Pen _gamePen;
        private GraphService _graphService;
        private ControlForm _control;

        private string TeamTime = "rop";


        public BaseGame(ControlForm control)
        {
            InitializeComponent();
            _graphicGrid = CreateGraphics();
            _gridPen = new Pen(Color.Blue, 1);
            _gameGraph = CreateGraphics();
            _gamePen = new Pen(Color.Red, 1);
            _graphService = new GraphService();

            _control = control;


        }

        private void Shaihai_Paint(object sender, PaintEventArgs e)
        {
            DesenhaGrid();
        }

        private void DesenhaGrid()
        {
            _graphicGrid.Clear(SystemColors.Control);
            for (int i = 0; i*50 < 500; i ++)
            {
                for (int j = 0; j*50 < 500; j++)
                {
                    _graphicGrid.DrawRectangle(_gridPen, i * 50, j * 50, 50, 50);
                    Thread.Sleep(10);
              }
            }
        }

        private void Shaihai_MouseClick(object sender, MouseEventArgs e)
        {

            _control.ChangePicture(TeamTime);
            TeamTime = TeamTime == "pop" ? "rop" : "pop";
            

            try
            {
                var size = _graphService.GetCoordenades(e.X, e.Y, TeamTime);
            }
            catch (Exception ex)
            {


                MessageBox.Show(ex.Message);
                return;
            }

            for (int i = 0; i * 50 < 500; i++)
            {
                for (int j = 0; j * 50 < 500; j++)
                {
                    var image = _graphService.GetImage(i*50, j*50);
                    if(image==null)continue;
                    _gameGraph.DrawImage(image, (i * 50)+1, (j * 50)+1);
                }
            } 
            
        }

    }
}
