using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Schoolbib.Models
{
    public enum AvailabilityItem
    {
        Aanwezig,
        Uitgeleend,
        Gereserveerd, 
        Verloren
    }
   public enum Studychoices
    {
        Informatica,
        Othopedagogie,
        Ergotherapie,
        Logopedie,
        Electronica,
        Verpleegkunde,
    }
   public enum BookGenre
    {
        Thriller,
        Fantasy,
        ScienceFictie,
        Romance,
        nonFictie,
        Avontuur
    }
    public enum CDGenre
    {
        HipHop,
        Rock,
        Rap,
        Klasiek,
        Jazz
    }
   public enum DVDGenre
    {
        Actie,
        Fantasy,
        Komedie,
        Drama
    }
    public enum Language
    {
        FR,
        NL,
        ENG,
        DUI,
        SPA
    }
    public enum SexEnum
    { 
        Vrouw,
        Man,
        None
    }
    class Enums
    {
    }
}
