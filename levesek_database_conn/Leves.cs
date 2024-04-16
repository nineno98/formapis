using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace levesek_database_conn
{
    class Leves
    {
        private string megnevezes_;
        private int kaloria_;
        private double feherje_;
        private double zsir_;
        private double szenhidrat_;
        private double hamu_;
        private double rost_;

        public Leves(string megnevezes_, int kaloria_, double feherje_, double zsir_, double szenhidrat_, double hamu_, double rost_)
        {
            this.megnevezes_ = megnevezes_;
            this.kaloria_ = kaloria_;
            this.feherje_ = feherje_;
            this.zsir_ = zsir_;
            this.szenhidrat_ = szenhidrat_;
            this.hamu_ = hamu_;
            this.rost_ = rost_;
        }

        public string Megnevezes_ { get => megnevezes_; set => megnevezes_ = value; }
        public int Kaloria { get => kaloria_; set => kaloria_ = value; }
        public double Feherje { get => feherje_; set => feherje_ = value; }
        public double Zsir { get => zsir_; set => zsir_ = value; }
        public double Szenhidrat { get => szenhidrat_; set => szenhidrat_ = value; }
        public double Hamu { get => hamu_; set => hamu_ = value; }
        public double Rost { get => rost_; set => rost_ = value; }


        public override string ToString()
        {
            return megnevezes_ + " " + kaloria_ + " " + feherje_ + " " + zsir_ + " " + szenhidrat_ + " " + hamu_ + " " + rost_;
        }
    }
}
