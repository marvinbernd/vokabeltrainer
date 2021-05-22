using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace Vokabeltrainer
{
    class Vokabel
    {
        private string _deutsch;
        private string _fremdsprache;
        private static List<Vokabel> _alleVokabeln = new List<Vokabel>();

        public Vokabel()
        {
            _alleVokabeln.Add(this);
        }

        public Vokabel(string deutsch, string fremdsprache)
        {
            _deutsch = deutsch;
            _fremdsprache = fremdsprache;
            _alleVokabeln.Add(this);
        }

        public string Deutsch
        {
            get { return _deutsch; }
            set 
            {
                if (value != "")
                    _deutsch = value;
            }
        }

        public string Fremdsprache
        {
            get { return _fremdsprache; }
            set 
            {
                if (value != "")
                    _fremdsprache = value;
            }
        }

        public static List<Vokabel> AlleVokabeln
        {
            get { return _alleVokabeln; }
        }

        public void SpieleSound()
        {
            SoundPlayer player = new SoundPlayer(@"wav\" + _fremdsprache + ".wav");
            player.Play();
        }
    }
}
