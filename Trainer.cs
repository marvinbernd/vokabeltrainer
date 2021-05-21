using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vokabeltrainer
{
    class Trainer
    {
        private List<Vokabel> _pruefVokabeln;
        private int _laufendeNummer;

        public List<Vokabel> PruefVokabeln
        {
            get { return _pruefVokabeln; }
            set { _pruefVokabeln = value; }
        }

        public Vokabel AktuelleVokabel
        {
            get { return _pruefVokabeln[_laufendeNummer];  }
        }

        public void StarteDurchlauf()
        {
            mischeVokabeln();
            _laufendeNummer = -1;
        }

        private void mischeVokabeln()
        {
            int a, b;
            Vokabel v;
            Random r = new Random();
            for (int i = 0; i < _pruefVokabeln.Count; i++)
            {
                a = r.Next(_pruefVokabeln.Count);
                b = r.Next(_pruefVokabeln.Count);
                v = _pruefVokabeln[a];
                _pruefVokabeln[a] = _pruefVokabeln[b];
                _pruefVokabeln[b] = v;
            }
        }

        public Vokabel GetNaechsteVokabel()
        {
            Vokabel v = null;
            _laufendeNummer++;
            if (_laufendeNummer < _pruefVokabeln.Count)
                v =_pruefVokabeln[_laufendeNummer];
            return v;
        }
    }
}
