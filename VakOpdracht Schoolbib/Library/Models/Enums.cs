using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryModels.Models
{
    public enum AvailabilityItem
    {
        Aanwezig,
        Uitgeleend,
        GereserveerdAanwezig,
        Gereserveerduitgeleend
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
    public enum LanguageEnum
    {
        FR,
        NL,
        ENG,
        DUI,
        SPA
    }
    public enum SexEnum
    { 
        Vrouw =0,
        Man =1
    }
    class Enums
    {
    }
}
