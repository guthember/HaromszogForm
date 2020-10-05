using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Haromszogek
{
  public partial class frmFo : Form
  {
    private int aOldal;
    private int bOldal;
    private int cOldal;


    public frmFo()
    {
      aOldal = 0;
      bOldal = 0;
      cOldal = 0;
      InitializeComponent();
      tbAoldal.Text = aOldal.ToString();
      tbBoldal.Text = bOldal.ToString();
      tbColdal.Text = cOldal.ToString();
      lbHarmszogLista.Items.Clear();
    }

    private void btnKilepes_Click(object sender, EventArgs e)
    {
      Application.Exit();
    }

    private void btnSzamol_Click(object sender, EventArgs e)
    {
      aOldal = Convert.ToInt32(tbAoldal.Text);
      bOldal = Convert.ToInt32(tbBoldal.Text);
      cOldal = Convert.ToInt32(tbColdal.Text);

      if (aOldal == 0 || bOldal == 0 || cOldal == 0)
      {
        MessageBox.Show("Nem lehet 0 a háromszög oldala!", "Hiba",
          MessageBoxButtons.OK,
          MessageBoxIcon.Error);
      }
      else
      {
        var h = new Haromszog(aOldal, bOldal, cOldal);
        
        List<string> adatok = h.AdatokSzoveg();

        foreach (var a in adatok)
        {
          lbHarmszogLista.Items.Add(a);
        }

      }
    }

    private void btnTorol_Click(object sender, EventArgs e)
    {
      if(lbHarmszogLista.Items.Count > 0)
      {
        lbHarmszogLista.Items.Clear();
      }
      else
      {
        MessageBox.Show("Nincs mit törölni!");
      }
    }
  }
}
