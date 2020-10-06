using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Haromszogek
{
  public partial class frmFo : Form
  {
    private double aOldal;
    private double bOldal;
    private double cOldal;


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
      try
      {
        aOldal = Convert.ToDouble(tbAoldal.Text);
        bOldal = Convert.ToDouble(tbBoldal.Text);
        cOldal = Convert.ToDouble(tbColdal.Text);

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
      catch (Exception ex)
      {
        MessageBox.Show("Számot adj meg!","Hiba",MessageBoxButtons.OK,
          MessageBoxIcon.Error);
        tbAoldal.Focus();
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

    private void btnFajlbol_Click(object sender, EventArgs e)
    {
      lbHarmszogLista.Items.Clear();
      if (ofdMegnyitas.ShowDialog() == DialogResult.OK)
      {
        try
        {
          StreamReader file = new StreamReader(ofdMegnyitas.FileName);
          try
          {
            while (!file.EndOfStream)
            {
              string sor = file.ReadLine();
              var h = new Haromszog(sor);

              lbHarmszogLista.Items.Add("Fáljból olvasás:");
              foreach (var a in h.AdatokSzoveg())
              {
                lbHarmszogLista.Items.Add(a);
              }
              lbHarmszogLista.Items.Add("-------------------");
            }
            file.Close();
          }
          catch (Exception ex)
          {
            MessageBox.Show(ex.Message);
          }
          finally
          {
            file.Close();
          }
        }
        catch (Exception ex)
        {
          MessageBox.Show(ex.Message);
        }
      }
    }
  }
}
