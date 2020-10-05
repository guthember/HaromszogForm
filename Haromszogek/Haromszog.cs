using System;
using System.Collections.Generic;

namespace Haromszogek
{
  public class Haromszog
  {
    private double aOldal;
    private double bOldal;
    private double cOldal;

    public double Terulet { get; private set; }
    public double Kerulet { get; private set; }
    public bool Szerkesztheto { get; private set; }

    public List<string> AdatokSzoveg()
    {
      List<string> adatok = new List<string>();
      adatok.Add($"a: {aOldal} - b: {bOldal} - c: {cOldal}");
      if (Szerkesztheto)
      {
        adatok.Add($"Kerület: {Kerulet:N2} - Terület: {Terulet:N2}");
      }
      else
      {
        adatok.Add("Nem szerkeszthető!");
      }
  
      return adatok;
    }

    private void Szerk()
    {
      if (aOldal + bOldal > cOldal && 
          bOldal + cOldal > aOldal &&
          aOldal + cOldal > bOldal )
      {
        Szerkesztheto = true;
        Terulet = TeruletSzamitas();
        Kerulet = KeruletSzamitas();
      }
      else
      {
        Szerkesztheto = false;
        Terulet = 0;
        Kerulet = 0;
      }
    }

    private double TeruletSzamitas()
    {
      double s = (aOldal + bOldal + cOldal) / 2;
      return Math.Sqrt(s * 
                      (s - aOldal) * 
                      (s - bOldal) * (s - cOldal));
    }

    private double KeruletSzamitas()
    {
      return aOldal + bOldal + cOldal;
    }

    public Haromszog(double aOldal, double bOldal, double cOldal)
    {
      this.aOldal = aOldal;
      this.bOldal = bOldal;
      this.cOldal = cOldal;
      Szerk();
    }
  }
}